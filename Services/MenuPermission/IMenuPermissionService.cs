using Common.Utilities;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;

namespace Services
{
    public interface IMenuPermissionService
    {
        Task<MenuPermissionDTO> Create(MenuPermissionDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int cityId, CancellationToken cancellationToken);
        Task<MenuPermissionDTO> UpdateAsync(int cityId, MenuPermissionDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<MenuPermission>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<MenuPermissionDTO>> GetAsync(CancellationToken cancellationToken);
    }
}
