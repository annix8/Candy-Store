using CandyStore.Contracts.Client.Presenters;
using CandyStore.Contracts.Client.Views;
using CandyStore.Contracts.Infrastructure;
using CandyStore.Contracts.Infrastructure.Utilities;
using CandyStore.DataModel.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CandyStore.Client.Presenters
{
    public class CategoriesPresenter : ICategoriesPresenter
    {
        private readonly ICandyStoreRepository _candyStoreRepository;
        private readonly IImageUtil _imageUtil;
        private readonly ISession _session;

        public CategoriesPresenter(ICandyStoreRepository candyStoreRepository,
            IImageUtil imageUtil,
            ISession session)
        {
            _candyStoreRepository = candyStoreRepository;
            _imageUtil = imageUtil;
            _session = session;
        }

        public ICategoriesView View { get; set; }

        public void ClearShoppingCart()
        {
            _session.Clear();
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
