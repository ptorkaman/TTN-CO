using Common.Utilities;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public interface ICountryService
    {
        Task<CountryDTO> Create(CountryDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteCountryAsync(int cityId, CancellationToken cancellationToken);
        Task<CountryDTO> UpdateCountryAsync(int cityId, CountryDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<CountryDTO>> GetAllCitiesAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<CountryDTO>> GetAllAsync(CancellationToken cancellationToken);
    }
}
