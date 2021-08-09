using Common.Utilities;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public interface IMenuPermissionService
    {
        Task<MenuPermissionDTO> Create(MenuPermissionDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteMenuPermissionAsync(int cityId, CancellationToken cancellationToken);
        Task<MenuPermissionDTO> UpdateMenuPermissionAsync(int cityId, MenuPermissionDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<MenuPermissionDTO>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<MenuPermissionDTO>> GetAll(CancellationToken cancellationToken);
    }
}
