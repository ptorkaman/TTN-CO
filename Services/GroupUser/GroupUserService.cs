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
    public class GroupUserService : IGroupUserService
    {
        #region Fields
        private readonly IRepository<Domain.GroupUser> _groupUserRepository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;

        #endregion

        #region CTOR
        public GroupUserService(IRepository<Domain.GroupUser> groupUserRepository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings)
        {
            _groupUserRepository = groupUserRepository;
            _mapper = mapper;
            _pagingSettings = pagingSettings.Value;
        }

        public async Task<GroupUserDTO> Create(GroupUserDTO modelDto, CancellationToken cancellationToken)
        {

            //var model = _groupUserRepository.GetByCityId(modelDto.Id) != null;
            //if (!model)
            //    throw new CustomException("خطا در دریافت اطلاعات ");

            Domain.GroupUser groupUser = new()
            {
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = DateTime.Now,
                Name = modelDto.Name,
                IsActive = true

            };

            await _groupUserRepository.AddAsync(groupUser, cancellationToken);
            return _mapper.Map<GroupUserDTO>(groupUser);

        }

        public async Task<bool> DeleteGroupUserAsync(int groupUserId, CancellationToken cancellationToken)
        {
            var model = _groupUserRepository.GetById(groupUserId);
            if (model == null)
                throw new CustomException("خطا در دریافت اطلاعات ");
            _groupUserRepository.DeleteAsync(model, cancellationToken);
            return true;
        }

        public async Task<List<GroupUserDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var model = _groupUserRepository.GetAllAsync( cancellationToken);
            return _mapper.Map<List<GroupUserDTO>>(model);
        }

        public async Task<PagedResult<GroupUserDTO>> GetAllCitiesAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _groupUserRepository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
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

            await _groupUserRepository.UpdateAsync(groupUser, cancellationToken);
            return _mapper.Map<GroupUserDTO>(groupUser);
        }
        #endregion

    }
}
