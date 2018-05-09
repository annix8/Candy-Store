using Orders.DataModel.Enums;
using System;
using System.Collections.Generic;

namespace Orders.DataModel.Models
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new List<OrderDetails>();
        }

        public int Id { get; set; }
        public virtual Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public int SupplierId { get; set; }
        public virtual List<OrderDetails> OrderDetails { get; set; }
        public DateTime OrderedDate { get; set; }
        public DateTime ExpectedDate { get; set; }
        public OrderStatus Status { get; set; }
    }
}
