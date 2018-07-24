using CandyStore.Client.Cache;
using CandyStore.Contracts.Client.Presenters;
using CandyStore.Contracts.Client.Views;
using CandyStore.Contracts.Infrastructure;
using System.Linq;
using CandyStore.DataModel.CandyStoreModels;
using System.Collections.Generic;
using CandyStore.DataModel.Models;
using System;
using CandyStore.Client.Messages;
using CandyStore.Client.Util;

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
                TotalPrice = Session.Products.Sum(x => x.Key.Price * x.Value)
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

        public DataValidationResult PerformProdcutValidation(int productId, string operation)
        {
            var result = new DataValidationResult();

            var productFromDB = _candyStoreRepository.GetAll<Product>().FirstOrDefault(p => p.ProductID == productId);
            var productQuantityFromSession = Session.Products.FirstOrDefault(p => p.Key.ProductID == productFromDB.ProductID).Value;

            switch (operation)
            {
                case Constants.PLUS_OPERATION:
                    result = ValidatePlusOperation(productFromDB, productQuantityFromSession);
                    break;
                case Constants.MINUS_OPERATION:
                    result = ValidateMinusOperation(productFromDB, productQuantityFromSession);
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

        private DataValidationResult ValidatePlusOperation(Product product, int productQuantityFromSession)
        {
            var result = new DataValidationResult
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

            return result;
        }

        private DataValidationResult ValidateMinusOperation(Product product, int productQuantityFromSession)
        {
            var result = new DataValidationResult
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
            }

            return result;
        }

        public void UpdateProductQuantityInCart(int productId, int quantity)
        {
            var productInSession = Session.Products.FirstOrDefault(x => x.Key.ProductID == productId);
            Session.Products[productInSession.Key] += quantity;
        }
    }
}
