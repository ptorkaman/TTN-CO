using Common.Extensions;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Repository
{
    public class UserMenuRepository : Repository<UserMenu>, IUserMenuRepository
    {


        public UserMenuRepository(TTNContext dbContext) : base(dbContext)
        {
        
        }

       

        public async Task<List<UserMenu>> GetByUserId(long Id)
        {  
            return await Table.Where(p =>p.IsActive && p.UserId == Id ).ToListAsync();
        }
    }
}
