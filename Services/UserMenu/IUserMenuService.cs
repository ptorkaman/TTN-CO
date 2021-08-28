using Common.Utilities;
using DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;

namespace Services
{
    public interface IUserMenuService
    {
        Task<UserMenuDTO> Create(UserMenuDTO modelDto, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int cityId, CancellationToken cancellationToken);
        Task<UserMenuDTO> UpdateAsync(int cityId, UserMenuDTO modelDto, CancellationToken cancellationToken);
        Task<PagedResult<UserMenu>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken);
        Task<List<UserMenuDTO>> GetAsync(CancellationToken cancellationToken);
    }
}
