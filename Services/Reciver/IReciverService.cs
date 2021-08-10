using Common.Utilities;
using Domain;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public interface IReciverService
    {
        Task<ReciverDTO> Create(ReciverDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int cityId, CancellationToken cancellationToken);
        Task<ReciverDTO> UpdateAsync(int cityId, ReciverDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<ReciverDTO>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<ReciverDTO>> GetAsync(int id,CancellationToken cancellationToken);
    }
}
