using CandyStore.Client.Cache;
using CandyStore.DataModel;
using CandyStore.DataModel.Models;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CandyStore.Client.Forms
{
    public partial class OrderCategoriesForm : Form
    {
        public OrderCategoriesForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void OrderCategoriesForm_Load(object sender, EventArgs e)
        {
            using (var context = new CandyStoreDbContext())
            {
                var categories = context.Categories.ToList();
                var categoriesCounter = 1;
                var x = 30;
                var y = 60;
                foreach (var category in categories)
                {
                    if (categoriesCounter == 4)
                    {
                        categoriesCounter = 1;
                        x = 30;
                        y += 350;
                    }

                    if (categoriesCounter == 2 || categoriesCounter == 3)
                    {
                        x += 350;
                    }
                    Image image;
                    using (MemoryStream ms = new MemoryStream(category.CategoryImage))
                    {
                        image = Image.FromStream(ms);
                    }

                    var pictureBox = new PictureBox();
                    pictureBox.Image = image;

                    pictureBox.Location = new Point(x, y);
                    pictureBox.Tag = category;
                    pictureBox.Size = new Size(250, 250);
                    pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                    pictureBox.BorderStyle = BorderStyle.Fixed3D;
                    pictureBox.Click += new EventHandler(this.pictureBox_click);
                    this.Controls.Add(pictureBox);

                    var label = new Label();
                    label.Text = category.Name;
                    label.Font = new Font("Monotype Corsiva", 12, FontStyle.Italic);
                    label.Location = new Point(x, y - 20);
                    this.Controls.Add(label);

                    categoriesCounter++;
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
            var picture = sender as PictureBox;
            var category = picture.Tag as Category;

            var productsForm = new OrderProductsForm(category.CategoryID);
            productsForm.Show();
            this.Hide();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            var main = Application.OpenForms.OfType<StartupForm>().FirstOrDefault();
            main.Show();
            Session.Clear();
            this.Hide();
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var finalize = new FinalizeOrderForm();
            finalize.Show();
        }
    }
}
