using CandyStore.Client.Facades;
using CandyStore.Client.Presenters;
using CandyStore.Client.Services;
using CandyStore.Client.Views;
using CandyStore.Contracts.Client.Facades;
using CandyStore.Contracts.Client.Presenters;
using CandyStore.Contracts.Client.Services;
using CandyStore.Contracts.Client.Views;
using CandyStore.Contracts.Infrastructure;
using CandyStore.Contracts.Infrastructure.Utilities;
using CandyStore.Infrastructure;
using CandyStore.Infrastructure.Repositories;
using CandyStore.Infrastructure.Utilities;
using SimpleInjector;

namespace CandyStore.Client.Extensions
{
    public static class SimpleInjectorExtensions
    {
        public static Container RegisterViews(this Container container)
        {
            container.Register<IHomeView, HomeView>(Lifestyle.Scoped);
            container.Register<ICategoriesView, CategoriesView>(Lifestyle.Scoped);
            container.Register<IProductsView, ProductsView>(Lifestyle.Scoped);
            container.Register<IReceiptView, ReceiptView>(Lifestyle.Scoped);
            container.Register<IShoppingCartView, ShoppingCartView>(Lifestyle.Scoped);

            container.Register<IOrderView, OrderView>(Lifestyle.Scoped);
            container.Register<IOrderStatusView, OrderStatusView>(Lifestyle.Scoped);

            container.Register<IAdminManagerView, AdminManagerView>(Lifestyle.Scoped);
            container.Register<IAdminPanelView, AdminPanelView>(Lifestyle.Scoped);

            return container;
        }

        public static Container RegisterPresenters(this Container container)
        {
            container.Register<IHomePresenter, HomePresenter>(Lifestyle.Scoped);
            container.Register<ICategoriesPresenter, CategoriesPresenter>(Lifestyle.Scoped);
            container.Register<IShoppingCartPresenter, ShoppingCartPresenter>(Lifestyle.Scoped);
            container.Register<IReceiptPresenter, ReceiptPresenter>(Lifestyle.Scoped);

            return container;
        }

        public static Container RegisterInfrastructure(this Container container)
        {
            container.Register<CandyStoreDbContext>(Lifestyle.Scoped);

            container.Register<ICandyStoreRepository, CandyStoreRepository>(Lifestyle.Scoped);

            container.Register<IImageUtil, ImageUtil>(Lifestyle.Scoped);

            return container;
        }

        public static Container RegisterServices(this Container container)
        {
            container.Register<IViewService, ViewService>(Lifestyle.Scoped);

            container.Register<IDateTimeFacade, DateTimeFacade>(Lifestyle.Singleton);
            container.Register<IStringBuilderFacade, StringBuilderFacade>(Lifestyle.Singleton);

            return container;
        }
    }
}
