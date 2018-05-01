using Orders.DataModel.Models;
using System.Data.Entity;

namespace Orders.DataModel
{
    public class OrdersDbContext : DbContext
    {
        public OrdersDbContext()
            : base("name=OrdersDbContext")
        { }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
    }
}
