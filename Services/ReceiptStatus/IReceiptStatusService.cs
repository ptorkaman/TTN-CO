using Common.Utilities;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public interface IReceiptStatusService
    {
        Task<ReceiptStatusDTO> Create(ReceiptStatusDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int cityId, CancellationToken cancellationToken);
        Task<ReceiptStatusDTO> UpdateAsync(int cityId, ReceiptStatusDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<ReceiptStatusDTO>> GetAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<ReceiptStatusDTO>> GetAllAsync(CancellationToken cancellationToken);
    }
}
