using Orders.DataModel;
using Orders.DataModel.Models;
using System.Collections.Generic;
using System.Linq;

namespace Orders.Infrastructure
{
    public class ProductRepository
    {
        public IEnumerable<Product> GetBySupplier(string supplierName)
        {
            using (var ctx = new OrdersDbContext())
            {
                return ctx.Suppliers
                    .FirstOrDefault(s => s.Name == supplierName)
                    .Products
                    .ToList();
            }
        }
    }
}
