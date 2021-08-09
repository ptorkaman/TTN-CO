using Common.Utilities;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public interface IBijakStatusService
    {
        Task<ReceiptStatusDTO> Create(ReceiptStatusDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteBijakStatusAsync(int cityId, CancellationToken cancellationToken);
        Task<ReceiptStatusDTO> UpdateBijakStatusAsync(int cityId, ReceiptStatusDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<ReceiptStatusDTO>> GetAllCitiesAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<ReceiptStatusDTO>> GetAllAsync(CancellationToken cancellationToken);
    }
}
