using CandyStore.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyStore.Client.Cache
{
    public static class Session
    {
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static Dictionary<Product, int> Products { get; set; }

        public static void Clear()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Products = null;
        }
    }
}
