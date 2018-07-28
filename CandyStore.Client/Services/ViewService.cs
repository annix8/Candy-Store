using CandyStore.Contracts.Client.Services;
using CandyStore.Contracts.Client.Views;
using SimpleInjector;
using System;
using System.Collections.Generic;

namespace CandyStore.Client.Services
{
    public class ViewService : IViewService
    {
        private readonly Container _container;

        public ViewService(Container container)
        {
            _container = container;
        }

        public void ShowView<TView>(IView currentView) where TView : class, IView
        {
            var view = _container.GetInstance<TView>();
            view.ViewClosed += new EventHandler((sender, args) => currentView.Close());
            currentView.Hide();
            view.Show();
        }

        public void ShowViewWithPropertyInjection<TView>(IView currentView, IDictionary<string, object> propertyValuesHash) where TView : class, IView
        {
            var view = _container.GetInstance<TView>();

            foreach (var item in propertyValuesHash)
            {
                var propertyInfo = view.GetType().GetProperty(item.Key);
                propertyInfo.SetValue(view, item.Value);
            }

            view.ViewClosed += new EventHandler((sender, args) => currentView.Close());
            currentView.Hide();
            view.Show();
        }

        public void ShowDialogView<TView>() where TView : class, IView
        {
            var view = _container.GetInstance<TView>();
            view.ShowDialog();
        }

        public void ShowDialogViewWithPropertyInjection<TView>(IDictionary<string, object> propertyValuesHash) where TView : class, IView
        {
            var view = _container.GetInstance<TView>();

            foreach (var item in propertyValuesHash)
            {
                var propertyInfo = view.GetType().GetProperty(item.Key);
                propertyInfo.SetValue(view, item.Value);
            }

            view.ShowDialog();
        }
    }
}
