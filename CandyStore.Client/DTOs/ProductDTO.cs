using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyStore.Client.DTOs
{
    public class ProductDTO
    {
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string ProductCategory { get; set; }
        public int ProductQuantity { get; set; }
    }
}
