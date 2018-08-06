using CandyStore.Client.Util;
using CandyStore.Contracts.Client.Presenters;
using CandyStore.Contracts.Client.Views;
using CandyStore.Contracts.Infrastructure;
using CandyStore.DataModel.CandyStoreModels;
using CandyStore.DataModel.Models;
using System.Linq;

namespace CandyStore.Client.Presenters
{
    public class ProductsPresenter : IProductsPresenter
    {
        private readonly ICandyStoreRepository _candyStoreRepository;
        private readonly ISession _session;

        public ProductsPresenter(ICandyStoreRepository candyStoreRepository,
            ISession session)
        {
            _candyStoreRepository = candyStoreRepository;
            _session = session;
        }

        public IProductsView View { get; set; }

        public Category GetCategoryById(int categoryId)
        {
            return _candyStoreRepository.GetAll<Category>()
                .FirstOrDefault(x => x.CategoryID == categoryId);
        }

        public Product GetProductById(int productId)
        {
            return _candyStoreRepository.GetAll<Product>()
                .FirstOrDefault(x => x.ProductID == productId);
        }

        public int GetProductQuantity(Product product)
        {
            var productQuantity = product.Count;
            var productQuantityInSession = _session
                                            .Get<ShoppingCart>(Constants.SHOPPING_CART_KEY)
                                            .GetProductQuantity(product);

            productQuantity -= productQuantityInSession;
            return productQuantity;
        }

        public OperationValidationResult AddProductToCart(string productIdString, string quantityString)
        {
            var result = new OperationValidationResult
            {
                Valid = true
            };

            bool parsedQuantity = int.TryParse(quantityString, out int quantityToNumber);
            if (!parsedQuantity || quantityToNumber <= 0)
            {
                result.Valid = false;
                result.AddErrorMessage("Quantity must be a whole positive number");
                return result;
            }

            var confirmationResult = View.GetProductAddToCartConfirmationResult();
            if (!confirmationResult)
            {
                result.Valid = false;
                return result;
            }

            var productId = int.Parse(productIdString);
            var product = _candyStoreRepository.GetAll<Product>().FirstOrDefault(p => p.ProductID == productId);

            int productCountInSession = _session
                                            .Get<ShoppingCart>(Constants.SHOPPING_CART_KEY)
                                            .GetProductQuantity(product);

            if (product.Count - productCountInSession < quantityToNumber)
            {
                result.Valid = false;
                result.AddErrorMessage("Not enough quantity on stock");
                return result;
            }

            _session.Get<ShoppingCart>(Constants.SHOPPING_CART_KEY).AddQuantityToProduct(product, quantityToNumber);

            result.Object = product.Count - _session.Get<ShoppingCart>(Constants.SHOPPING_CART_KEY)
                                                        .GetProductQuantity(product);

            return result;
        }
    }
}
