using CandyStore.DataModel.Models;
using System.Collections.Generic;

namespace CandyStore.Client.Cache
{
    public static class Session
    {
        private static Dictionary<Product, int> _products;

        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static Dictionary<Product, int> Products
        {
            get
            {
                if (_products == null)
                {
                    return new Dictionary<Product, int>();
                }

                return _products;
            }

            private set
            {
                _products = value;
            }
        }

        public static int GetProductCount(Product product)
        {
            if (Products.ContainsKey(product))
            {
                return Products[product];
            }

            return 0;
        }

        public static void AddQuantityToProduct(Product product, int quantity)
        {
            if (!Products.ContainsKey(product))
            {
                Products.Add(product, 0);
            }

            Products[product] += quantity;
        }

        public static void Clear()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Products.Clear();
        }
    }
}
