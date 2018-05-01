using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyStore.DataModel.Models
{
    public class Product
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
