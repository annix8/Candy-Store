using System.Linq;

namespace CandyStore.Contracts.Infrastructure
{
    public interface ICrudRepository
    {
        IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;
        TEntity Insert<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        TEntity Update<TEntity>(TEntity entity) where TEntity : class;
    }
}
