using CandyStore.Client.Cache;
using CandyStore.Client.Forms;
using CandyStore.Client.Messages;
using CandyStore.Contracts.Client.Views;
using CandyStore.Contracts.Infrastructure;
using CandyStore.DataModel.Models;
using CandyStore.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CandyStore.Contracts.Client.Presenters;

namespace CandyStore.Client.Views
{
    public partial class HomeView : Form, IHomeView
    {
        public IHomePresenter Presenter { get; set; }

        public HomeView()
        {
            InitializeComponent();
        }

        public void ClearTextBoxes()
        {
            identificationNumberBox.Text = "";
            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void adminLoginButton_Click(object sender, EventArgs e)
        {
            if (!Presenter.LoginAdministrator(identificationNumberBox.Text))
            {
                return;
            }

            var adminManagerForm = new AdminManagerForm();
            adminManagerForm.Show();
            this.Hide();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            customerGroupBox.BackColor = Color.Transparent;
            adminGroupBox.BackColor = Color.Transparent;

            firstnameLabel.BackColor = Color.Transparent;
            lastnameLabel.BackColor = Color.Transparent;
        }

        private void customerContinueBtn_Click(object sender, EventArgs e)
        {
            if(!Presenter.LoginCustomer(firstNameTextBox.Text, lastNameTextBox.Text))
            {
                return;
            }

            var categoriesForm = new CategoriesForm();
            categoriesForm.Show();
            this.Hide();
        }
    }
}
