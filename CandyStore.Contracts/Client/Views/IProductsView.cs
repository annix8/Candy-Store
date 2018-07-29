using CandyStore.Contracts.Client.Presenters;

namespace CandyStore.Contracts.Client.Views
{
    public interface IProductsView : IView
    {
        IProductsPresenter Presenter { get; set; }
        int CategoryId { get; set; }
    }
}
