using CandyStore.Client.OrderServiceProxy;
using CandyStore.Contracts.Client.Presenters;
using CandyStore.Contracts.Client.Views;
using CandyStore.DataModel.CandyStoreModels;
using System.Linq;
using System.Threading.Tasks;

namespace CandyStore.Client.Presenters
{
    public class OrderPresenter : IOrderPresenter
    {
        private readonly OrderServiceSoapClient _orderService;

        public OrderPresenter()
        {
            _orderService = new OrderServiceSoapClient();
        }

        public IOrderView View { get; set; }

        public async Task<SupplierModel[]> GetAllSuppliers()
        {
            var suppliersResponse = await _orderService.GetAllSuppliersAsync();
            var suppliers = suppliersResponse.Body.GetAllSuppliersResult;

            return suppliers.Select(s => new SupplierModel
            {
                Address = s.Address,
                Name = s.Name,
                PhoneNumber = s.PhoneNumber,
                Products = s.Products.Select(p => new ProductModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity
                }).ToArray()
            }).ToArray();
        }
    }
}
