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
    public class UserMenuService : IUserMenuService
    {
        #region Fields
        private readonly IRepository<UserMenu> _repository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;

        #endregion

        #region CTOR
        public UserMenuService(IRepository<Domain.UserMenu> repository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings)
        {
            _repository = repository;
            _mapper = mapper;
            _pagingSettings = pagingSettings.Value;
        }

        public async Task<UserMenuDTO> Create(UserMenuDTO modelDto, CancellationToken cancellationToken)
        {
            try
            {
                Domain.UserMenu menu = new()
                {
                    CreatedBy = modelDto.CreatedBy.Value,
                    CreatedDate = DateTime.Now,
                    UserId = modelDto.UserId,
                    MenuId = modelDto.MenuId,
                    IsActive=true
                };

                await _repository.AddAsync(menu, cancellationToken);
                return _mapper.Map<UserMenuDTO>(menu);
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

        public async Task<List<UserMenuDTO>> GetAsync(CancellationToken cancellationToken)
        {
            var model = await _repository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<UserMenuDTO>>(model);
        }

        public Task<PagedResult<UserMenu>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _repository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return model;
        }

        public async Task<UserMenuDTO> UpdateAsync(int menuId, UserMenuDTO modelDto, CancellationToken cancellationToken)
        {
            Domain.UserMenu menu = new()
            {
                Id = menuId,
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = modelDto.CreatedDate.Value,
                MenuId = modelDto.MenuId,
                UserId = modelDto.UserId,

                ModifiedDate = DateTime.Now
            };

            await _repository.UpdateAsync(menu, cancellationToken);
            return _mapper.Map<UserMenuDTO>(menu);
        }
        #endregion

    }
}
