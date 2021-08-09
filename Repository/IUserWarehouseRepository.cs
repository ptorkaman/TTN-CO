using Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Repository
{
    public interface IUserWarehouseRepository : IRepository<UserWarhouse>
    {
        Task<List<UserWarhouse>> GetByWarehouseId(int id, CancellationToken cancellationToken);
        Task<List<UserWarhouse>> GetByUserId(int id, CancellationToken cancellationToken);
    }
}