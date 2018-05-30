using CandyStore.Client.Cache;
using CandyStore.Client.Messages;
using CandyStore.Client.Prompt;
using CandyStore.Client.Util;
using CandyStore.Infrastructure;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CandyStore.Client.Forms
{
    public partial class ProductsForm : Form
    {
        private int _categoryId;

        public ProductsForm()
        {
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
            using (var ctx = new CandyStoreDbContext())
            {
                var category = ctx.Categories
                    .FirstOrDefault(c => c.CategoryID == _categoryId);

                var categoryName = category.Name;
                var products = category
                    .Products
                    .ToList();

                productsList.ValueMember = "ProductID";
                productsList.DisplayMember = "Name";
                productsList.DataSource = products;

                categoryNameLbl.Text = categoryName.ToString();

                if (!products.Any())
                {
                    productQuantityBox.Enabled = false;
                    addToCartBtn.Enabled = false;
                    noProductsLbl.Visible = true;
                }
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void productsList_SelectedIndexChanged(object sender, EventArgs e)
        {

            using (var ctx = new CandyStoreDbContext())
            {
                var productId = int.Parse(productsList.SelectedValue.ToString());

                var product = ctx.Products
                    .FirstOrDefault(c => c.ProductID == productId);
                var productImage = product
                    .ProductImage;

                Image image;
                using (MemoryStream ms = new MemoryStream(productImage))
                {
                    image = Image.FromStream(ms);
                }

                productPictureBox.Image = image;
                productPrice.Text = $"${product.Price}";
                onStock.Text = product.Count.ToString();
            }
        }

        private void addToCartBtn_Click(object sender, EventArgs e)
        {
            var productQuantity = productQuantityBox.Text;
            int quantityToNumber;
            bool result = int.TryParse(productQuantity, out quantityToNumber);
            if (result)
            {
                if (quantityToNumber <= 0)
                {
                    MessageForm.ShowError("Quantity must be a positive number.");
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
            else
            {
                MessageForm.ShowError("Quantity must be a whole positive number");
                return;
            }
        }
    }
}
