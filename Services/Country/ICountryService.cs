using Common.Utilities;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;

namespace Services
{
    public interface ICountryService
    {
        Task<CountryDTO> Create(CountryDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int cityId, CancellationToken cancellationToken);
        Task<CountryDTO> UpdateAsync(int cityId, CountryDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<Country>> GetAllCountryAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<CountryDTO>> GetAsync(CancellationToken cancellationToken);
    }
}
