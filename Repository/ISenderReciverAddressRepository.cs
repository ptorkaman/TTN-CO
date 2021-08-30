using Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Repository
{
    public interface ISenderReciverAddressRepository : IRepository<SenderReciverAddress>
    {
        Task<SenderReciverAddress> GetBySenderReciverId(int id, CancellationToken cancellationToken);
    }
}