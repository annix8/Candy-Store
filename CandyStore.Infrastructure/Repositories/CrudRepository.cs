using System.Data.Entity;
using System.Linq;

namespace CandyStore.Infrastructure.Repositories
{
    public abstract class CrudRepository<TContext>
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

        public IQueryable<TEntity> GetAll<TEntity>()
            where TEntity : class
        {
            return Context.Set<TEntity>();
        }

        public TEntity Insert<TEntity>(TEntity entity)
            where TEntity : class
        {
            Context.Set<TEntity>().Add(entity);
            Save();
            return entity;
        }

        public void Delete<TEntity>(TEntity entity)
            where TEntity : class
        {
            Context.Set<TEntity>().Remove(entity);
            Save();
        }

        public TEntity Update<TEntity>(TEntity entity)
            where TEntity : class
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            Save();
            return entity;
        }

        private void Save()
        {
            Context.SaveChanges();
        }

        protected abstract TContext CreateDbContext();
    }
}
