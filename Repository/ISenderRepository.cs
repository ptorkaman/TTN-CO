using Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Repository
{
    public interface ISenderRepository : IRepository<Sender>
    {
        Task<List<Sender>> GetByCityId(int id, CancellationToken cancellationToken);
    }
}