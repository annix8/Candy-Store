namespace CandyStore.DataModel
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

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
    }
}