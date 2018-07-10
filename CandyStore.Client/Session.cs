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
                if(_products == null)
                {
                    return new Dictionary<Product, int>();
                }

                return _products;
            }

            set
            {
                _products = value;
            }
        }

        public static void Clear()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Products = null;
        }
    }
}
