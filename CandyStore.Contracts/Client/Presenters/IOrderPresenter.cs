using CandyStore.Contracts.Client.Views;
using CandyStore.DataModel.CandyStoreModels;
using System.Threading.Tasks;

namespace CandyStore.Contracts.Client.Presenters
{
    public interface IOrderPresenter : IPresenter
    {
        IOrderView View { get; set; }
        Task<SupplierModel[]> GetAllSuppliersAsync();
        Task<ProductModel[]> GetProductsBySupplierAsync(string name);
        Task PlaceOrder(CustomerModel customerModel, string supplierName, ProductModel[] productModels);
    }
}
