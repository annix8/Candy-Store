using CandyStore.Client.Util;
using CandyStore.Contracts.Client.Presenters;
using CandyStore.Contracts.Client.Views;
using CandyStore.Contracts.Infrastructure;
using CandyStore.DataModel.CandyStoreModels;
using CandyStore.DataModel.Models;
using System.Linq;

namespace CandyStore.Client.Presenters
{
    public class HomePresenter : IHomePresenter
    {
        private readonly ICandyStoreRepository _candyStoreRepository;
        private readonly ISession _session;

        public HomePresenter(ICandyStoreRepository candyStoreRepository,
            ISession session)
        {
            _candyStoreRepository = candyStoreRepository;
            _session = session;
        }

        public IHomeView View { get; set; }

        public OperationValidationResult LoginAdministrator(string identificationNumberAsString)
        {
            var result = new OperationValidationResult
            {
                Valid = true
            };

            int identificationNumber;
            var parsed = int.TryParse(identificationNumberAsString, out identificationNumber);
            if (!parsed)
            {
                result.Valid = false;
                result.AddErrorMessage("Enter a correct whole number value.");

                return result;
            }

            var user = _candyStoreRepository.GetAll<Employee>()
                .FirstOrDefault(u => u.IdentificationNumber == identificationNumber);

            if (user == null)
            {
                result.Valid = false;
                result.AddErrorMessage("There is no such employee");
            }

            return result;
        }

        public OperationValidationResult LoginCustomer(string firstName, string lastName)
        {
            var result = new OperationValidationResult
            {
                Valid = true
            };

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                result.Valid = false;
                result.AddErrorMessage("Some of the values are empty");
                return result;
            }

            _session.Add(Constants.FIRST_NAME_KEY, firstName);
            _session.Add(Constants.LAST_NAME_KEY, lastName);
            _session.Add(Constants.SHOPPING_CART_KEY, new ShoppingCart());

            return result;
        }
    }
}
