using IntimeVisitor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Core.DataAccess.Abstract
{
   
    public interface IRepository<TEntity, TContext> where TEntity : class, IEntity, new()
       where TContext : DbContext, new()
    {
        IQueryable<TEntity> GetAllAsQueryable(Expression<Func<TEntity, bool>> filter = null);
        IEnumerable<TEntity> GetAllAsEnumerable(Expression<Func<TEntity, bool>> filter = null);
        List<TEntity> GetAllAsList(Expression<Func<TEntity, bool>> filter = null);

        TEntity Get(Expression<Func<TEntity, bool>> filter);
        IQueryable<TEntity> GetAll();
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);
    }
}
