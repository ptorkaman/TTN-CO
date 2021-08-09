using Common.Utilities;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public interface IRegionService
    {
        Task<RegionDTO> Create(RegionDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteRegionAsync(int cityId, CancellationToken cancellationToken);
        Task<RegionDTO> UpdateRegionAsync(int cityId, RegionDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<RegionDTO>> GetAllCitiesAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<RegionDTO>> GetByCityId(int id, CancellationToken cancellationToken);
    }
}
