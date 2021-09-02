using Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Repository
{
    public interface IBinRepository : IRepository<Bin>
    {
        Task<List<Bin>> GetByWarehoseId(int id, CancellationToken cancellationToken);
    }
}