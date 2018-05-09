namespace Orders.DataModel.Models
{
    public class OrderDetails
    {
        public virtual Order Order { get; set; }
        public int OrderId { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
    }
}
