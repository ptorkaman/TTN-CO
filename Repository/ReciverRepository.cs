using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Repository
{
    public class ReciverRepository : Repository<SenderReciver>, IReciverRepository
    {


        public ReciverRepository(TTNContext dbContext) : base(dbContext)
        {

        }

        public Task<List<SenderReciver>> GetByCityId(int id, CancellationToken cancellationToken)
        {
            return Table.Where(x => x.IsActive && x.CityId == id).ToListAsync();

        }
    }
}
