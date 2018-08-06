using CandyStore.DataModel.Models;
using System.Collections.Generic;

namespace CandyStore.Client.Util
{
    public class ShoppingCart
    {
        private readonly IDictionary<Product, int> _products;

        public ShoppingCart()
        {
            _products = new Dictionary<Product, int>();
        }

        public int GetProductQuantity(Product product)
        {
            if (_products.ContainsKey(product))
            {
                return _products[product];
            }

            return 0;
        }

        public void AddQuantityToProduct(Product product, int quantity)
        {
            if (!_products.ContainsKey(product))
            {
                _products.Add(product, 0);
            }

            _products[product] += quantity;
        }
    }
}
