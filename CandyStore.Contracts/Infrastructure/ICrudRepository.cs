using System;
using System.Linq;

namespace CandyStore.Contracts.Infrastructure
{
    public interface ICrudRepository<TRelatedToDbContext> : IDisposable
    {
        IQueryable<TEntity> GetAll<TEntity>() where TEntity : class, TRelatedToDbContext;
        TEntity Insert<TEntity>(TEntity entity) where TEntity : class, TRelatedToDbContext;
        void Delete<TEntity>(TEntity entity) where TEntity : class, TRelatedToDbContext;
        TEntity Update<TEntity>(TEntity entity) where TEntity : class, TRelatedToDbContext;
    }
}
