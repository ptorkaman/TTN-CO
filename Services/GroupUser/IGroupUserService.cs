using Common.Utilities;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public interface IGroupUserService
    {
        Task<GroupUserDTO> Create(GroupUserDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteGroupUserAsync(int cityId, CancellationToken cancellationToken);
        Task<GroupUserDTO> UpdateGroupUserAsync(int cityId, GroupUserDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<GroupUserDTO>> GetAllCitiesAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<GroupUserDTO>> GetAllAsync(CancellationToken cancellationToken);
    }
}
