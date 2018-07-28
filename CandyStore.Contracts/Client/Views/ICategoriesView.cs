using CandyStore.Contracts.Client.Presenters;

namespace CandyStore.Contracts.Client.Views
{
    public interface ICategoriesView : IView
    {
        ICategoriesPresenter Presenter { get; set; }
    }
}
