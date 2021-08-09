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
        private readonly IRepository<Menu> _menuRepository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;

        #endregion

        #region CTOR
        public MenuService(IRepository<Menu> menuRepository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings)
        {
            _menuRepository = menuRepository;
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

                await _menuRepository.AddAsync(menu, cancellationToken);
                return _mapper.Map<MenuDTO>(menu);
            }
            catch (Exception ex)
            {

                return null;
            }
            

        }

        public async Task<bool> DeleteMenuAsync(int menuId, CancellationToken cancellationToken)
        {
            var model = _menuRepository.GetById(menuId);
            if (model == null)
                throw new CustomException("خطا در دریافت اطلاعات ");
            _menuRepository.DeleteAsync(model, cancellationToken);
            return true;
        }

        public async Task<List<MenuDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var model = _menuRepository.GetAllAsync( cancellationToken);
            return _mapper.Map<List<MenuDTO>>(model);
        }

        public async Task<PagedResult<MenuDTO>> GetAllCitiesAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _menuRepository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return _mapper.Map<PagedResult<MenuDTO>>(model);
        }

        public async Task<MenuDTO> UpdateMenuAsync(int menuId, MenuDTO modelDto, CancellationToken cancellationToken)
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

            await _menuRepository.UpdateAsync(menu, cancellationToken);
            return _mapper.Map<MenuDTO>(menu);
        }
        #endregion

    }
}
