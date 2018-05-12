using CandyStore.DataModel;
using CandyStore.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CandyStore.Client.Prompt;
using CandyStore.Client.Messages;

namespace CandyStore.Client.Forms
{
    public partial class AdminPanelForm : Form
    {
        private byte[] _categoryImage;
        private byte[] _productImage;
        public AdminPanelForm()
        {
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
                    
                    this._categoryImage = ConvertImageToByteArray(file);

                    var fileName = openFileDialog1.SafeFileName;
                    imageSelectedLabel.Text = fileName;
                }
                catch (Exception ex)
                {
                    MessageForm.ShowError("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private byte[] ConvertImageToByteArray(string file)
        {
            Image.GetThumbnailImageAbort myCallback =
                               new Image.GetThumbnailImageAbort(ThumbnailCallback);
            Bitmap myBitmap = new Bitmap(file);
            Image myThumbnail = myBitmap.GetThumbnailImage(250, 250,
                myCallback, IntPtr.Zero);

            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(myThumbnail, typeof(byte[]));
            return xByte;
        }

        public bool ThumbnailCallback()
        {
            return false;
        }

        private void saveCategoryButton_Click(object sender, EventArgs e)
        {
            if (categoryNameBox.Text == "" || this._categoryImage == null)
            {
                MessageForm.ShowError("Category image or category name were not set");
                return;
            }
            using (var context = new CandyStoreDbContext())
            {
                try
                {
                    context.Categories.Add(new Category
                    {
                        Name = categoryNameBox.Text,
                        CategoryImage = this._categoryImage
                    });
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageForm.ShowError(ex.Message);
                    return;
                }
                MessageForm.ShowSuccess("Record successfully added");
                categoryNameBox.Text = string.Empty;
                this._categoryImage = null;
                imageSelectedLabel.Text = "No image selected...";
                FillProductsAndCategoriesComboBoxes();
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            var main = Application.OpenForms.OfType<Main>().FirstOrDefault();
            main.Show();
            this.Hide();
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
            using (var context = new CandyStoreDbContext())
            {
                List<Category> categories = context.Categories.ToList();
                List<Product> products = context.Products.ToList();

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
        }

        private void choosePictureButtonProduct_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var file = openFileDialog1.FileName;
                    
                    this._productImage = ConvertImageToByteArray(file);

                    var fileName = openFileDialog1.SafeFileName;
                    imageSelectedLabelProduct.Text = fileName;
                }
                catch (Exception ex)
                {
                    MessageForm.ShowError("Could not read file from disk. Original error: " + ex.Message);
                    return;
                }
            }
        }

        private void productSave_Click(object sender, EventArgs e)
        {
            var productName = productNameBox.Text;
            var productPrice = double.Parse(productPriceBox.Text);
            var categoryName = productCategoryComboBox.Text;

            using (var context = new CandyStoreDbContext())
            {
                try
                {
                    var product = new Product();
                    product.Name = productName;
                    product.Price = productPrice;
                    var category = context.Categories.FirstOrDefault(c => c.Name == categoryName);
                    product.Category = category;
                    product.ProductImage = this._productImage;

                    context.Products.Add(product);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageForm.ShowError(ex.Message);
                    return;
                }
                MessageForm.ShowSuccess("Record successfully added");
                productNameBox.Text = string.Empty;
                productPriceBox.Text = string.Empty;
                productCategoryComboBox.Text = string.Empty;
                this._productImage = null;
                imageSelectedLabelProduct.Text = "No image selected...";
                FillProductsAndCategoriesComboBoxes();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = PromptMessage.ConfirmationMessage("Are you sure you want to delete this record?");
            if (result)
            {
                var productName = productComboBox.Text;
                if (productName == "")
                {
                    MessageForm.ShowError("You haven't selected product name");
                }

                using (var context = new CandyStoreDbContext())
                {
                    try
                    {
                        var productToDelete = context.Products.FirstOrDefault(p => p.Name == productName);
                        context.Products.Remove(productToDelete);
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageForm.ShowError(ex.Message);
                        return;
                    }
                }

                MessageForm.ShowSuccess("Product deleted");
                FillProductsAndCategoriesComboBoxes();
            }
        }

        private void deleteCategory_Click(object sender, EventArgs e)
        {
            var result = PromptMessage.ConfirmationMessage("Are you sure you want to delete this record?");
            if (result)
            {
                var categoryName = categoryComboBox.Text;
                if (categoryName == "")
                {
                    MessageForm.ShowError("You haven't selected category name");
                    return;
                }

                using (var context = new CandyStoreDbContext())
                {
                    try
                    {
                        var categoryToDelete = context.Categories.FirstOrDefault(p => p.Name == categoryName);
                        context.Categories.Remove(categoryToDelete);
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageForm.ShowError(ex.Message);
                    }
                }

                MessageForm.ShowSuccess("Category deleted");
                FillProductsAndCategoriesComboBoxes();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var product = productInsertStock.Text;
            var quantity = int.Parse(productQuantityToAdd.Text);
            //TODO: add validations for the above variables

            using (var context = new CandyStoreDbContext())
            {
                var productFromDB = context.Products.FirstOrDefault(pro => pro.Name == product);

                try
                {
                    productFromDB.Count += quantity;
                    context.SaveChanges();
                }
                catch(Exception ex)
                {
                    MessageForm.ShowError(ex.Message);
                    return;
                }
                MessageForm.ShowSuccess("Record successfully added");
                productInsertStock.Text = string.Empty;
                productQuantityToAdd.Text = string.Empty;
                FillProductsAndCategoriesComboBoxes();
            }
        }
    }
}
