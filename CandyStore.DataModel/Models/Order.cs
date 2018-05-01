using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyStore.DataModel.Models
{
    public class Order
    {
        public Order()
        {
            this.Products = new HashSet<Product>();
        }
        public int OrderID { get; set; }
        public DateTime Date { get; set; }
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        public double TotalPrice { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
