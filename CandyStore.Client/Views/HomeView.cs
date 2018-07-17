﻿using CandyStore.Client.Messages;
using CandyStore.Contracts.Client.Presenters;
using CandyStore.Contracts.Client.Services;
using CandyStore.Contracts.Client.Views;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CandyStore.Client.Views
{
    public partial class HomeView : Form, IHomeView
    {
        private readonly IViewService _viewService;

        public HomeView(IViewService viewService)
        {
            _viewService = viewService;

            InitializeComponent();
        }

        public IHomePresenter Presenter { get; set; }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void adminLoginButton_Click(object sender, EventArgs e)
        {
            var loginValidationResult = Presenter.LoginAdministrator(identificationNumberBox.Text);
            if (!loginValidationResult.Valid)
            {
                NotifyMessageBox.ShowError(string.Join(", ", loginValidationResult.ErrorMessages));
                return;
            }

            ClearTextBoxes();

            _viewService.ShowView<IAdminManagerView>(this);
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
            var loginValidationResult = Presenter.LoginCustomer(firstNameTextBox.Text, lastNameTextBox.Text);
            if (!loginValidationResult.Valid)
            {
                NotifyMessageBox.ShowError(string.Join(", ", loginValidationResult.ErrorMessages));
                return;
            }

            ClearTextBoxes();

            var categoriesForm = new CategoriesForm();
            categoriesForm.Show();
            this.Hide();
        }

        private void ClearTextBoxes()
        {
            identificationNumberBox.Text = string.Empty;
            firstNameTextBox.Text = string.Empty;
            lastNameTextBox.Text = string.Empty;
        }
    }
}
