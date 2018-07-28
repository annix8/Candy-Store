using CandyStore.Contracts.Client.Views;
using CandyStore.DataModel.Models;
using System.Collections.Generic;
using System.Drawing;

namespace CandyStore.Contracts.Client.Presenters
{
    public interface ICategoriesPresenter : IPresenter
    {
        ICategoriesView View { get; set; }
        IList<Category> GetAllCategories();
        Image GetCategoryImageById(int categoryId);
        void ClearShoppingCart();
    }
}
