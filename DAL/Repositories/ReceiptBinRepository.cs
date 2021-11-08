using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DAL.Models;

namespace Repository
{
    public class ReceiptBinRepository : Repository<ReceiptBin>, IReceiptBinRepository
    {


        public ReceiptBinRepository(TTNContext dbContext) : base(dbContext)
        {

        }

        public Task<List<ReceiptBin>> GetByReceiptBinId(int id, CancellationToken cancellationToken)
        {
            return Table.Where(x => x.IsActive && x.ReceiptId == id).ToListAsync();

        }
    }
}
