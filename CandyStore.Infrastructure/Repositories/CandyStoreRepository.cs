using CandyStore.Contracts.Infrastructure;
using CandyStore.DataModel.Interfaces;

namespace CandyStore.Infrastructure.Repositories
{
    public class CandyStoreRepository : CrudRepository<CandyStoreDbContext, IRelatedToCandyStoreDbContext>, ICandyStoreRepository
    {
        protected override CandyStoreDbContext CreateDbContext()
        {
            return new CandyStoreDbContext();
        }
    }
}
