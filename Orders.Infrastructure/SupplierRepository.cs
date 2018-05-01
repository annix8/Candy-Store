using Orders.DataModel;
using Orders.Infrastructure.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Orders.Infrastructure
{
    public class SupplierRepository
    {
        public IEnumerable<SupplierDto> GetAll()
        {
            using (var ctx = new OrdersDbContext())
            {
                var suppliers = ctx.Suppliers
                    .Select(s => new SupplierDto
                    {
                        Address = s.Address,
                        Name = s.Name,
                        PhoneNumber = s.PhoneNumber,
                        Products = s.Products.Select(p => new ProductDto
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Price = p.Price
                        }).ToList()
                    }).ToList();

                return suppliers;
            }
        }
    }
}
