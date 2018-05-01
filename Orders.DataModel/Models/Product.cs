using System.Collections.Generic;

namespace Orders.DataModel.Models
{
    public class Product
    {
        public Product()
        {
            Suppliers = new List<Supplier>();
            OrderDetails = new List<OrderDetails>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public virtual List<OrderDetails> OrderDetails { get; set; }
        public virtual List<Supplier> Suppliers { get; set; }
    }
}
