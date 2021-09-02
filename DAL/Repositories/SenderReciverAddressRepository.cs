using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DAL.Models;

namespace Repository
{
    public class SenderReciverAddressRepository : Repository<SenderReciverAddress>, ISenderReciverAddressRepository
    {


        public SenderReciverAddressRepository(TTNContext dbContext) : base(dbContext)
        {

        }

        public async Task<SenderReciverAddress> GetBySenderReciverId(int id, CancellationToken cancellationToken)
        {
            return  Table.Where(x => x.IsActive && x.SenderReciverId == id).FirstOrDefault();

        }
    }
}
