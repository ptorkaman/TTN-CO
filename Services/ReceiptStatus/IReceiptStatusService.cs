using Common.Utilities;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;

namespace Services
{
    public interface IReceiptStatusService
    {
        Task<ReceiptStatusDTO> Create(ReceiptStatusDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int cityId, CancellationToken cancellationToken);
        Task<ReceiptStatusDTO> UpdateAsync(int cityId, ReceiptStatusDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<ReceiptStatus>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<ReceiptStatusDTO>> GetAsync(CancellationToken cancellationToken);
        Task<ReceiptStatusDTO> GetByCode(int code, CancellationToken cancellationToken);

    }
}
