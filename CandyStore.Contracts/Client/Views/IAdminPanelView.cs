using CandyStore.Contracts.Client.Presenters;

namespace CandyStore.Contracts.Client.Views
{
    public interface IAdminPanelView : IView
    {
        IAdminPanelPresenter Presenter { get; set; }
    }
}
