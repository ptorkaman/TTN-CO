using Common.Utilities;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;

namespace Services
{
    public interface IPermissionService
    {
        Task<PermissionDTO> Create(PermissionDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int cityId, CancellationToken cancellationToken);
        Task<PermissionDTO> UpdateAsync(int cityId, PermissionDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<Permission>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<PermissionDTO>> GetAsync(CancellationToken cancellationToken);
    }
}
