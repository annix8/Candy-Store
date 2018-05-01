using CandyStore.DataModel;
using CandyStore.DataModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CandyStore.Client.Forms
{
    public partial class OrderProductsForm : Form
    {
        private int _categoryID;
        public OrderProductsForm(int categoryID)
        {
            this._categoryID = categoryID;
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void OrderProductsForm_Load(object sender, EventArgs e)
        {
            using (var context = new CandyStoreDbContext())
            {
                var products = context.Categories
                    .FirstOrDefault(c => c.CategoryID == this._categoryID)
                    .Products.ToList();

                if(products.Count == 0)
                {
                    var label = new Label();
                    label.Text = "There are no products for this category";
                    label.Location = new Point(400, 150);
                    label.Font = new Font("Monotype Corsiva",16, FontStyle.Italic);
                    label.AutoSize = true;
                    this.Controls.Add(label);
                    return;
                }

                var productsCounter = 1;
                var x = 30;
                var y = 60;
                foreach (var product in products)
                {
                    if (productsCounter == 4)
                    {
                        productsCounter = 1;
                        x = 30;
                        y += 350;
                    }

                    if (productsCounter == 2 || productsCounter == 3)
                    {
                        x += 350;
                    }
                    Image image;
                    using (MemoryStream ms = new MemoryStream(product.ProductImage))
                    {
                        image = Image.FromStream(ms);
                    }

                    var pictureBox = new PictureBox();
                    pictureBox.Image = image;

                    pictureBox.Location = new Point(x, y);
                    pictureBox.Tag = product;
                    pictureBox.Size = new Size(250, 250);
                    pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                    pictureBox.BorderStyle = BorderStyle.Fixed3D;
                    pictureBox.Click += new EventHandler(this.pictureBox_click);
                    this.Controls.Add(pictureBox);

                    var label = new Label();
                    label.Text = product.Name;
                    label.Font = new Font("Monotype Corsiva", 12, FontStyle.Italic);
                    label.Location = new Point(x, y - 20);
                    this.Controls.Add(label);

                    productsCounter++;
                }
            }
            this.BackgroundImageLayout = ImageLayout.Center;
            foreach (Label lbl in this.Controls.OfType<Label>())
            {
                lbl.BackColor = Color.Transparent;
            }
        }

        private void pictureBox_click(object sender, EventArgs e)
        {
            var pictureClicked = sender as PictureBox;
            var product = pictureClicked.Tag as Product;

            var productDetails = new ProductDetailsForm(product.ProductID);
            productDetails.ShowDialog();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            var orders = new OrderCategoriesForm();
            orders.Show();
            this.Hide();
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var oc = new OrderCategoriesForm();
            oc.Show();
        }

        private void shoppingCartButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new FinalizeOrderForm();
            form.Show();
        }
    }
}
