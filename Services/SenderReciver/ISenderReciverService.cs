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
        Task<bool> DeleteAsync(int Id, CancellationToken cancellationToken);
        Task<SenderReciverDTO> UpdateAsync(int Id, SenderReciverDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<SenderReciverDTO>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<SenderReciverDTO>> GetAsync(int id,CancellationToken cancellationToken);
    }
}
