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
        private readonly ISession _session;

        public ShoppingCartPresenter(ICandyStoreRepository candyStoreRepository,
            ISession session)
        {
            _candyStoreRepository = candyStoreRepository;
            _session = session;
        }

        public IShoppingCartView View { get; set; }
        private ShoppingCart ShoppingCart
        {
            get
            {
                return _session.Get<ShoppingCart>(Constants.SHOPPING_CART_KEY);
            }
        }

        public Order CreateOrder()
        {
            var order = new Order()
            {
                Customer = new Customer
                {
                    FirstName = _session.Get<string>(Constants.FIRST_NAME_KEY),
                    LastName = _session.Get<string>(Constants.LAST_NAME_KEY)
                },
                Date = DateTime.Now,
                TotalPrice = ShoppingCart.GetTotalPrice()
            };

            var shoppingCartProductIds = ShoppingCart.GetProductIds();
            var products = _candyStoreRepository.GetAll<Product>()
                .Where(x => shoppingCartProductIds.Contains(x.ProductID));

            var orderDetails = new List<OrderDetails>();
            foreach (var product in products)
            {
                var orderDetail = new OrderDetails
                {
                    Order = order,
                    Product = product,
                    ProductQuantity = ShoppingCart.GetProductQuantity(product)
                };

                orderDetails.Add(orderDetail);
            }

            _candyStoreRepository.InsertRange(orderDetails);

            var productsInDb = from product in ShoppingCart.GetAllProducts()
                               join dbProduct in _candyStoreRepository.GetAll<Product>()
                               on product.ProductID equals dbProduct.ProductID
                               select dbProduct;

            foreach (var product in ShoppingCart.GetAllProductsWithQuantity())
            {
                var productInDb = productsInDb.FirstOrDefault(x => x.ProductID.Equals(product.Key.ProductID));
                productInDb.Count -= product.Value;
            }

            _candyStoreRepository.UpdateRange(productsInDb);

            _session.Clear();

            return order;
        }

        public IList<ShoppingCartProductViewModel> GetProductsForDisplay()
        {
            return ShoppingCart
                .GetAllProductsWithQuantity()
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
            return ShoppingCart.GetTotalPrice();
        }

        public void UpdateProductQuantityInCart(int productId, int quantity)
        {
            var productInSession = ShoppingCart.GetProductById(productId);

            ShoppingCart.AddQuantityToProduct(productInSession, quantity);
        }

        public OperationValidationResult PerformProdcutQuantityChange(int productId, string operation)
        {
            var result = new OperationValidationResult();

            var productFromDB = _candyStoreRepository.GetAll<Product>().FirstOrDefault(p => p.ProductID == productId);
            var productQuantityFromSession = ShoppingCart.GetProductQuantity(productFromDB);

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
                    ShoppingCart.RemoveProduct(product);
                }
            }
            else
            {
                ShoppingCart.AddQuantityToProduct(product, -1);
                View.UpdateTotalPrice(-product.Price);
            }

            return result;
        }

        private ICollection<Product> GetProducts()
        {
            var productsInSession = ShoppingCart.GetAllProducts();
            var productsFromDb = from sessionProduct in productsInSession
                                 join dbProduct in _candyStoreRepository.GetAll<Product>()
                                 on sessionProduct.ProductID equals dbProduct.ProductID
                                 select dbProduct;

            return productsFromDb.ToList();
        }
    }
}
