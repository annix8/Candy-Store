using CandyStore.Client.Util;
using CandyStore.Contracts.Client.Presenters;
using CandyStore.Contracts.Client.Services;
using CandyStore.Contracts.Client.Views;
using CandyStore.DataModel.Models;
using System;
using System.Collections.Generic;

namespace CandyStore.Client.Views
{
    public partial class CategoriesView : BaseView, ICategoriesView
    {
        private readonly IViewService _viewService;

        public CategoriesView(ICategoriesPresenter categoriesPresenter, IViewService viewService)
        {
            Presenter = categoriesPresenter;
            Presenter.View = this;

            _viewService = viewService;

            InitializeComponent();

            CandyStoreUtil.MakeLabelsTransparent(this);
        }

        public ICategoriesPresenter Presenter { get; set; }

        private void CategoriesForm_Load(object sender, EventArgs e)
        {
            IList<Category> categories = Presenter.GetAllCategories();

            categoriesList.ValueMember = nameof(Category.CategoryID);
            categoriesList.DisplayMember = nameof(Category.Name);
            categoriesList.DataSource = categories;
        }

        private void categoriesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var categoryId = int.Parse(categoriesList.SelectedValue.ToString());

            categoryPictureBox.Image = Presenter.GetCategoryImageById(categoryId);
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Presenter.ClearShoppingCart();
            _viewService.ShowView<IHomeView>(this);
        }

        private void shoppingCartBtn_Click(object sender, EventArgs e)
        {
            _viewService.ShowView<IShoppingCartView>(this);
        }

        private void selectCategoryBtn_Click(object sender, EventArgs e)
        {
            var categoryId = int.Parse(categoriesList.SelectedValue.ToString());

            var values = new Dictionary<string, object>
            {
                { nameof(IProductsView.CategoryId), categoryId }
            };

            _viewService.ShowDialogViewWithPropertyInjection<IProductsView>(values);
        }
    }
}
