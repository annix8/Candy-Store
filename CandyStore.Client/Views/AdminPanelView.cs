using CandyStore.Client.Messages;
using CandyStore.Contracts.Client.Views;
using CandyStore.Contracts.Infrastructure;
using CandyStore.Contracts.Infrastructure.Utilities;
using CandyStore.DataModel.Models;
using CandyStore.Infrastructure.Repositories;
using CandyStore.Infrastructure.Utilities;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CandyStore.Client.Views
{
    public partial class AdminPanelView : BaseView, IAdminPanelView
    {
        private readonly ICandyStoreRepository _candyStoreRepository;
        private readonly IImageUtil _imageUtil;

        private byte[] _categoryImage;
        private byte[] _productImage;

        public AdminPanelView(ICandyStoreRepository candyStoreRepository)
        {
            _candyStoreRepository = candyStoreRepository;
            _imageUtil = new ImageUtil();

            InitializeComponent();
        }

        private void choosePictureButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var file = openFileDialog1.FileName;

                    this._categoryImage = _imageUtil.ConvertImageToByteArray(file);

                    var fileName = openFileDialog1.SafeFileName;
                    categoryImageSelectedLabel.Text = fileName;
                }
                catch (Exception ex)
                {
                    NotifyMessageBox.ShowError("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void saveCategoryButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(categoryNameBox.Text) || this._categoryImage == null)
            {
                NotifyMessageBox.ShowError("Category image or category name were not set");
                return;
            }

            _candyStoreRepository.Insert(new Category
            {
                Name = categoryNameBox.Text,
                CategoryImage = this._categoryImage
            });

            NotifyMessageBox.ShowSuccess("Record successfully added");
            categoryNameBox.Text = string.Empty;
            this._categoryImage = null;
            categoryImageSelectedLabel.Text = "No image selected...";
            FillProductsAndCategoriesComboBoxes();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AdminPanelForm_Load(object sender, EventArgs e)
        {
            FillProductsAndCategoriesComboBoxes();
            SetAutoCompleteOnComboboxes();
            this.BackgroundImageLayout = ImageLayout.Center;
            this.groupBox1.BackColor = Color.Transparent;
            this.groupBox4.BackColor = Color.Transparent;
        }

        private void SetAutoCompleteOnComboboxes()
        {
            categoryComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            categoryComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;

            productCategoryComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            productCategoryComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;

            productComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            productComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;

            productInsertStock.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            productInsertStock.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void FillProductsAndCategoriesComboBoxes()
        {
            var categories = _candyStoreRepository.GetAll<Category>().ToList();
            var products = _candyStoreRepository.GetAll<Product>().ToList();

            //clear all comboboxes so there wouldnt be duplication
            categoryComboBox.Items.Clear();
            productCategoryComboBox.Items.Clear();

            productComboBox.Items.Clear();
            productInsertStock.Items.Clear();

            // fill comboboxes
            foreach (Category category in categories)
            {
                categoryComboBox.Items.Add(category.Name);
                productCategoryComboBox.Items.Add(category.Name);
            }
            foreach (Product product in products)
            {
                productComboBox.Items.Add(product.Name);
                productInsertStock.Items.Add(product.Name);
            }
        }

        private void choosePictureButtonProduct_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var file = openFileDialog1.FileName;

                    this._productImage = _imageUtil.ConvertImageToByteArray(file);

                    var fileName = openFileDialog1.SafeFileName;
                    imageSelectedLabelProduct.Text = fileName;
                }
                catch (Exception ex)
                {
                    NotifyMessageBox.ShowError("Could not read file from disk. Original error: " + ex.Message);
                    return;
                }
            }
        }

        private void productSave_Click(object sender, EventArgs e)
        {
            double productPrice;
            var isParsed = double.TryParse(productPriceBox.Text, out productPrice);
            if (!isParsed || productPrice < 0)
            {
                NotifyMessageBox.ShowError("Price must be a positive number.");
                return;
            }

            if (_productImage == null)
            {
                NotifyMessageBox.ShowError("Select an image for the product.");
                return;
            }

            var productName = productNameBox.Text;
            var categoryName = productCategoryComboBox.Text;

            if (string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(categoryName))
            {
                NotifyMessageBox.ShowError("Type in a valid name for product and category.");
                return;
            }

            try
            {
                var product = new Product
                {
                    Name = productName,
                    Price = productPrice
                };
                var category = _candyStoreRepository.GetAll<Category>().FirstOrDefault(c => c.Name == categoryName);
                product.Category = category;
                product.ProductImage = this._productImage;

                _candyStoreRepository.Insert(product);
            }
            catch (Exception ex)
            {
                NotifyMessageBox.ShowError(ex.Message);
                return;
            }
            NotifyMessageBox.ShowSuccess("Record successfully added");
            productNameBox.Text = string.Empty;
            productPriceBox.Text = string.Empty;
            productCategoryComboBox.Text = string.Empty;
            this._productImage = null;
            imageSelectedLabelProduct.Text = "No image selected...";
            FillProductsAndCategoriesComboBoxes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = PromptMessage.ConfirmationMessage("Are you sure you want to delete this record?");
            if (result)
            {
                var productName = productComboBox.Text;
                if (string.IsNullOrEmpty(productName))
                {
                    NotifyMessageBox.ShowError("You haven't selected product name");
                }

                try
                {
                    var productToDelete = _candyStoreRepository.GetAll<Product>().FirstOrDefault(p => p.Name == productName);
                    _candyStoreRepository.Delete(productToDelete);
                }
                catch (Exception ex)
                {
                    NotifyMessageBox.ShowError(ex.Message);
                    return;
                }

                NotifyMessageBox.ShowSuccess("Product deleted");
                FillProductsAndCategoriesComboBoxes();
            }
        }

        private void deleteCategory_Click(object sender, EventArgs e)
        {
            var result = PromptMessage.ConfirmationMessage("Are you sure you want to delete this record?");
            if (result)
            {
                var categoryName = categoryComboBox.Text;
                if (string.IsNullOrEmpty(categoryName))
                {
                    NotifyMessageBox.ShowError("You haven't selected category name");
                    return;
                }

                try
                {
                    var categoryToDelete = _candyStoreRepository.GetAll<Category>().FirstOrDefault(p => p.Name == categoryName);
                    _candyStoreRepository.Delete(categoryToDelete);
                }
                catch (Exception ex)
                {
                    NotifyMessageBox.ShowError(ex.Message);
                }

                NotifyMessageBox.ShowSuccess("Category deleted");
                FillProductsAndCategoriesComboBoxes();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var product = productInsertStock.Text;

            int parsedQuantity;
            var isParsed = int.TryParse(productQuantityToAdd.Text, out parsedQuantity);
            if (!isParsed || parsedQuantity < 1)
            {
                NotifyMessageBox.ShowError("Quantity must be a whole positive number.");
                return;
            }

            try
            {
                var productFromDB = _candyStoreRepository.GetAll<Product>().FirstOrDefault(pro => pro.Name == product);
                productFromDB.Count += parsedQuantity;
                _candyStoreRepository.Update(productFromDB);
            }
            catch (Exception ex)
            {
                NotifyMessageBox.ShowError(ex.Message);
                return;
            }

            NotifyMessageBox.ShowSuccess("Record successfully added");
            productInsertStock.Text = string.Empty;
            productQuantityToAdd.Text = string.Empty;
            FillProductsAndCategoriesComboBoxes();
        }

        private void categoryDiscard_Click(object sender, EventArgs e)
        {
            categoryNameBox.Text = string.Empty;
            _categoryImage = null;
            categoryImageSelectedLabel.Text = "No image selected...";
        }

        private void productDiscard_Click(object sender, EventArgs e)
        {
            productNameBox.Text = string.Empty;
            productPriceBox.Text = string.Empty;
            productCategoryComboBox.SelectedIndex = -1;
            _productImage = null;
        }
    }
}