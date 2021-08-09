using Common.Utilities;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public interface IBijakStatusService
    {
        Task<BijakStatusDTO> Create(BijakStatusDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteBijakStatusAsync(int cityId, CancellationToken cancellationToken);
        Task<BijakStatusDTO> UpdateBijakStatusAsync(int cityId, BijakStatusDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<BijakStatusDTO>> GetAllCitiesAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<BijakStatusDTO>> GetAllAsync(CancellationToken cancellationToken);
    }
}
