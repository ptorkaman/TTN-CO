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
        Task<bool> DeleteMenuAsync(int cityId, CancellationToken cancellationToken);
        Task<MenuDTO> UpdateMenuAsync(int cityId, MenuDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<MenuDTO>> GetAllCitiesAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<MenuDTO>> GetAllAsync(CancellationToken cancellationToken);
    }
}
