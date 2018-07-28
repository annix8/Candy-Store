using CandyStore.Contracts.Client.Presenters;

namespace CandyStore.Contracts.Client.Views
{
    public interface IReceiptView : IView
    {
        IReceiptPresenter Presenter { get; set; }
        int OrderId { get; set; }
    }
}
