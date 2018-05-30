using CandyStore.DataModel.Interfaces;
using System.Collections.Generic;

namespace CandyStore.DataModel.Models
{
    public class Product : IRelatedToCandyStoreDbContext
    {
        public Product()
        {
            this.Orders = new HashSet<Order>();
        }
        public int ProductID { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public byte[] ProductImage { get; set; }
    }
}
