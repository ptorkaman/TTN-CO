using Common.Utilities;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public interface IParishService
    {
        Task<ParishDTO> Create(ParishDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteParishAsync(int cityId, CancellationToken cancellationToken);
        Task<ParishDTO> UpdateParishAsync(int cityId, ParishDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<ParishDTO>> GetAllCitiesAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<ParishDTO>> GetByRegionId(int id, CancellationToken cancellationToken);
    }
}
