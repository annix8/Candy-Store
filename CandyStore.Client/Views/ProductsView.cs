﻿using CandyStore.Client.Cache;
using CandyStore.Client.Messages;
using CandyStore.Client.Util;
using CandyStore.Contracts.Client.Views;
using CandyStore.Contracts.Infrastructure;
using CandyStore.Contracts.Infrastructure.Utilities;
using CandyStore.DataModel.Models;
using System;
using System.Linq;
using CandyStore.Contracts.Client.Presenters;

namespace CandyStore.Client.Views
{
    public partial class ProductsView : BaseView, IProductsView
    {
        private readonly ICandyStoreRepository _candyStoreRepository;
        private readonly IImageUtil _imageUtil;

        public ProductsView(IProductsPresenter productsPresenter,
            ICandyStoreRepository candyStoreRepository,
            IImageUtil imageUtil)
        {
            Presenter = productsPresenter;
            Presenter.View = this;

            _candyStoreRepository = candyStoreRepository;
            _imageUtil = imageUtil;

            InitializeComponent();

            CandyStoreUtil.MakeLabelsTransparent(this);
            noProductsLbl.Visible = false;
        }

        public IProductsPresenter Presenter { get; set; }

        public int CategoryId { get; set; }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            var category = Presenter.GetCategoryById(CategoryId);

            var products = category
                .Products
                .ToList();

            productsList.ValueMember = nameof(Product.ProductID);
            productsList.DisplayMember = nameof(Category.Name);
            productsList.DataSource = products;

            categoryNameLbl.Text = category.Name;

            if (!products.Any())
            {
                productQuantityBox.Enabled = false;
                addToCartBtn.Enabled = false;
                noProductsLbl.Visible = true;
                onStock.Text = "0";
            }
            else
            {
                productQuantityBox.Enabled = true;
                addToCartBtn.Enabled = true;
                noProductsLbl.Visible = false;
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void productsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var productId = int.Parse(productsList.SelectedValue.ToString());
            var product = Presenter.GetProductById(productId);

            productPictureBox.Image = _imageUtil.GetImageFromByteArray(product.ProductImage);
            productPrice.Text = $"${product.Price}";

            var productQuantity = Presenter.GetProductQuantity(product);

            onStock.Text = productQuantity.ToString();
        }

        private void addToCartBtn_Click(object sender, EventArgs e)
        {
            var result = Presenter.AddProductToCart(productsList.SelectedValue.ToString(), productQuantityBox.Text);

            if (!result.Valid)
            {
                NotifyMessageBox.ShowError(result.GetAllErrorMessages());
            }

            productQuantityBox.Clear();

            // result.Object should hold the current quantity of product: the count of the product minus the count in the session
            onStock.Text = result.Object.ToString();
        }

        public bool GetProductAddToCartConfirmationResult()
        {
            return PromptMessage.ConfirmationMessage("Are you sure you want to add these records to the shopping cart?");
        }
    }
}
