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
        Task<bool> DeleteCityAsync(int cityId, CancellationToken cancellationToken);
        Task<CityDTO> UpdateCityAsync(int cityId, CityDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<CityDTO>> GetAllCitiesAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<CityDTO>> GetAllAsync(int id,CancellationToken cancellationToken);
    }
}
