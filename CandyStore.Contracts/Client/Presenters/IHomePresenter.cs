using CandyStore.Contracts.Client.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyStore.Contracts.Client.Presenters
{
    public interface IHomePresenter
    {
        IHomeView HomeView { get; set; }
        bool LoginAdministrator(string identificationNumberAsString);
        bool LoginCustomer(string firstName, string lastName);
    }
}
