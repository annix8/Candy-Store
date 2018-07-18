﻿using CandyStore.Client.Cache;
using CandyStore.Client.Util;
using CandyStore.Contracts.Client.Presenters;
using CandyStore.Contracts.Client.Services;
using CandyStore.Contracts.Client.Views;
using CandyStore.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CandyStore.Client.Views
{
    public partial class CategoriesView : Form, ICategoriesView
    {
        private readonly IViewService _viewService;

        public CategoriesView(IViewService viewService)
        {
            _viewService = viewService;

            InitializeComponent();

            CandyStoreUtil.MakeLabelsTransparent(this);
        }

        public ICategoriesPresenter CategoriesPresenter { get; set; }

        private void CategoriesForm_Load(object sender, EventArgs e)
        {
            IList<Category> categories = CategoriesPresenter.GetAllCategories();

            categoriesList.ValueMember = nameof(Category.CategoryID);
            categoriesList.DisplayMember = nameof(Category.Name);
            categoriesList.DataSource = categories;
        }

        private void categoriesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var categoryId = int.Parse(categoriesList.SelectedValue.ToString());

            categoryPictureBox.Image = CategoriesPresenter.GetCategoryImageById(categoryId);
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

            var values = new Dictionary<string, object>
            {
                { nameof(IProductsView.CategoryId), categoryId }
            };

            _viewService.ShowDialogViewWithPropertyInjection<IProductsView>(values);
        }
    }
}
