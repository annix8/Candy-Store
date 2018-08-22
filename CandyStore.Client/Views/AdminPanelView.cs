using CandyStore.Client.Messages;
using CandyStore.Contracts.Client.Presenters;
using CandyStore.Contracts.Client.Views;
using CandyStore.Contracts.Infrastructure;
using CandyStore.Contracts.Infrastructure.Utilities;
using CandyStore.DataModel.Models;
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


        public AdminPanelView(IAdminPanelPresenter adminPanelPresenter, ICandyStoreRepository candyStoreRepository)
        {
            Presenter = adminPanelPresenter;
            Presenter.View = this;

            _candyStoreRepository = candyStoreRepository;
            _imageUtil = new ImageUtil();

            InitializeComponent();
        }

        public IAdminPanelPresenter Presenter { get; set; }

        private void choosePictureButton_Click(object sender, EventArgs e)
        {
            // TODO 22.August.2018 - Maybe make a facade?
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var file = openFileDialog.FileName;

                    _categoryImage = _imageUtil.ConvertImageToByteArray(file);

                    var fileName = openFileDialog.SafeFileName;
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
            var result = Presenter.AddNewCategory(categoryNameBox.Text, _categoryImage);

            if (!result.Valid)
            {
                NotifyMessageBox.ShowError(result.GetAllErrorMessages());
                return;
            }

            NotifyMessageBox.ShowSuccess("Record successfully added");
            categoryNameBox.Text = string.Empty;
            _categoryImage = null;
            categoryImageSelectedLabel.Text = "No image selected...";
            FillProductsAndCategoriesComboBoxes();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AdminPanelForm_Load(object sender, EventArgs e)
        {
            FillProductsAndCategoriesComboBoxes();
            SetAutoCompleteOnComboboxes();
            BackgroundImageLayout = ImageLayout.Center;
            groupBox1.BackColor = Color.Transparent;
            groupBox4.BackColor = Color.Transparent;
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
            var categories = Presenter.GetAllCategories();
            var products = Presenter.GetAllProducts();

            //clear all comboboxes so there wouldn't be duplication
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
            // TODO 22.August.2018 - Maybe make a facade?
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var file = openFileDialog.FileName;

                    _productImage = _imageUtil.ConvertImageToByteArray(file);

                    var fileName = openFileDialog.SafeFileName;
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
            var result = Presenter.AddNewProduct(productPriceBox.Text,
                productNameBox.Text,
                productCategoryComboBox.Text,
                _productImage);
            if (!result.Valid)
            {
                NotifyMessageBox.ShowError(result.GetAllErrorMessages());
                return;
            }

            NotifyMessageBox.ShowSuccess("Record successfully added");
            productNameBox.Text = string.Empty;
            productPriceBox.Text = string.Empty;
            productCategoryComboBox.Text = string.Empty;
            _productImage = null;
            imageSelectedLabelProduct.Text = "No image selected...";
            FillProductsAndCategoriesComboBoxes();
        }

        private void deleteProductBtn_Click(object sender, EventArgs e)
        {
            var result = Presenter.DeleteProduct(productComboBox.Text);
            if (!result.Valid)
            {
                NotifyMessageBox.ShowError(result.GetAllErrorMessages());
                return;
            }

            NotifyMessageBox.ShowSuccess("Product deleted");
            FillProductsAndCategoriesComboBoxes();
        }

        private void deleteCategory_Click(object sender, EventArgs e)
        {
            var result = Presenter.DeleteCategory(categoryComboBox.Text);
            if (!result.Valid)
            {
                NotifyMessageBox.ShowError(result.GetAllErrorMessages());
                return;
            }

            NotifyMessageBox.ShowSuccess("Category deleted");
            FillProductsAndCategoriesComboBoxes();
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

        public bool GetConfirmationResult()
        {
            return PromptMessage.ConfirmationMessage("Are you sure you want to delete this record?");
        }
    }
}