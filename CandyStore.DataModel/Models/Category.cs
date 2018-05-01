using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyStore.DataModel.Models
{
    public class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public byte[] CategoryImage { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
