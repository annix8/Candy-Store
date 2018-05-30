using CandyStore.DataModel.Interfaces;

namespace CandyStore.DataModel.Models
{
    public class Customer : IRelatedToCandyStoreDbContext
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
