﻿using CandyStore.Client.Cache;
using CandyStore.Client.Messages;
using CandyStore.Client.Prompt;
using CandyStore.Client.Util;
using CandyStore.Contracts.Infrastructure;
using CandyStore.Contracts.Infrastructure.Utilities;
using CandyStore.DataModel.Models;
using CandyStore.Infrastructure;
using CandyStore.Infrastructure.Repositories;
using CandyStore.Infrastructure.Utilities;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CandyStore.Client.Forms
{
    public partial class ProductsForm : Form
    {
        private readonly ICandyStoreRepository _candyStoreRepository;
        private readonly IImageProvider _imageProvider;

        private int _categoryId;

        public ProductsForm()
        {
            // TODO: (04.June.2018) - use dependency injection
            _candyStoreRepository = new CandyStoreRepository();
            _imageProvider = new ImageProvider();

            InitializeComponent();

            CandyStoreUtil.MakeLabelsTransparent(this);
            noProductsLbl.Visible = false;
        }

        public int CategoryId
        {
            get { return _categoryId; }
            set { _categoryId = value; }
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            var category = _candyStoreRepository.GetAll<Category>()
                .FirstOrDefault(c => c.CategoryID == _categoryId);

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
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void productsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var productId = int.Parse(productsList.SelectedValue.ToString());

            var product = _candyStoreRepository.GetAll<Product>()
                    .FirstOrDefault(c => c.ProductID == productId);

            productPictureBox.Image = _imageProvider.GetImageFromByteArray(product.ProductImage);
            productPrice.Text = $"${product.Price}";
            onStock.Text = product.Count.ToString();
        }

        private void addToCartBtn_Click(object sender, EventArgs e)
        {
            int quantityToNumber;
            bool result = int.TryParse(productQuantityBox.Text, out quantityToNumber);
            if (!result || quantityToNumber < 0)
            {
                MessageForm.ShowError("Quantity must be a whole positive number");
                return;
            }

            var confirmationResult = PromptMessage.ConfirmationMessage("Are you sure you want to add these records to the shopping cart?");
            if (!confirmationResult)
            {
                return;
            }
            using (var context = new CandyStoreDbContext())
            {
                var productId = int.Parse(productsList.SelectedValue.ToString());
                var product = context.Products.FirstOrDefault(p => p.ProductID == productId);

                if (product.Count < quantityToNumber)
                {
                    MessageForm.ShowError("Not enough quantity on stock");
                    return;
                }
                else
                {
                    product.Count -= quantityToNumber;

                    if (Session.Products.ContainsKey(product))
                    {
                        Session.Products[product] += quantityToNumber;
                    }
                    else
                    {
                        Session.Products.Add(product, quantityToNumber);
                    }
                }
                context.SaveChanges();
                productQuantityBox.Clear();
                onStock.Text = product.Count.ToString();
            }
        }
    }
}
