using CandyStore.Contracts.Client.Presenters;
using CandyStore.Contracts.Client.Views;

namespace CandyStore.Client.Presenters
{
    public class CategoriesPresenter : ICategoriesPresenter
    {
        public CategoriesPresenter()
        {

        }

        public ICategoriesView CategoriesView { get; set; }
    }
}
