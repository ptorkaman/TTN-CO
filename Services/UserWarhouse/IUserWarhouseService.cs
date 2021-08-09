﻿using Common.Utilities;
using Domain;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserWarhouseService
    {
        Task<UserWarhouseDTO> Create(UserWarhouseDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteUserWarhouseAsync(int cityId, CancellationToken cancellationToken);
        Task<UserWarhouseDTO> UpdateUserWarhouseAsync(int cityId, UserWarhouseDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<UserWarhouseDTO>> GetAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<UserWarhouseDTO>> GetByWarehouseId(int id,CancellationToken cancellationToken);
        Task<List<UserWarhouseDTO>> GetByUserId(int id, CancellationToken cancellationToken);
    }
}
