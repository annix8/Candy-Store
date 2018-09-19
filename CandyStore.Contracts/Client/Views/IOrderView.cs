using CandyStore.Contracts.Client.Presenters;

namespace CandyStore.Contracts.Client.Views
{
    public interface IOrderView : IView
    {
        IOrderPresenter Presenter { get; set; }
    }
}
