using Common.Utilities;
using Domain;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public interface IReceiptDetailService
    {
        //Task<ReceiptDetailDTO> Create(ReceiptDetailDTO modelDto, CancellationToken cancellationToken);
        //Task<bool> DeleteAsync(int cityId, CancellationToken cancellationToken);
        //Task<ReceiptDetailDTO> UpdateAsync(int cityId, ReceiptDetailDTO modelDto, CancellationToken cancellationToken);
        //Task<PagedResult<ReceiptDetail>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        //Task<List<ReceiptDetailDTO>> GetAsync(CancellationToken cancellationToken);
        Task<ReceiptDetailDTO> UpdateDetail(ReceiptDetailDTO modelDto, CancellationToken cancellationToken);
    }
}
