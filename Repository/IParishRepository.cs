using Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Repository
{
    public interface IParishRepository : IRepository<Parish>
    {
        Task<List<Parish>> GetByRegionId(int id, CancellationToken cancellationToken);
    }
}