using Common.Utilities;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public interface IMenuService
    {
        Task<MenuDTO> Create(MenuDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int cityId, CancellationToken cancellationToken);
        Task<MenuDTO> UpdateAsync(int cityId, MenuDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<MenuDTO>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<MenuDTO>> GetAsync(CancellationToken cancellationToken);
    }
}
