using System.Collections.Generic;

namespace Orders.DataModel.Models
{
    public class Supplier
    {
        public Supplier()
        {
            Products = new List<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
