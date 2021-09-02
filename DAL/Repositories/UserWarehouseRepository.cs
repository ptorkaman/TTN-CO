using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DAL.Models;

namespace Repository
{
    public class UserWarehouseRepository : Repository<UserWarhouse>, IUserWarehouseRepository
    {


        public UserWarehouseRepository(TTNContext dbContext) : base(dbContext)
        {

        }

        public Task<List<UserWarhouse>> GetByUserId(int id, CancellationToken cancellationToken)
        {
            return Table.Where(x => x.IsActive && x.UserId == id).ToListAsync();
        }

        public Task<List<UserWarhouse>> GetByWarehouseId(int id, CancellationToken cancellationToken)
        {
            return Table.Where(x => x.IsActive && x.WarehouseId == id).ToListAsync();

        }
    }
}
