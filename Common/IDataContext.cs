using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IDataContext : IDisposable
    {

        //string GetTableName<T>() where T : class;

        ////TEntity Add<TEntity>(TEntity entity) where TEntity : class;

        //TEntity Edit<TEntity>(TEntity entity, List<string> navigationPropertiesMustbeUpdate, List<string> constantFields) where TEntity : class;

        //void Remove<TEntity>(TEntity entity) where TEntity : class;
        //IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters)
        //    where TEntity : class, new();
        //void RemoveBatch<TEntity>(TEntity entity, Expression<Func<TEntity, bool>> filter = null) where TEntity : class;

        //IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters);

        //long ExecuteSqlCommand(string sqlCommand, string taleName);
    }
}
