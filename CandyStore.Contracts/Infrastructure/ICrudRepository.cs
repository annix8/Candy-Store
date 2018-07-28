using System;
using System.Collections.Generic;
using System.Linq;

namespace CandyStore.Contracts.Infrastructure
{
    public interface ICrudRepository<TRelatedToDbContext> : IDisposable
    {
        IQueryable<TEntity> GetAll<TEntity>() where TEntity : class, TRelatedToDbContext;
        TEntity Insert<TEntity>(TEntity entity) where TEntity : class, TRelatedToDbContext;
        void InsertRange<TEntity>(IEnumerable<TEntity> entitiesToBeInserted) where TEntity : class, TRelatedToDbContext;
        void Delete<TEntity>(TEntity entity) where TEntity : class, TRelatedToDbContext;
        TEntity Update<TEntity>(TEntity entity) where TEntity : class, TRelatedToDbContext;
        IEnumerable<TEntity> UpdateRange<TEntity>(IEnumerable<TEntity> entitiesToBeUpdated) where TEntity : class, TRelatedToDbContext;
    }
}
