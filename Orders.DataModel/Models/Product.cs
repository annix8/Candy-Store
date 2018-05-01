using System.Collections.Generic;

namespace Orders.DataModel.Models
{
    public class Product
    {
        public Product()
        {
            Suppliers = new HashSet<Supplier>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Supplier> Suppliers { get; set; }
    }
}
