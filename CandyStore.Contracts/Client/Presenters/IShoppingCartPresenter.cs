using CandyStore.Contracts.Client.Views;
using CandyStore.DataModel.CandyStoreModels;
using System.Collections.Generic;

namespace CandyStore.Contracts.Client.Presenters
{
    public interface IShoppingCartPresenter : IPresenter
    {
        IShoppingCartView View { get; set; }
        double GetTotalPriceOfProducts();
        IList<ShoppingCartProductViewModel> GetProductsForDisplay();
    }
}
