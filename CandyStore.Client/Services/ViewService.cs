using CandyStore.Contracts.Client.Services;
using CandyStore.Contracts.Client.Views;
using SimpleInjector;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CandyStore.Client.Services
{
    public class ViewService : IViewService
    {
        private readonly Container _container;

        public ViewService(Container container)
        {
            _container = container;
        }

        // TODO: Mario(18.July.2018) - Make the currentForm variable to be an IView interface
        public void ShowView<TView>(Form currentForm) where TView : class, IView
        {
            var view = _container.GetInstance<TView>() as Form;
            view.FormClosed += new FormClosedEventHandler((sender, args) => currentForm.Close());
            currentForm.Hide();
            view.Show();
        }
        
        public void ShowDialogView<TView>() where TView : class, IView
        {
            var view = _container.GetInstance<TView>() as Form;
            view.ShowDialog();
        }

        public void ShowDialogViewWithPropertyInjection<TView>(Dictionary<string, object> propertyValuesHash) where TView : class, IView
        {
            var view = _container.GetInstance<TView>() as Form;

            foreach (var item in propertyValuesHash)
            {
                var propertyInfo = view.GetType().GetProperty(item.Key);
                propertyInfo.SetValue(view, item.Value);
            }

            view.ShowDialog();
        }
    }
}
