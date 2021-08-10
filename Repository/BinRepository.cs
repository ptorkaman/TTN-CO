using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Repository
{
    public class BinRepository : Repository<Bin>, IBinRepository
    {


        public BinRepository(TTNContext dbContext) : base(dbContext)
        {

        }

        public Task<List<Bin>> GetByWarehoseId(int id, CancellationToken cancellationToken)
        {
            return Table.Where(x => x.IsActive && x.WarehoseId == id).ToListAsync();

        }
    }
}
