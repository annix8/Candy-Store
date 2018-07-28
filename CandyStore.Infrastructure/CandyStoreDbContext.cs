using CandyStore.DataModel.Models;
using System.Data.Entity;

namespace CandyStore.Infrastructure
{
    public class CandyStoreDbContext : DbContext
    {
        public CandyStoreDbContext()
            : base("name=CandyStoreDbContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
    }
}