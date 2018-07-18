using CandyStore.Contracts.Client.Views;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CandyStore.Contracts.Client.Services
{
    public interface IViewService
    {
        void ShowView<TView>(Form currentForm) where TView : class, IView;
        void ShowDialogView<TView>() where TView : class, IView;
        void ShowDialogViewWithPropertyInjection<TView>(Dictionary<string, object> propertyValuesHash) where TView : class, IView;
    }
}
