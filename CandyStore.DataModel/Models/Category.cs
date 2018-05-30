using CandyStore.DataModel.Interfaces;
using System.Collections.Generic;

namespace CandyStore.DataModel.Models
{
    public class Category : IRelatedToCandyStoreDbContext
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public byte[] CategoryImage { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
