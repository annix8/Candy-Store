using CandyStore.Client.Cache;
using CandyStore.Contracts.Client.Presenters;
using CandyStore.Contracts.Client.Views;
using CandyStore.Contracts.Infrastructure;
using System.Linq;
using CandyStore.DataModel.CandyStoreModels;
using System.Collections.Generic;
using CandyStore.DataModel.Models;

namespace CandyStore.Client.Presenters
{
    public class ShoppingCartPresenter : IShoppingCartPresenter
    {
        private readonly ICandyStoreRepository _candyStoreRepository;

        public ShoppingCartPresenter(ICandyStoreRepository candyStoreRepository)
        {
            _candyStoreRepository = candyStoreRepository;
        }

        public IShoppingCartView View { get; set; }

        public IList<ShoppingCartProductViewModel> GetProductsForDisplay()
        {
            return Session.Products
                .Select(x => new ShoppingCartProductViewModel
                {
                    ProductCategory = GetProductCategory(x.Key.ProductID),
                    ProductName = x.Key.Name,
                    ProductPrice = x.Key.Price,
                    ProductQuantity = x.Value
                })
                .ToList();
        }

        public double GetTotalPriceOfProducts()
        {
            return Session.Products.Sum(x => x.Key.Price * x.Value);
        }

        private string GetProductCategory(int productID)
        {
            return _candyStoreRepository.GetAll<Product>()
                .FirstOrDefault(p => p.ProductID == productID).Category.Name;
        }
    }
}
