﻿using Common.Utilities;
using Domain;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public interface IPackageTypeService
    {
        Task<PackageTypeDTO> Create(PackageTypeDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int Id, CancellationToken cancellationToken);
        Task<PackageTypeDTO> UpdateAsync(int cityId, PackageTypeDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<PackageTypeDTO>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
    }
}
