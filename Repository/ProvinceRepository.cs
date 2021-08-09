using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Repository
{
    public class ProvinceRepository : Repository<Province>, IProvinceRepository
    {


        public ProvinceRepository(TTNContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Province>> GetByCountryId(int id, CancellationToken cancellationToken)
        {
            return await Table.Where(p => p.IsActive && p.CountryId == id).ToListAsync();
        }
    }

       
}
