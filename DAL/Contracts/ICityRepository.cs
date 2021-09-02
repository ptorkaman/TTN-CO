using Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Repository
{
    public interface ICityRepository : IRepository<City>
    {
        Task<List<City>> GetByCityId(int id, CancellationToken cancellationToken);
    }
}