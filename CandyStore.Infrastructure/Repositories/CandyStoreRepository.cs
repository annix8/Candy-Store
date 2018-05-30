using CandyStore.Contracts.Infrastructure;

namespace CandyStore.Infrastructure.Repositories
{
    public class CandyStoreRepository : CrudRepository<CandyStoreDbContext>, ICandyStoreRepository
    {
        protected override CandyStoreDbContext CreateDbContext()
        {
            return new CandyStoreDbContext();
        }
    }
}
