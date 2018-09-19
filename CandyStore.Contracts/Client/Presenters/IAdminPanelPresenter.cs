using CandyStore.Contracts.Client.Views;
using CandyStore.DataModel.CandyStoreModels;
using CandyStore.DataModel.Models;
using System.Collections.Generic;

namespace CandyStore.Contracts.Client.Presenters
{
    public interface IAdminPanelPresenter : IPresenter
    {
        IAdminPanelView View { get; set; }
        OperationValidationResult AddNewCategory(string name, byte[] image);
        OperationValidationResult DeleteCategory(string categoryName);
        OperationValidationResult AddNewProduct(string productPrice, string productName, string categoryName, byte[] image);
        OperationValidationResult DeleteProduct(string productName);
        OperationValidationResult SaveProductQuantity(string productName, string productQuantityString);
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Category> GetAllCategories();
    }
}
