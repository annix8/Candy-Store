using CandyStore.Contracts.Client.Views;
using CandyStore.DataModel.CandyStoreModels;

namespace CandyStore.Contracts.Client.Presenters
{
    public interface IHomePresenter : IPresenter
    {
        IHomeView HomeView { get; set; }
        DataValidationResult LoginAdministrator(string identificationNumberAsString);
        DataValidationResult LoginCustomer(string firstName, string lastName);
    }
}
