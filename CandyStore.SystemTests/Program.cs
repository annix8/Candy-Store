using CandyStore.Contracts.Infrastructure;
using CandyStore.DataModel.Models;
using CandyStore.Infrastructure.Repositories;
using System;
using System.Linq;

namespace CandyStore.SystemTests
{
    class Program
    {
        static void Main(string[] args)
        {
            ICandyStoreRepository candyStoreRepository = new CandyStoreRepository();

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
    }
}
