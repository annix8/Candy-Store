using CandyStore.Contracts.Infrastructure;
using CandyStore.DataModel.Models;
using CandyStore.Infrastructure.Repositories;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CandyStore.SystemTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestRepo();

            TestScope();
        }

        private static void TestRepo()
        {
            ICandyStoreRepository candyStoreRepository = new CandyStoreRepository(new Infrastructure.CandyStoreDbContext());

            using (candyStoreRepository)
            {
                var categories = candyStoreRepository.GetAll<Category>()
                   .ToList();

                Console.WriteLine(string.Join(", ", categories.Select(x => x.Name)));

                var customers = candyStoreRepository.GetAll<Customer>()
                    .ToList();

                Console.WriteLine(string.Join(", ", customers.Select(x => $"{x.FirstName} {x.LastName}")));
            }
        }

        private static void TestScope()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();

            container.Register<Test>(Lifestyle.Scoped);

            using (var scope = ThreadScopedLifestyle.BeginScope(container))
            {
                scope.Container.GetInstance<Test>().Number = 5;

                var test = scope.Container.GetInstance<Test>();
                Console.WriteLine(test.Number);
            }

            using (var scope = ThreadScopedLifestyle.BeginScope(container))
            {
                var test = scope.Container.GetInstance<Test>();
                Console.WriteLine(test.Number);
            }
        }

        public class Test
        {
            public int Number { get; set; }
        }
    }
}
