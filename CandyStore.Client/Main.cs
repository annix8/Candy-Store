﻿using CandyStore.Client.Cache;
using CandyStore.Client.Forms;
using CandyStore.Client.Messages;
using CandyStore.Infrastructure;
using CandyStore.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CandyStore.Contracts.Infrastructure;
using CandyStore.Infrastructure.Repositories;

namespace CandyStore.Client
{
    public partial class Main : Form
    {
        private readonly ICandyStoreRepository _candyStoreRepository;

        public Main()
        {
            // TODO: (04.June.2018) - use dependency injection
            _candyStoreRepository = new CandyStoreRepository();

            InitializeComponent();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void adminLoginButton_Click(object sender, EventArgs e)
        {
            int identificationNumber;
            var parsed = int.TryParse(identificationNumberBox.Text, out identificationNumber);
            if (!parsed)
            {
                MessageForm.ShowError("Enter a correct whole number value.");
                return;
            }

            var user = _candyStoreRepository.GetAll<Employee>()
                .FirstOrDefault(u => u.IdentificationNumber == identificationNumber);

            if (user == null)
            {
                MessageForm.ShowError("There is no such employee");
                return;
            }

            ClearTextBoxes();

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
            if (string.IsNullOrEmpty(firstNameTextBox.Text) || string.IsNullOrEmpty(lastNameTextBox.Text))
            {
                MessageForm.ShowError("Some of the values are empty");
                return;
            }

            Session.FirstName = firstNameTextBox.Text;
            Session.LastName = lastNameTextBox.Text;
            Session.Products = new Dictionary<Product, int>();

            ClearTextBoxes();

            var categoriesForm = new CategoriesForm();
            categoriesForm.Show();
            this.Hide();
        }

        private void ClearTextBoxes()
        {
            identificationNumberBox.Text = "";
            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
        }
    }
}
