using Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Repository
{
    public interface IUserMenuRepository : IRepository<UserMenu>
    {
        Task<List<UserMenu>> GetByUserId(long Id);
 
    }
}