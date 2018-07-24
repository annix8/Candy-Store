using CandyStore.Contracts.Client.Views;
using CandyStore.DataModel.CandyStoreModels;

namespace CandyStore.Contracts.Client.Presenters
{
    public interface IHomePresenter : IPresenter
    {
        IHomeView HomeView { get; set; }
        OperationValidationResult LoginAdministrator(string identificationNumberAsString);
        OperationValidationResult LoginCustomer(string firstName, string lastName);
    }
}
