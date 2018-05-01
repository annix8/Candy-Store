using Orders.DataModel;
using Orders.DataModel.Models;
using System.Collections.Generic;
using System.Linq;

namespace Orders.Infrastructure
{
    public class SupplierRepository
    {
        public IEnumerable<Supplier> GetAll()
        {
            using (var ctx = new OrdersDbContext())
            {
                return ctx.Suppliers.ToList();
            }
        }
    }
}
