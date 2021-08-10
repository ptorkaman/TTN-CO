using Common.Utilities;
using Domain;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public interface ICityService
    {
        Task<CityDTO> Create(CityDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int cityId, CancellationToken cancellationToken);
        Task<CityDTO> UpdateAsync(int cityId, CityDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<CityDTO>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<CityDTO>> GetAsync(int id,CancellationToken cancellationToken);
    }
}
