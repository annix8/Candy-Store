using CandyStore.Contracts.Client.Views;

namespace CandyStore.Contracts.Client.Presenters
{
    public interface IReceiptPresenter : IPresenter
    {
        IReceiptView View { get; set; }
        string GetReceiptText();
    }
}
