using CandyStore.Contracts.Client.Views;
using CandyStore.DataModel.CandyStoreModels;
using CandyStore.DataModel.Models;
using System.Collections.Generic;

namespace CandyStore.Contracts.Client.Presenters
{
    public interface IAdminPanelPresenter
    {
        IAdminPanelView View { get; set; }
        OperationValidationResult AddNewCategory(string name, byte[] image);
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Category> GetAllCategories();
    }
}
