﻿using CandyStore.DataModel.Interfaces;
using System;
using System.Collections.Generic;

namespace CandyStore.DataModel.Models
{
    public class Order : IRelatedToCandyStoreDbContext
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }
        public int OrderID { get; set; }
        public DateTime Date { get; set; }
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        public double TotalPrice { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
