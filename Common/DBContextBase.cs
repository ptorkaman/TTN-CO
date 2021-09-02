using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TTN;

namespace Common
{
    public class DBContextBase : System.Data.Entity.DbContext, IUnitOfWork, IDataContext
    {
        public DBContextBase(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
           // this.Configuration.LazyLoadingEnabled = false;
        }
        //public IDbSet<TEntiy> Entities<TEntiy>() where TEntiy : class
        //{
        //    return this.Set<TEntiy>();
        //}
        //public TEntity Add<TEntity>(TEntity entity) where TEntity : class
        //{
        //    var obj = this.Entities<TEntity>().Add(entity);

        //    return obj;

        //}

      
        public void Commit()
        {

        }

        
    }

}
