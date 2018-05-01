using CandyStore.Client.Cache;
using CandyStore.Client.Messages;
using CandyStore.Client.Prompt;
using CandyStore.DataModel;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CandyStore.Client.Forms
{
    public partial class ProductDetailsForm : Form
    {
        private int _productID;
        public ProductDetailsForm(int productID)
        {
            _productID = productID;
            InitializeComponent();
        }

        private void ProductDetailsForm_Load(object sender, EventArgs e)
        {
            using (var context = new CandyStoreDbContext())
            {
                var product = context.Products.FirstOrDefault(p => p.ProductID == this._productID);
                this.Text = product.Category.Name;
                productName.Text = product.Name;
                productPrice.Text = product.Price.ToString();
                onStock.Text = product.Count.ToString();
            }
            foreach (Label lbl in this.Controls.OfType<Label>())
            {
                lbl.BackColor = Color.Transparent;
            }

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            var productQuantity = productQuantityBox.Text;
            int quantityToNumber;
            bool result = Int32.TryParse(productQuantity, out quantityToNumber);
            if (result)
            {
                if(quantityToNumber == 0)
                {
                    Logger.ShowError("Quantity cannot be 0");
                    return;
                }

                var confirmationResult = PromptMessage.ConfirmationMessage("Are you sure you want to add these records to the shopping cart?");
                if (!confirmationResult)
                {
                    return;
                }
                using (var context = new CandyStoreDbContext())
                {
                    var product = context.Products.FirstOrDefault(p => p.ProductID == this._productID);

                    if (product.Count < quantityToNumber)
                    {
                        Logger.ShowError("Not enough quantity on stock");
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
                }

            }
            else
            {
                Logger.ShowError("Quantity must be a whole positive number");
                return;
            }
            this.Hide();
        }
    }
}
