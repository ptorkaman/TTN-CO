using Common.Utilities;
using Domain;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public interface IReceiptService
    {
        Task<ReceiptDTO> Create(ReceiptDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int cityId, CancellationToken cancellationToken);
        Task<ReceiptDTO> UpdateAsync(int cityId, ReceiptDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<Receipt>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<ReceiptDTO>> GetAsync(CancellationToken cancellationToken);
    }
}
