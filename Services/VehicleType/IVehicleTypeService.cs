using Common.Utilities;
using Domain;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public interface IVehicleTypeService
    {
        Task<VehicleTypeDTO> Create(VehicleTypeDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int cityId, CancellationToken cancellationToken);
        Task<VehicleTypeDTO> UpdateAsync(int cityId, VehicleTypeDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<VehicleType>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<VehicleTypeDTO>> GetAsync(CancellationToken cancellationToken);
    }
}
