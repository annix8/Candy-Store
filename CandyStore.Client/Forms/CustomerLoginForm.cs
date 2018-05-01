using CandyStore.Client.Cache;
using CandyStore.Client.Forms;
using CandyStore.Client.Messages;
using CandyStore.DataModel;
using CandyStore.DataModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CandyStore.Client
{
    public partial class CustomerLoginForm : Form
    {
        public CustomerLoginForm()
        {
            InitializeComponent();
        }

        private void adminButton_Click(object sender, EventArgs e)
        {
            var adminLoginForm = new AdminLoginForm();
            adminLoginForm.Show();
            this.Hide();
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            if(firstNameBox.Text == "" || lastNameBox.Text == "")
            {
                Logger.ShowError("Some of the values are empty");
                return;
            }
            Session.FirstName = firstNameBox.Text;
            Session.LastName = lastNameBox.Text;
            Session.Products = new Dictionary<Product, int>();

            var orderForm = new OrderCategoriesForm();
            orderForm.Show();
            this.Hide();
            var openedStartupForm = Application.OpenForms.OfType<StartupForm>().FirstOrDefault();
            openedStartupForm?.Hide();
        }

        private void exitAppButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            firstnameLabel.BackColor = Color.Transparent;
            lastnameLabel.BackColor = Color.Transparent;
        }
    }
}
