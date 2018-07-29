using CandyStore.Contracts.Client.Presenters;
using CandyStore.Contracts.Infrastructure;
using CandyStore.DataModel.Models;
using System.Linq;
using CandyStore.Contracts.Client.Views;
using CandyStore.Client.Cache;
using CandyStore.DataModel.CandyStoreModels;

namespace CandyStore.Client.Presenters
{
    public class ProductsPresenter : IProductsPresenter
    {
        private readonly ICandyStoreRepository _candyStoreRepository;

        public ProductsPresenter(ICandyStoreRepository candyStoreRepository)
        {
            _candyStoreRepository = candyStoreRepository;
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
            var productQuantityInSession = Session.GetProductQuantity(product);

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
            if (!parsedQuantity || quantityToNumber < 0)
            {
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

            int productCountInSession = Session.GetProductQuantity(product);

            if (product.Count - productCountInSession < quantityToNumber)
            {
                result.Valid = false;
                result.AddErrorMessage("Not enough quantity on stock");
                return result;
            }

            Session.AddQuantityToProduct(product, quantityToNumber);

            result.Object = product.Count - Session.GetProductQuantity(product);

            return result;
        }
    }
}
