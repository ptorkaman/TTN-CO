using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DAL.Models;

namespace Repository
{
    public class CityRepository : Repository<City>, ICityRepository
    {


        public CityRepository(TTNContext dbContext) : base(dbContext)
        {

        }

        public Task<List<City>> GetByCityId(int id, CancellationToken cancellationToken)
        {
            return Table.Where(x => x.IsActive && x.ProvinceId == id).ToListAsync();

        }
    }
}
