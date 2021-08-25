using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Repository
{
    public class ReceiptRepository : Repository<Receipt>, IReceiptRepository
    {


        public ReceiptRepository(TTNContext dbContext) : base(dbContext)
        {

        }

        public Task<List<Receipt>> GetByReceiptId(long id, CancellationToken cancellationToken)
        {
            return Table.Where(x => x.IsActive  ).ToListAsync();

        }
    }
}
