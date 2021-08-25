using AutoMapper;
using Common.Exceptions;
using Common.Utilities;
using Domain;
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
    public class MenuService : IMenuService
    {
        #region Fields
        private readonly IRepository<Menu> _repository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;

        #endregion

        #region CTOR
        public MenuService(IRepository<Menu> repository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings)
        {
            _repository = repository;
            _mapper = mapper;
            _pagingSettings = pagingSettings.Value;
        }

        public async Task<MenuDTO> Create(MenuDTO modelDto, CancellationToken cancellationToken)
        {
            try
            {
                Menu menu = new()
                {
                    CreatedBy = modelDto.CreatedBy.Value,
                    CreatedDate = DateTime.Now,
                    Name = modelDto.Name,
                    ParentId = modelDto.ParentId,
                    IsActive = true
                };

                await _repository.AddAsync(menu, cancellationToken);
                return _mapper.Map<MenuDTO>(menu);
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

        public async Task<List<MenuDTO>> GetAsync(CancellationToken cancellationToken)
        {
            var model = await _repository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<MenuDTO>>(model);
        }

        public Task<PagedResult<Menu>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _repository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return model;
        }

        public async Task<MenuDTO> UpdateAsync(int menuId, MenuDTO modelDto, CancellationToken cancellationToken)
        {
            Domain.Menu menu = new()
            {
                Id = menuId,
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = modelDto.CreatedDate.Value,
                Name = modelDto.Name,
                ParentId = modelDto.ParentId,

                ModifiedDate = DateTime.Now
            };

            await _repository.UpdateAsync(menu, cancellationToken);
            return _mapper.Map<MenuDTO>(menu);
        }
        #endregion

    }
}
