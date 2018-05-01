using System.Collections.Generic;

namespace Orders.DataModel.Models
{
    public class Customer
    {
        public Customer()
        {
            Orders = new List<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string IdentificationNumber { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
