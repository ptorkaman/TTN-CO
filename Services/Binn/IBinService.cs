using Common.Utilities;
using Domain;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public interface IBinService
    {
        Task<BinDTO> Create(BinDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int cityId, CancellationToken cancellationToken);
        Task<BinDTO> UpdateAsync(int cityId, BinDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<BinDTO>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<BinDTO>> GetAsync(int id,CancellationToken cancellationToken);
    }
}
