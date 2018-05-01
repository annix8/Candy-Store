using Orders.DataModel;
using Orders.Infrastructure.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Orders.Infrastructure
{
    public class ProductRepository
    {
        public IEnumerable<ProductDto> GetBySupplier(string supplierName)
        {
            using (var ctx = new OrdersDbContext())
            {
                var products = ctx.Suppliers
                    .FirstOrDefault(s => s.Name == supplierName)
                    .Products
                    .Select(p => new ProductDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price
                    });

                return products;
            }
        }
    }
}
