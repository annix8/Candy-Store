using CandyStore.Client.Cache;
using CandyStore.Client.Util;
using CandyStore.Contracts.Client.Presenters;
using CandyStore.Contracts.Client.Views;
using CandyStore.Contracts.Infrastructure;
using CandyStore.DataModel.CandyStoreModels;
using CandyStore.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public Order CreateOrder()
        {
            //TODO 24.July.2018 - Create factory class for this
            var order = new Order()
            {
                Customer = new Customer { FirstName = Session.FirstName, LastName = Session.LastName },
                Date = DateTime.Now,
                TotalPrice = Session.Products.Sum(x => x.Key.Price * x.Value),
                Products = GetProducts()
            };

            var insertedOrder = _candyStoreRepository.Insert(order);

            var productsInDb = from product in Session.Products
                               join dbProduct in _candyStoreRepository.GetAll<Product>()
                               on product.Key.ProductID equals dbProduct.ProductID
                               select dbProduct;

            foreach (var product in Session.Products)
            {
                var productInDb = productsInDb.FirstOrDefault(x => x.ProductID.Equals(product.Key.ProductID));
                productInDb.Count -= product.Value;
            }

            _candyStoreRepository.UpdateRange(productsInDb);

            Session.Clear();

            return insertedOrder;
        }

        public IList<ShoppingCartProductViewModel> GetProductsForDisplay()
        {
            return Session.Products
                .Select(x => new ShoppingCartProductViewModel
                {
                    ProductId = x.Key.ProductID,
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

        public void UpdateProductQuantityInCart(int productId, int quantity)
        {
            var productInSession = Session.Products.FirstOrDefault(x => x.Key.ProductID == productId);
            Session.Products[productInSession.Key] += quantity;
        }

        public OperationValidationResult PerformProdcutQuantityChange(int productId, string operation)
        {
            var result = new OperationValidationResult();

            var productFromDB = _candyStoreRepository.GetAll<Product>().FirstOrDefault(p => p.ProductID == productId);
            var productQuantityFromSession = Session.Products.FirstOrDefault(p => p.Key.ProductID == productFromDB.ProductID).Value;

            switch (operation)
            {
                case Constants.PLUS_OPERATION:
                    result = PerformPlusValidationOperation(productFromDB, productQuantityFromSession);
                    break;
                case Constants.MINUS_OPERATION:
                    result = PerformMinusValidationOperation(productFromDB, productQuantityFromSession);
                    break;
                default: throw new ArgumentException("Valid operations for quantity on the shopping cart are \"plus\" and \"minus\"");
            }

            return result;
        }

        private string GetProductCategory(int productID)
        {
            return _candyStoreRepository.GetAll<Product>()
                .FirstOrDefault(p => p.ProductID == productID).Category.Name;
        }

        private OperationValidationResult PerformPlusValidationOperation(Product product, int productQuantityFromSession)
        {
            var result = new OperationValidationResult
            {
                Valid = true,
                Object = product
            };

            var productCount = product.Count - productQuantityFromSession;

            if (productCount - 1 < 0)
            {
                result.Valid = false;
                result.AddErrorMessage("No more products in stock.");
            }

            View.UpdateTotalPrice(product.Price);

            return result;
        }

        private OperationValidationResult PerformMinusValidationOperation(Product product, int productQuantityFromSession)
        {
            var result = new OperationValidationResult
            {
                Valid = true,
                Object = product
            };

            if (productQuantityFromSession - 1 < 0)
            {
                var removalResult = View.ConfirmShoppingCartProductRemoval();
                if (removalResult)
                {
                    Session.Products.Remove(product);
                }
            }
            else
            {
                Session.Products[product] -= 1;
                View.UpdateTotalPrice(-product.Price);
            }

            return result;
        }

        private ICollection<Product> GetProducts()
        {
            var productsInSession = Session.Products.Keys;
            var productsFromDb = from sessionProduct in productsInSession
                                 join dbProduct in _candyStoreRepository.GetAll<Product>()
                                 on sessionProduct.ProductID equals dbProduct.ProductID
                                 select dbProduct;

            return productsFromDb.ToList();
        }
    }
}
