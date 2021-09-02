using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DAL.Models;

namespace Repository
{
    public class WarehouseRepository : Repository<Warehouse>, IWarehouseRepository
    {


        public WarehouseRepository(TTNContext dbContext) : base(dbContext)
        {

        }

        public Task<List<Warehouse>> GetByCityId(int id, CancellationToken cancellationToken)
        {
            return Table.Where(x => x.IsActive && x.CityId == id).ToListAsync();

        }
    }
}
