using Common.Utilities;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;

namespace Services
{
    public interface IRegionService
    {
        Task<RegionDTO> Create(RegionDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int cityId, CancellationToken cancellationToken);
        Task<RegionDTO> UpdateRegionAsync(int cityId, RegionDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<Region>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<RegionDTO>> GetAsync(CancellationToken cancellationToken);
    }
}
