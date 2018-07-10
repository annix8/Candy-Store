using CandyStore.Client.Cache;
using CandyStore.Contracts.Client.Presenters;
using CandyStore.Contracts.Client.Views;
using CandyStore.Contracts.Infrastructure;
using CandyStore.DataModel.CandyStoreModels;
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

        public DataValidationResult LoginAdministrator(string identificationNumberAsString)
        {
            var result = new DataValidationResult
            {
                Valid = true
            };

            int identificationNumber;
            var parsed = int.TryParse(identificationNumberAsString, out identificationNumber);
            if (!parsed)
            {
                result.Valid = false;
                result.ErrorMessages.Add("Enter a correct whole number value.");

                return result;
            }

            var user = _candyStoreRepository.GetAll<Employee>()
                .FirstOrDefault(u => u.IdentificationNumber == identificationNumber);

            if (user == null)
            {
                result.Valid = false;
                result.ErrorMessages.Add("There is no such employee");
            }

            return result;
        }

        public DataValidationResult LoginCustomer(string firstName, string lastName)
        {
            var result = new DataValidationResult
            {
                Valid = true
            };

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                result.Valid = false;
                result.ErrorMessages.Add("Some of the values are empty");
                return result;
            }

            Session.FirstName = firstName;
            Session.LastName = lastName;
            Session.Products = new Dictionary<Product, int>();

            return result;
        }
    }
}
