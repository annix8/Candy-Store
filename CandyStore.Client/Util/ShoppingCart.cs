using CandyStore.DataModel.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CandyStore.Client.Util
{
    public class ShoppingCart
    {
        private readonly IDictionary<Product, int> _productsHash;

        public ShoppingCart()
        {
            _productsHash = new Dictionary<Product, int>();
        }

        public int GetProductQuantity(Product product)
        {
            if (_productsHash.ContainsKey(product))
            {
                return _productsHash[product];
            }

            return 0;
        }

        public void AddQuantityToProduct(Product product, int quantity)
        {
            if (!_productsHash.ContainsKey(product))
            {
                _productsHash.Add(product, 0);
            }

            _productsHash[product] += quantity;
        }

        public void RemoveProduct(Product product)
        {
            _productsHash.Remove(product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productsHash.Keys;
        }

        public IReadOnlyDictionary<Product, int> GetAllProductsWithQuantity()
        {
            return new ReadOnlyDictionary<Product, int>(_productsHash);
        }

        public Product GetProductById(int productId)
        {
            return _productsHash.FirstOrDefault(x => x.Key.ProductID == productId).Key;
        }

        public IEnumerable<int> GetProductIds()
        {
            return _productsHash.Keys.Select(x => x.ProductID);
        }

        public double GetTotalPrice()
        {
            return _productsHash.Sum(x => x.Key.Price * x.Value);
        }
    }
}
