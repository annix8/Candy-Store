using Orders.DataModel;
using Orders.DataModel.Models;
using System.Linq;

namespace Orders.Infrastructure
{
    public class ProductRepository
    {
        public void Test()
        {
            using (var ctx = new OrdersDbContext())
            {
                ctx.Products.Add(new Product
                {
                    Name = "Test product"
                });
                
                ctx.SaveChanges();
            }
        }
    }
}
