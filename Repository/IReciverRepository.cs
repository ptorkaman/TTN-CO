using Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Repository
{
    public interface IReciverRepository : IRepository<SenderReciver>
    {
        Task<List<SenderReciver>> GetByCityId(int id, CancellationToken cancellationToken);
    }
}