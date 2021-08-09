using Common.Utilities;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public interface IPermissionService
    {
        Task<PermissionDTO> Create(PermissionDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeletePermissionAsync(int cityId, CancellationToken cancellationToken);
        Task<PermissionDTO> UpdatePermissionAsync(int cityId, PermissionDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<PermissionDTO>> GetAllCitiesAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<PermissionDTO>> GetAllAsync(CancellationToken cancellationToken);
    }
}
