using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DAL.Models;

namespace Repository
{
    public class ParishRepository : Repository<Parish>, IParishRepository
    {


        public ParishRepository(TTNContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Parish>> GetByRegionId(int id, CancellationToken cancellationToken)
        {
            return await Table.Where(p => p.IsActive && p.RegionId == id).ToListAsync();
        }
    }

       
}
