using System.Collections.Generic;
using CandyStore.Contracts.Client.Presenters;
using CandyStore.Contracts.Client.Views;
using CandyStore.Contracts.Infrastructure;
using CandyStore.Contracts.Infrastructure.Utilities;
using CandyStore.DataModel.Models;
using System.Linq;
using System.Drawing;
using CandyStore.Client.Cache;

namespace CandyStore.Client.Presenters
{
    public class CategoriesPresenter : ICategoriesPresenter
    {
        private readonly ICandyStoreRepository _candyStoreRepository;
        private readonly IImageUtil _imageUtil;

        public CategoriesPresenter(ICandyStoreRepository candyStoreRepository, IImageUtil imageUtil)
        {
            _candyStoreRepository = candyStoreRepository;
            _imageUtil = imageUtil;
        }

        public ICategoriesView View { get; set; }

        public void ClearShoppingCart()
        {
            Session.Clear();
        }

        public IList<Category> GetAllCategories()
        {
            return _candyStoreRepository.GetAll<Category>()
                .ToList();
        }

        public Image GetCategoryImageById(int categoryId)
        {
            var byteArrayCategoryImage = _candyStoreRepository.GetAll<Category>()
                .FirstOrDefault(c => c.CategoryID == categoryId)
                .CategoryImage;

            return _imageUtil.GetImageFromByteArray(byteArrayCategoryImage);
        }
    }
}
