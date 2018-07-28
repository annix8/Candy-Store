using CandyStore.DataModel.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandyStore.DataModel.Models
{
    public class OrderDetails : IRelatedToCandyStoreDbContext
    {
        [Key, Column(Order = 0)]
        public int OrderId { get; set; }
        [Key, Column(Order = 1)]
        public int ProductId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }

        public int ProductQuantity { get; set; }
    }
}
