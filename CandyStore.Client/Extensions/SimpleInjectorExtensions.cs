using CandyStore.Client.Presenters;
using CandyStore.Client.Services;
using CandyStore.Client.Views;
using CandyStore.Contracts.Client.Presenters;
using CandyStore.Contracts.Client.Services;
using CandyStore.Contracts.Client.Views;
using CandyStore.Contracts.Infrastructure;
using CandyStore.Infrastructure;
using CandyStore.Infrastructure.Repositories;
using SimpleInjector;

namespace CandyStore.Client.Extensions
{
    public static class SimpleInjectorExtensions
    {
        public static Container RegisterViews(this Container container)
        {
            container.Register<IHomeView, HomeView>(Lifestyle.Scoped);
            container.Register<IAdminManagerView, AdminManagerView>(Lifestyle.Scoped);
            container.Register<ICategoriesView, CategoriesView>(Lifestyle.Scoped);

            return container;
        }

        public static Container RegisterPresenters(this Container container)
        {
            container.Register<IHomePresenter, HomePresenter>(Lifestyle.Scoped);

            return container;
        }

        public static Container RegisterInfrastructure(this Container container)
        {
            container.Register<CandyStoreDbContext>(Lifestyle.Scoped);

            container.Register<ICandyStoreRepository, CandyStoreRepository>(Lifestyle.Scoped);

            return container;
        }

        public static Container RegisterServices(this Container container)
        {
            container.Register<IViewService, ViewService>(Lifestyle.Scoped);

            return container;
        }
    }
}
