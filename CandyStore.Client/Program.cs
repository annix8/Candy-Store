using CandyStore.Client.Extensions;
using CandyStore.Client.Util;
using CandyStore.Client.Views;
using CandyStore.Contracts.Client.Presenters;
using SimpleInjector.Lifestyles;
using System;
using System.Windows.Forms;

namespace CandyStore.Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Bootstrap();

            using (ThreadScopedLifestyle.BeginScope(SimpleInjectorContainer.Instance))
            {
                var homePresenter = SimpleInjectorContainer.Instance.GetInstance<IHomePresenter>();
                Application.Run((HomeView)homePresenter.HomeView);
            }
        }

        private static void Bootstrap()
        {
            SimpleInjectorContainer.Instance
                .RegisterForms()
                .RegisterPresenters()
                .RegisterDbContext()
                .RegisterRepositories()
                .Verify();
        }
    }
}
