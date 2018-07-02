using CandyStore.Client.Properties;
using CandyStore.Client.Util;
using CandyStore.Client.Views;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CandyStore.Client.Forms
{
    public partial class AdminManagerForm : Form
    {
        Image _inventoryImage = Resources.inventory;
        Image _orderImage = Resources.order;
        Image _ordersImage = Resources.list;

        public AdminManagerForm()
        {
            InitializeComponent();

            CandyStoreUtil.MakeLabelsTransparent(this);
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

            inventoryPictureBox.Image = _inventoryImage;
            makeOrderPictureBox.Image = _orderImage;
            ordersPictureBox.Image = _ordersImage;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            var mainForm = CandyStoreUtil.GetFormOfType<HomeView>();
            mainForm.Show();
            this.Hide();
        }
    }
}
