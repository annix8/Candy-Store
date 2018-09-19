using AutoMapper;
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

        public async Task<SupplierModel[]> GetAllSuppliersAsync()
        {
            var suppliersResponse = await _orderService.GetAllSuppliersAsync();
            var suppliers = suppliersResponse.Body.GetAllSuppliersResult;

            return Mapper.Map<SupplierModel[]>(suppliers);
        }

        public async Task<ProductModel[]> GetProductsBySupplierAsync(string name)
        {
            var suppliersProductsResponse = await _orderService.GetProductsBySupplierAsync(name);
            var suppliersProducts = suppliersProductsResponse.Body.GetProductsBySupplierResult;

            return Mapper.Map<ProductModel[]>(suppliersProducts);
        }
    }
}
