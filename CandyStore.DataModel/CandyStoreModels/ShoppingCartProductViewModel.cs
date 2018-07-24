namespace CandyStore.DataModel.CandyStoreModels
{
    public class ShoppingCartProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string ProductCategory { get; set; }
        public int ProductQuantity { get; set; }
    }
}
