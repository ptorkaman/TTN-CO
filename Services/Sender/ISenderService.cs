using Common.Utilities;
using Domain;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public interface ISenderService
    {
        Task<SenderDTO> Create(SenderDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int cityId, CancellationToken cancellationToken);
        Task<SenderDTO> UpdateAsync(int cityId, SenderDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<SenderDTO>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<SenderDTO>> GetAsync(int id,CancellationToken cancellationToken);
    }
}
