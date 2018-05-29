﻿using CandyStore.DataModel;
using Unity;
using Unity.Lifetime;

namespace CandyStore.Client.Extensions
{
    public static class UnityContainerExtensions
    {
        public static UnityContainer RegisterForms(this UnityContainer container)
        {
            // register forms here...
            container.RegisterType<Main>();
            return container;
        }

        public static UnityContainer RegisterServices(this UnityContainer container)
        {
            // register services here...
            return container;
        }

        public static UnityContainer RegisterDbContext(this UnityContainer container)
        {
            container.RegisterType<CandyStoreDbContext>(new PerResolveLifetimeManager());

            return container;
        }
    }
}
