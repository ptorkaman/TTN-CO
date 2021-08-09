using Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Repository
{
    public interface IWarehouseRepository : IRepository<Warehouse>
    {
        Task<List<Warehouse>> GetByCityId(int id, CancellationToken cancellationToken);
    }
}