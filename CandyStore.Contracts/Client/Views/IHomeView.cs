using CandyStore.Contracts.Client.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyStore.Contracts.Client.Views
{
    public interface IHomeView : IView
    {
        IHomePresenter Presenter { get; set; }
    }
}
