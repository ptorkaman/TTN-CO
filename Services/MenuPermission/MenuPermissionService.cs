using AutoMapper;
using Common.Exceptions;
using Common.Utilities;
using DTO;
using Microsoft.Extensions.Options;
using Repository;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using Models.Settings;

namespace Services
{
    public class MenuPermissionService : IMenuPermissionService
    {
        #region Fields
        private readonly IRepository<MenuPermission> _repository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;

        #endregion

        #region CTOR
        public MenuPermissionService(IRepository<Domain.MenuPermission> repository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings)
        {
            _repository = repository;
            _mapper = mapper;
            _pagingSettings = pagingSettings.Value;
        }

        public async Task<MenuPermissionDTO> Create(MenuPermissionDTO modelDto, CancellationToken cancellationToken)
        {
            try
            {
                Domain.MenuPermission menu = new()
                {
                    CreatedBy = modelDto.CreatedBy.Value,
                    CreatedDate = DateTime.Now,
                    PermissionId = modelDto.PermissionId,
                    MenuId = modelDto.MenuId,
                    IsActive=true
                };

                await _repository.AddAsync(menu, cancellationToken);
                return _mapper.Map<MenuPermissionDTO>(menu);
            }
            catch (Exception ex)
            {

                return null;
            }
            

        }

        public async Task<bool> DeleteAsync(int menuId, CancellationToken cancellationToken)
        {
            var model = _repository.GetById(menuId);
            if (model == null)
                throw new CustomException("خطا در دریافت اطلاعات ");
            model.IsActive = false;
            _repository.UpdateAsync(model, cancellationToken);
            return true;
        }

        public async Task<List<MenuPermissionDTO>> GetAsync(CancellationToken cancellationToken)
        {
            var model = await _repository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<MenuPermissionDTO>>(model);
        }

        public Task<PagedResult<MenuPermission>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _repository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return model;
        }

        public async Task<MenuPermissionDTO> UpdateAsync(int menuId, MenuPermissionDTO modelDto, CancellationToken cancellationToken)
        {
            Domain.MenuPermission menu = new()
            {
                Id = menuId,
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = modelDto.CreatedDate.Value,
                MenuId = modelDto.MenuId,
                PermissionId = modelDto.PermissionId,

                ModifiedDate = DateTime.Now
            };

            await _repository.UpdateAsync(menu, cancellationToken);
            return _mapper.Map<MenuPermissionDTO>(menu);
        }
        #endregion

    }
}
