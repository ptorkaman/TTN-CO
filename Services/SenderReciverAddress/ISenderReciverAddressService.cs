using Common.Utilities;
using Domain;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public interface ISenderReciverAddressService
    {
        Task<SenderReciverAddressDTO> Create(SenderReciverAddressDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int cityId, CancellationToken cancellationToken);
        Task<SenderReciverAddressDTO> UpdateAsync(int cityId, SenderReciverAddressDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<SenderReciverAddress>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<SenderReciverAddressDTO>> GetAsync(CancellationToken cancellationToken);
    }
}
