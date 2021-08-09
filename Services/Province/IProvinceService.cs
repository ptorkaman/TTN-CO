using Common.Utilities;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public interface IProvinceService
    {
        Task<ProvinceDTO> Create(ProvinceDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteProvinceAsync(int cityId, CancellationToken cancellationToken);
        Task<ProvinceDTO> UpdateProvinceAsync(int cityId, ProvinceDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<ProvinceDTO>> GetAllCitiesAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<ProvinceDTO>> GetAllAsync(int id,CancellationToken cancellationToken);
    }
}
