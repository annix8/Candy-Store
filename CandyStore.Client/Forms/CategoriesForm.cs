using CandyStore.Client.Cache;
using CandyStore.DataModel;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CandyStore.Client.Forms
{
    public partial class CategoriesForm : Form
    {
        public CategoriesForm()
        {
            InitializeComponent();
        }

        private void CategoriesForm_Load(object sender, EventArgs e)
        {
            using (var ctx = new CandyStoreDbContext())
            {
                var categories = ctx.Categories.ToList();

                categoriesList.ValueMember = "CategoryID";
                categoriesList.DisplayMember = "Name";
                categoriesList.DataSource = categories;
            }
        }

        private void categoriesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var ctx = new CandyStoreDbContext())
            {
                var categoryId = int.Parse(categoriesList.SelectedValue.ToString());

                var categoryImage = ctx.Categories
                    .FirstOrDefault(c => c.CategoryID == categoryId)
                    .CategoryImage;

                Image image;
                using (MemoryStream ms = new MemoryStream(categoryImage))
                {
                    image = Image.FromStream(ms);
                }

                categoryPictureBox.Image = image;
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            var main = Application.OpenForms.OfType<Main>().FirstOrDefault();
            main.Show();
            Session.Clear();
            this.Hide();
        }

        private void shoppingCartBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var finalize = new FinalizeOrderForm();
            finalize.Show();
        }

        private void selectCategoryBtn_Click(object sender, EventArgs e)
        {
            var categoryId = int.Parse(categoriesList.SelectedValue.ToString());

            var productsForm = new OrderProductsForm(categoryId);
            productsForm.Show();
            this.Hide();
        }
    }
}
