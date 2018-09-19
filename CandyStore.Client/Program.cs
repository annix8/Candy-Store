using AutoMapper;
using CandyStore.Client.Extensions;
using CandyStore.Client.Messages;
using CandyStore.Client.OrderServiceProxy;
using CandyStore.Client.Views;
using CandyStore.Contracts.Client.Views;
using CandyStore.Contracts.ExceptionLogging;
using CandyStore.DataModel.CandyStoreModels;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Threading;
using System.Windows.Forms;

namespace CandyStore.Client
{
    static class Program
    {
        private static Container _container;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += ApplicationOnThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BuildContainer();
            ConfigureAutoMapper();

            using (ThreadScopedLifestyle.BeginScope(_container))
            {
                Application.Run((HomeView)_container.GetInstance<IHomeView>());
            }
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            NotifyOnException((Exception)e.ExceptionObject);
        }

        private static void ApplicationOnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            NotifyOnException(e.Exception);
        }

        private static void NotifyOnException(Exception e)
        {
            var exceptionLogger = _container.GetInstance<IExceptionLogger>();
            exceptionLogger.Log(e);

            NotifyMessageBox.ShowError($"Something went wrong.\r\n{e.Message}");
        }

        private static void BuildContainer()
        {
            _container = new Container();
            _container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();

            _container
                .RegisterViews()
                .RegisterPresenters()
                .RegisterInfrastructure()
                .RegisterServices()
                .Verify();
        }

        private static void ConfigureAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                // two way mapping
                cfg.CreateMap<SupplierModel, SupplierDto>();
                cfg.CreateMap<SupplierDto, SupplierModel>();

                cfg.CreateMap<ProductModel, ProductDto>();
                cfg.CreateMap<ProductDto, ProductModel>();

                cfg.CreateMap<CustomerModel, CustomerDto>();
                cfg.CreateMap<CustomerDto, CustomerModel>();
            });
        }
    }
}
