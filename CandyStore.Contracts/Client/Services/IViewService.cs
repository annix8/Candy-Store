using CandyStore.Contracts.Client.Views;
using System.Collections.Generic;

namespace CandyStore.Contracts.Client.Services
{
    public interface IViewService
    {
        void ShowView<TView>(IView currentForm) where TView : class, IView;
        void ShowViewWithPropertyInjection<TView>(IView currentView, IDictionary<string, object> propertyValuesHash) where TView : class, IView;
        void ShowDialogView<TView>() where TView : class, IView;
        void ShowDialogViewWithPropertyInjection<TView>(IDictionary<string, object> propertyValuesHash) where TView : class, IView;
    }
}
