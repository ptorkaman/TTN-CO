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
using Domain;

namespace Services
{
    public class PermissionService : IPermissionService
    {
        #region Fields
        private readonly IRepository<Permission> _repository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;

        #endregion

        #region CTOR
        public PermissionService(IRepository<Domain.Permission> repository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings)
        {
            _repository = repository;
            _mapper = mapper;
            _pagingSettings = pagingSettings.Value;
        }

        public async Task<PermissionDTO> Create(PermissionDTO modelDto, CancellationToken cancellationToken)
        {
            Domain.Permission permission = new()
            {
           
                Name = modelDto.Name,
                EnglishName = modelDto.EnglishName,
             IsActive = true
            };

            await _repository.AddAsync(permission, cancellationToken);
            return _mapper.Map<PermissionDTO>(permission);

        }

        public async Task<bool> DeleteAsync(int permissionId, CancellationToken cancellationToken)
        {
            var model = _repository.GetById(permissionId);
            if (model == null)
                throw new CustomException("خطا در دریافت اطلاعات ");
            _repository.DeleteAsync(model, cancellationToken);
            return true;
        }

        public async Task<List<PermissionDTO>> GetAsync(CancellationToken cancellationToken)
        {
            var model = await _repository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<PermissionDTO>>(model);
        }

        public Task<PagedResult<Permission>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _repository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return model;
        }

        public async Task<PermissionDTO> UpdateAsync(int permissionId, PermissionDTO modelDto, CancellationToken cancellationToken)
        {
            Domain.Permission permission = new()
            {
                Id = permissionId,
         
                Name = modelDto.Name,
                EnglishName = modelDto.EnglishName,
                IsActive = modelDto.IsActive
            };

            await _repository.UpdateAsync(permission, cancellationToken);
            return _mapper.Map<PermissionDTO>(permission);
        }
        #endregion

    }
}
