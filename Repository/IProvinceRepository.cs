using Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Repository
{
    public interface IProvinceRepository : IRepository<Province>
    {
        Task<List<Province>> GetByCountryId(int id, CancellationToken cancellationToken);
    }
}