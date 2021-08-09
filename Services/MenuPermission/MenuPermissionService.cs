using AutoMapper;
using Common.Exceptions;
using Common.Utilities;
using DTO;
using DTO.Settings;
using Microsoft.Extensions.Options;
using Repository;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public class MenuPermissionService : IMenuPermissionService
    {
        #region Fields
        private readonly IRepository<Domain.MenuPermission> _menuRepository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;

        #endregion

        #region CTOR
        public MenuPermissionService(IRepository<Domain.MenuPermission> menuRepository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings)
        {
            _menuRepository = menuRepository;
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

                await _menuRepository.AddAsync(menu, cancellationToken);
                return _mapper.Map<MenuPermissionDTO>(menu);
            }
            catch (Exception ex)
            {

                return null;
            }
            

        }

        public async Task<bool> DeleteMenuPermissionAsync(int menuId, CancellationToken cancellationToken)
        {
            var model = _menuRepository.GetById(menuId);
            if (model == null)
                throw new CustomException("خطا در دریافت اطلاعات ");
            _menuRepository.DeleteAsync(model, cancellationToken);
            return true;
        }

        public async Task<List<MenuPermissionDTO>> GetAll(CancellationToken cancellationToken)
        {
            var model = _menuRepository.GetAllAsync( cancellationToken);
            return _mapper.Map<List<MenuPermissionDTO>>(model);
        }

        public async Task<PagedResult<MenuPermissionDTO>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _menuRepository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return _mapper.Map<PagedResult<MenuPermissionDTO>>(model);
        }

        public async Task<MenuPermissionDTO> UpdateMenuPermissionAsync(int menuId, MenuPermissionDTO modelDto, CancellationToken cancellationToken)
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

            await _menuRepository.UpdateAsync(menu, cancellationToken);
            return _mapper.Map<MenuPermissionDTO>(menu);
        }
        #endregion

    }
}
