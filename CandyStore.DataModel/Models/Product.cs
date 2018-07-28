using CandyStore.DataModel.Interfaces;
using System;
using System.Collections.Generic;

namespace CandyStore.DataModel.Models
{
    public class Product : IEquatable<Product>, IRelatedToCandyStoreDbContext
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int ProductID { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public byte[] ProductImage { get; set; }

        public bool Equals(Product other)
        {
            return ProductID.Equals(other.ProductID);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Product);
        }

        public override int GetHashCode()
        {
            return ProductID.GetHashCode();
        }
    }
}
