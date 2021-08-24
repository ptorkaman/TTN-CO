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
        Task<bool> DeleteAsync(int cityId, CancellationToken cancellationToken);
        Task<WarehouseDTO> UpdateAsync(int cityId, WarehouseDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<Warehouse>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<WarehouseDTO>> GetAsync(CancellationToken cancellationToken);
    }
}
