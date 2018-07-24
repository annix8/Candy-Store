using CandyStore.Contracts.Infrastructure;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CandyStore.Infrastructure.Repositories
{
    public abstract class CrudRepository<TContext, TRelatedToDbContext> : ICrudRepository<TRelatedToDbContext>
        where TContext : DbContext
    {
        private TContext _context;
        private TContext Context
        {
            get
            {
                if (_context == null)
                {
                    _context = CreateDbContext();
                }

                return _context;
            }
        }

        public void Dispose() => Context.Dispose();

        public IQueryable<TEntity> GetAll<TEntity>()
            where TEntity : class, TRelatedToDbContext
        {
            return Context.Set<TEntity>();
        }

        public TEntity Insert<TEntity>(TEntity entity)
            where TEntity : class, TRelatedToDbContext
        {
            Context.Set<TEntity>().Add(entity);
            Save();
            return entity;
        }

        public void Delete<TEntity>(TEntity entity)
            where TEntity : class, TRelatedToDbContext
        {
            Context.Set<TEntity>().Remove(entity);
            Save();
        }

        public TEntity Update<TEntity>(TEntity entity)
            where TEntity : class, TRelatedToDbContext
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            Save();
            return entity;
        }

        public IEnumerable<TEntity> UpdateRange<TEntity>(IEnumerable<TEntity> entitiesToBeUpdated)
            where TEntity : class, TRelatedToDbContext
        {
            foreach (var entity in entitiesToBeUpdated)
            {
                Update(entity);
            }

            return entitiesToBeUpdated;
        }

        protected abstract TContext CreateDbContext();

        private void Save()
        {
            Context.SaveChanges();
        }
    }
}
