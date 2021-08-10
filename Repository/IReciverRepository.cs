using Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Repository
{
    public interface IReciverRepository : IRepository<Reciver>
    {
        Task<List<Reciver>> GetByCityId(int id, CancellationToken cancellationToken);
    }
}