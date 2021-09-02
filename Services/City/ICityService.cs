using Common.Utilities;
using Domain;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TTN;

namespace Services
{
    public interface ICityService
    {
        Task<CityDTO> Create(CityDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int Id, CancellationToken cancellationToken);
        Task<CityDTO> UpdateAsync(int Id, CityDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<City>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<CityDTO>> GetAsync(CancellationToken cancellationToken);
        Task<PagedResult<City>> FindAll(int pageSize, int pageIndex, Criteria criteria);
    }
}
