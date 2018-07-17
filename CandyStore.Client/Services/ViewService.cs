using System.Windows.Forms;
using CandyStore.Contracts.Client.Services;
using CandyStore.Contracts.Client.Views;
using CandyStore.Client.Util;
using SimpleInjector;

namespace CandyStore.Client.Services
{
    public class ViewService : IViewService
    {
        private readonly Container _container;

        public ViewService(Container container)
        {
            _container = container;
        }
        public void ShowView<TView>(Form currentForm) where TView : class, IView
        {
            var view = _container.GetInstance<TView>() as Form;
            view.FormClosed += new FormClosedEventHandler((sender, args) => currentForm.Close());
            view.Show();
            currentForm.Hide();
        }
    }
}
