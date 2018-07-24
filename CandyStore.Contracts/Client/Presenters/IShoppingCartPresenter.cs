using CandyStore.Contracts.Client.Views;
using CandyStore.DataModel.CandyStoreModels;
using CandyStore.DataModel.Models;
using System.Collections.Generic;

namespace CandyStore.Contracts.Client.Presenters
{
    public interface IShoppingCartPresenter : IPresenter
    {
        IShoppingCartView View { get; set; }
        double GetTotalPriceOfProducts();
        IList<ShoppingCartProductViewModel> GetProductsForDisplay();
        Order CreateOrder();
        OperationValidationResult PerformProdcutQuantityChange(int productId, string operation);
        void UpdateProductQuantityInCart(int productId, int quantity);
    }
}
