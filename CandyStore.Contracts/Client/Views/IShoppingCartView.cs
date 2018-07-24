using CandyStore.Contracts.Client.Presenters;

namespace CandyStore.Contracts.Client.Views
{
    public interface IShoppingCartView : IView
    {
        IShoppingCartPresenter Presenter { get; set; }
        bool ConfirmShoppingCartProductRemoval();
        void UpdateTotalPrice(double priceQuantity);
    }
}
