using Common.Utilities;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;

namespace Services
{
    public interface IStuffManagerService
    {
        Task<StuffManagerDTO> Create(StuffManagerDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int cityId, CancellationToken cancellationToken);
        Task<StuffManagerDTO> UpdateAsync(int cityId, StuffManagerDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<StuffManager>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<StuffManagerDTO>> GetAllAsync(CancellationToken cancellationToken);
    }
}
