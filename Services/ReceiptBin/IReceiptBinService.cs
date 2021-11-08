using Common.Utilities;
using Domain;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TTN;

namespace Services
{
    public interface IReceiptBinService
    {
        Task<ReceiptBinDTO> Create(ReceiptBinDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int Id, CancellationToken cancellationToken);
        Task<ReceiptBinDTO> UpdateAsync(int Id, ReceiptBinDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<ReceiptBin>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<ReceiptBinDTO>> GetAsync(CancellationToken cancellationToken);
        Task<PagedResult<ReceiptBin>> FindAll(int pageSize, int pageIndex, Criteria criteria);
    }
}
