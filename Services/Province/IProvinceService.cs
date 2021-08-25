using Common.Utilities;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;

namespace Services
{
    public interface IProvinceService
    {
        Task<ProvinceDTO> Create(ProvinceDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int cityId, CancellationToken cancellationToken);
        Task<ProvinceDTO> UpdateAsync(int cityId, ProvinceDTO modelDto, CancellationToken cancellationToken);
        Task<List<ProvinceDTO>> GetAllAsync(CancellationToken cancellationToken);
        Task<PagedResult<Province>> GetAllProvinceAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<ProvinceDTO> GetById(int itemProvinceId);
    }
}
