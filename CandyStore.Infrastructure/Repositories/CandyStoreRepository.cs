using CandyStore.Contracts.Infrastructure;
using CandyStore.DataModel.Interfaces;

namespace CandyStore.Infrastructure.Repositories
{
    public class CandyStoreRepository : CrudRepository<CandyStoreDbContext, IRelatedToCandyStoreDbContext>, ICandyStoreRepository
    {
        private readonly CandyStoreDbContext _candyStoreDbContext;

        public CandyStoreRepository(CandyStoreDbContext candyStoreDbContext)
        {
            _candyStoreDbContext = candyStoreDbContext;
        }

        protected override CandyStoreDbContext CreateDbContext()
        {
            return _candyStoreDbContext;
        }
    }
}
