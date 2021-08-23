using Common.Utilities;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;

namespace Services
{
    public interface IParishService
    {
        Task<ParishDTO> Create(ParishDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int cityId, CancellationToken cancellationToken);
        Task<ParishDTO> UpdateAsync(int cityId, ParishDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<Parish>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<ParishDTO>> GetAsync(CancellationToken cancellationToken);
    }
}
