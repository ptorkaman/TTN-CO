using Common.Utilities;
using Domain;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public interface IUnitService
    {
        Task<UnitDTO> Create(UnitDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int Id, CancellationToken cancellationToken);
        Task<UnitDTO> UpdateAsync(int Id, UnitDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<Unit>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<UnitDTO>> GetAsync(CancellationToken cancellationToken);
    }
}
