using CandyStore.Contracts.Client.Views;
using CandyStore.DataModel.CandyStoreModels;
using CandyStore.DataModel.Models;

namespace CandyStore.Contracts.Client.Presenters
{
    public interface IProductsPresenter : IPresenter
    {
        IProductsView View { get; set; }
        Category GetCategoryById(int categoryId);
        Product GetProductById(int productId);
        int GetProductQuantity(Product product);
        OperationValidationResult AddProductToCart(string productId, string quantity);
    }
}
