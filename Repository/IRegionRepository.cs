using Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Repository
{
    public interface IRegionRepository : IRepository<Region>
    {
        Task<List<Region>> GetByCityId(int id, CancellationToken cancellationToken);
    }
}