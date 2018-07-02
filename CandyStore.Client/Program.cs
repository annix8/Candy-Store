using CandyStore.Client.Extensions;
using CandyStore.Client.Presenters;
using CandyStore.Client.UnityIoC;
using CandyStore.Client.Views;
using CandyStore.Infrastructure.Repositories;
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
            var container = SingletonUnity.Instance
                .RegisterForms()
                .RegisterServices()
                .RegisterDbContext();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // TODO: implement IoC
            // note that using Unity must be included for generic container.Resolve to work

            var homeView = new HomeView();
            var homePresenter = new HomePresenter(homeView, new CandyStoreRepository());
            Application.Run(homeView);
        }
    }
}
