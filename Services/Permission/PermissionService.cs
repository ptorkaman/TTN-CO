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
    public class PermissionService : IPermissionService
    {
        #region Fields
        private readonly IRepository<Domain.Permission> _permissionRepository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;

        #endregion

        #region CTOR
        public PermissionService(IRepository<Domain.Permission> permissionRepository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings)
        {
            _permissionRepository = permissionRepository;
            _mapper = mapper;
            _pagingSettings = pagingSettings.Value;
        }

        public async Task<PermissionDTO> Create(PermissionDTO modelDto, CancellationToken cancellationToken)
        {
            Domain.Permission permission = new()
            {
           
                Name = modelDto.Name,
                EnglishName = modelDto.EnglishName,
             
            };

            await _permissionRepository.AddAsync(permission, cancellationToken);
            return _mapper.Map<PermissionDTO>(permission);

        }

        public async Task<bool> DeletePermissionAsync(int permissionId, CancellationToken cancellationToken)
        {
            var model = _permissionRepository.GetById(permissionId);
            if (model == null)
                throw new CustomException("خطا در دریافت اطلاعات ");
            _permissionRepository.DeleteAsync(model, cancellationToken);
            return true;
        }

        public async Task<List<PermissionDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var model = _permissionRepository.GetAllAsync( cancellationToken);
            return _mapper.Map<List<PermissionDTO>>(model);
        }

        public async Task<PagedResult<PermissionDTO>> GetAllCitiesAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _permissionRepository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return _mapper.Map<PagedResult<PermissionDTO>>(model);
        }

        public async Task<PermissionDTO> UpdatePermissionAsync(int permissionId, PermissionDTO modelDto, CancellationToken cancellationToken)
        {
            Domain.Permission permission = new()
            {
                Id = permissionId,
         
                Name = modelDto.Name,
                EnglishName = modelDto.EnglishName,
                
            };

            await _permissionRepository.UpdateAsync(permission, cancellationToken);
            return _mapper.Map<PermissionDTO>(permission);
        }
        #endregion

    }
}
