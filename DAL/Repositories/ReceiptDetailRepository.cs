using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DAL.Models;

namespace Repository
{
    public class ReceiptDetailRepository : Repository<ReceiptDetail>, IReceiptDetailRepository
    {


        public ReceiptDetailRepository(TTNContext dbContext) : base(dbContext)
        {

        }

        public Task<List<ReceiptDetail>> GetByReceiptId(long id, CancellationToken cancellationToken)
        {
            return Table.Where(x => x.IsActive && x.ReceiptId==id).ToListAsync();
        }

       
    }
}
