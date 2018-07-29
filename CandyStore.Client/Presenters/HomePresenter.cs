﻿using CandyStore.Client.Cache;
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

        public HomePresenter(ICandyStoreRepository candyStoreRepository)
        {
            _candyStoreRepository = candyStoreRepository;
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

            Session.Init(firstName, lastName);

            return result;
        }
    }
}
