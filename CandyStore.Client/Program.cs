using CandyStore.Client.Extensions;
using CandyStore.Client.Views;
using CandyStore.Contracts.Client.Presenters;
using CandyStore.Contracts.Client.Views;
using SimpleInjector;
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

            var container = BuildContainer();

            using (ThreadScopedLifestyle.BeginScope(container))
            {
                Application.Run((HomeView)container.GetInstance<IHomeView>());
            }
        }

        private static Container BuildContainer()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();

            container
                .RegisterViews()
                .RegisterPresenters()
                .RegisterInfrastructure()
                .RegisterServices()
                .Verify();

            return container;
        }
    }
}
