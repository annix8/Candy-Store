using CandyStore.Client.Cache;
using CandyStore.Client.Services;
using CandyStore.Client.Util;
using CandyStore.Contracts.Client.Services;
using CandyStore.Contracts.Client.Views;
using CandyStore.Contracts.Infrastructure;
using CandyStore.Contracts.Infrastructure.Utilities;
using CandyStore.DataModel.Models;
using CandyStore.Infrastructure.Repositories;
using CandyStore.Infrastructure.Utilities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CandyStore.Client.Views
{
    public partial class CategoriesView : Form, ICategoriesView
    {
        private readonly IViewService _viewService;
        private readonly ICandyStoreRepository _candyStoreRepository;
        private readonly IImageUtil _imageUtil;

        public CategoriesView(IViewService viewService)
        {
            _viewService = viewService;

            // TODO: (04.June.2018) - use dependency injection
            _candyStoreRepository = new CandyStoreRepository(new Infrastructure.CandyStoreDbContext());
            _imageUtil = new ImageUtil();

            InitializeComponent();

            CandyStoreUtil.MakeLabelsTransparent(this);
        }

        private void CategoriesForm_Load(object sender, EventArgs e)
        {
            var categories = _candyStoreRepository.GetAll<Category>()
                .ToList();

            categoriesList.ValueMember = nameof(Category.CategoryID);
            categoriesList.DisplayMember = nameof(Category.Name);
            categoriesList.DataSource = categories;
        }

        private void categoriesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var categoryId = int.Parse(categoriesList.SelectedValue.ToString());

            var byteArrayCategoryImage = _candyStoreRepository.GetAll<Category>()
                .FirstOrDefault(c => c.CategoryID == categoryId)
                .CategoryImage;

            categoryPictureBox.Image = _imageUtil.GetImageFromByteArray(byteArrayCategoryImage);
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            _viewService.ShowView<IHomeView>(this);
            Session.Clear();
        }

        private void shoppingCartBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var shoppingCartForm = new ShoppingCartForm();
            shoppingCartForm.Show();
        }

        private void selectCategoryBtn_Click(object sender, EventArgs e)
        {
            var categoryId = int.Parse(categoriesList.SelectedValue.ToString());

            var productsForm = new ProductsForm();
            productsForm.CategoryId = categoryId;
            productsForm.ShowDialog();
        }
    }
}
