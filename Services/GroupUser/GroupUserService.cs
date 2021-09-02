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
using Models.Settings;

namespace Services
{
    public class GroupUserService : IGroupUserService
    {
        #region Fields
        private readonly IRepository<Domain.GroupUser> _repository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;

        #endregion

        #region CTOR
        public GroupUserService(IRepository<Domain.GroupUser> repository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings)
        {
            _repository = repository;
            _mapper = mapper;
            _pagingSettings = pagingSettings.Value;
        }

        public async Task<GroupUserDTO> Create(GroupUserDTO modelDto, CancellationToken cancellationToken)
        {

            //var model = _repository.GetByCityId(modelDto.Id) != null;
            //if (!model)
            //    throw new CustomException("خطا در دریافت اطلاعات ");

            Domain.GroupUser groupUser = new()
            {
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = DateTime.Now,
                Name = modelDto.Name,
                IsActive = true

            };

            await _repository.AddAsync(groupUser, cancellationToken);
            return _mapper.Map<GroupUserDTO>(groupUser);

        }

        public async Task<bool> DeleteGroupUserAsync(int groupUserId, CancellationToken cancellationToken)
        {
            var model = _repository.GetById(groupUserId);
            if (model == null)
                throw new CustomException("خطا در دریافت اطلاعات ");
            model.IsActive = false;
            _repository.UpdateAsync(model, cancellationToken); return true;
        }

        public async Task<List<GroupUserDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var model = _repository.GetAllAsync( cancellationToken);
            return _mapper.Map<List<GroupUserDTO>>(model);
        }

        public async Task<PagedResult<GroupUserDTO>> GetAllCitiesAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _repository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return _mapper.Map<PagedResult<GroupUserDTO>>(model);
        }

        public async Task<GroupUserDTO> UpdateGroupUserAsync(int groupUserId, GroupUserDTO modelDto, CancellationToken cancellationToken)
        {
            Domain.GroupUser groupUser = new()
            {
                Id = groupUserId,
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = modelDto.CreatedDate.Value,
                Name = modelDto.Name,
                
                ModifiedDate = DateTime.Now
            };

            await _repository.UpdateAsync(groupUser, cancellationToken);
            return _mapper.Map<GroupUserDTO>(groupUser);
        }
        #endregion

    }
}
