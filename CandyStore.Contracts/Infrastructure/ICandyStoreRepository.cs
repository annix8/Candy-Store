using CandyStore.DataModel.Interfaces;

namespace CandyStore.Contracts.Infrastructure
{
    public interface ICandyStoreRepository : ICrudRepository<IRelatedToCandyStoreDbContext>
    {
    }
}
