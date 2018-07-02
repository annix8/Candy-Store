using CandyStore.Client.Cache;
using CandyStore.Client.Messages;
using CandyStore.Contracts.Client.Presenters;
using CandyStore.Contracts.Client.Views;
using CandyStore.Contracts.Infrastructure;
using CandyStore.DataModel.Models;
using System.Collections.Generic;
using System.Linq;

namespace CandyStore.Client.Presenters
{
    public class HomePresenter : IHomePresenter
    {
        private readonly ICandyStoreRepository _candyStoreRepository;

        public HomePresenter(IHomeView homeView, ICandyStoreRepository candyStoreRepository)
        {
            HomeView = homeView;
            HomeView.Presenter = this;

            _candyStoreRepository = candyStoreRepository;
        }

        public IHomeView HomeView { get; set; }

        public bool LoginAdministrator(string identificationNumberAsString)
        {
            int identificationNumber;
            var parsed = int.TryParse(identificationNumberAsString, out identificationNumber);
            if (!parsed)
            {
                MessageForm.ShowError("Enter a correct whole number value.");
                return false;
            }

            var user = _candyStoreRepository.GetAll<Employee>()
                .FirstOrDefault(u => u.IdentificationNumber == identificationNumber);

            if (user == null)
            {
                MessageForm.ShowError("There is no such employee");
                return false;
            }

            HomeView.ClearTextBoxes();

            return true;
        }

        public bool LoginCustomer(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                MessageForm.ShowError("Some of the values are empty");
                return false;
            }

            Session.FirstName = firstName;
            Session.LastName = lastName;
            Session.Products = new Dictionary<Product, int>();

            HomeView.ClearTextBoxes();

            return true;
        }
    }
}
