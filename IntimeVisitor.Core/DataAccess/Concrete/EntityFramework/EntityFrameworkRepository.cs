using IntimeVisitor.Core.DataAccess.Abstract;
using IntimeVisitor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Core.DataAccess.Concrete.EntityFramework
{
    public class EntityFrameworkRepository<TEntity, TContext> : IRepository<TEntity, TContext> where TEntity : class, IEntity, new()
         where TContext : DbContext, new()
    {
        TContext context = new TContext();
        //TODO: context.savechanges save methodunda çağırılacak
        public TEntity Add(TEntity entity)
        {

            var reference = context.Entry(entity);
            reference.State = EntityState.Added;
            context.SaveChanges();
            return entity;

        }

        public TEntity Delete(TEntity entity)
        {

            var reference = context.Entry(entity);
            reference.State = EntityState.Deleted;
            context.SaveChanges();
            return entity;

        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {

            return context.Set<TEntity>().Where(filter).FirstOrDefault();

        }

        public IQueryable<TEntity> GetAllAsQueryable(Expression<Func<TEntity, bool>> filter = null)
        {

            return filter != null ? context.Set<TEntity>().Where(filter) : context.Set<TEntity>();

        }
        public IEnumerable<TEntity> GetAllAsEnumerable(Expression<Func<TEntity, bool>> filter = null)
        {
            //using (TContext context = new TContext())

            return filter != null ? context.Set<TEntity>().Where(filter).AsEnumerable() : context.Set<TEntity>().AsEnumerable();

        }


        public List<TEntity> GetAllAsList(Expression<Func<TEntity, bool>> filter = null)
        {
            //using (TContext context = new TContext())

            return filter != null ? context.Set<TEntity>().Where(filter).ToList() : context.Set<TEntity>().ToList();

        }


        public TEntity Update(TEntity entity)
        {


            var reference = context.Entry(entity);
            reference.State = EntityState.Modified;
            context.SaveChanges();
            return entity;

        }

        public IQueryable<TEntity> GetAll()
        {
            return context.Set<TEntity>();
        }
    }
}
