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
            return await Table.Where(p =>p.IsActive && p.UserId == Id ).Include(x=>x.Menu).ToListAsync();
        }

        public async Task<List<UserMenu>> GetMenu(long modelId)
        {
            try
            {
                return await Table.Where(p => p.IsActive && p.UserId == modelId).Include(x => x.Menu).ToListAsync();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
