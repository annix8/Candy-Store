using CandyStore.Contracts.Client.Presenters;
using CandyStore.Contracts.Infrastructure;
using CandyStore.DataModel.Models;
using System.Linq;
using CandyStore.Contracts.Client.Views;
using CandyStore.Client.Cache;

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
            var productCountInSession = Session.GetProductCount(product);

            productQuantity -= productCountInSession;
            return productQuantity;
        }
    }
}
