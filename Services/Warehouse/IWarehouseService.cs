using Common.Utilities;
using Domain;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public interface IWarehouseService
    {
        Task<WarehouseDTO> Create(WarehouseDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteWarehouseAsync(int cityId, CancellationToken cancellationToken);
        Task<WarehouseDTO> UpdateWarehouseAsync(int cityId, WarehouseDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<WarehouseDTO>> GetAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<WarehouseDTO>> GetByCityId(int id,CancellationToken cancellationToken);
    }
}
