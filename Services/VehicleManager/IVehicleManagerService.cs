using Common.Utilities;
using Domain;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public interface IVehicleManagerService
    {
        Task<VehicleManagerDTO> Create(VehicleManagerDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int cityId, CancellationToken cancellationToken);
        Task<VehicleManagerDTO> UpdateAsync(int Id, VehicleManagerDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<VehicleManager>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<VehicleManagerDTO>> GetAsync(CancellationToken cancellationToken);
    }
}
