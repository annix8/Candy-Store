﻿using CandyStore.Client.Properties;
using CandyStore.Client.Services;
using CandyStore.Client.Util;
using CandyStore.Contracts.Client.Views;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CandyStore.Client.Views
{
    public partial class AdminManagerView : Form, IAdminManagerView
    {
        public AdminManagerView()
        {
            InitializeComponent();

            CandyStoreUtil.MakeLabelsTransparent(this);
        }

        public void ShowView()
        {
            Show();
        }

        private void inventoryPanelBtn_Click(object sender, EventArgs e)
        {
            var adminPanel = new AdminPanelForm();
            adminPanel.ShowDialog();
        }

        private void makeOrderBtn_Click(object sender, EventArgs e)
        {
            var orderForm = new OrderForm();
            orderForm.ShowDialog();
        }

        private void ordersBtn_Click(object sender, EventArgs e)
        {
            var orderStatusForm = new OrderStatusForm();
            orderStatusForm.ShowDialog();
        }

        private void AdminManagerForm_Load(object sender, EventArgs e)
        {
            inventoryPictureBox.BackColor = Color.Transparent;
            makeOrderPictureBox.BackColor = Color.Transparent;
            ordersPictureBox.BackColor = Color.Transparent;

            inventoryPictureBox.Image = Resources.inventory;
            makeOrderPictureBox.Image = Resources.order;
            ordersPictureBox.Image = Resources.list;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            new ViewService(new SimpleInjector.Container()).ShowView<IHomeView>(this);
            this.Hide();
        }
    }
}
