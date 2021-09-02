using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DAL.Models;

namespace Repository
{
    public class PackageTypeRepository : Repository<PackageType>, IPackageTypeRepository
    {


        public PackageTypeRepository(TTNContext dbContext) : base(dbContext)
        {

        }

        
    }
}
