using CandyStore.Contracts.Client.Views;
using CandyStore.DataModel.Models;
using System.Collections.Generic;
using System.Drawing;

namespace CandyStore.Contracts.Client.Presenters
{
    public interface ICategoriesPresenter
    {
        ICategoriesView CategoriesView { get; set; }
        IList<Category> GetAllCategories();
        Image GetCategoryImageById(int categoryId);
    }
}
