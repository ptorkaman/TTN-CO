using Common.Utilities;
using Domain;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public interface ISenderReciverService
    {
        Task<SenderReciverDTO> Create(SenderReciverDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int cityId, CancellationToken cancellationToken);
        Task<SenderReciverDTO> UpdateAsync(int cityId, SenderReciverDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<SenderReciver>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<SenderReciverDTO>> GetAsync(CancellationToken cancellationToken);
    }
}
