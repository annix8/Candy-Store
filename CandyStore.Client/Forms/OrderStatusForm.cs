using CandyStore.Client.Messages;
using CandyStore.Client.OrderServiceProxy;
using CandyStore.Client.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CandyStore.Client.Forms
{
    public partial class OrderStatusForm : Form
    {
        private readonly OrderServiceSoapClient _orderService;
        private List<OrderDto> _orders;

        public OrderStatusForm()
        {
            InitializeComponent();

            CandyStoreUtil.MakeLabelsTransparent(this);

            _orderService = new OrderServiceSoapClient();
            _orders = new List<OrderDto>();
        }

        private void OrderStatusForm_Load(object sender, EventArgs e)
        {
            InitializeOrdersGridView();
        }

        private async void InitializeOrdersGridView()
        {
            var response = await _orderService.GetOrdersByCustomerAsync(Constants.Customer);
            _orders = response.Body.GetOrdersByCustomerResult.
                OrderByDescending(x => x.OrderedDate)
                .ToList();

            ordersGridView.ClearSelection();
            ordersGridView.DataSource = _orders;
            ordersGridView.Columns[nameof(OrderDto.OrderId)].Visible = false;
        }

        private void searchSuppliersTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var found = _orders.Where(x => x.Supplier.ToLower().Contains(searchSuppliersTextBox.Text.ToLower()))
                .ToList();
            ordersGridView.DataSource = found;
        }

        private async void closeOrderButton_Click(object sender, EventArgs e)
        {
            var selectedOrder = ordersGridView.SelectedRows[0].DataBoundItem as OrderDto;

            if (selectedOrder == null)
            {
                NotifyMessageBox.ShowError("No orders selected.");
                return;
            }

            var result = PromptMessage.ConfirmationMessage("Are you sure you want to close this order");
            if (!result)
            {
                return;
            }

            await _orderService.CloseOrderAsync(selectedOrder.OrderId);
            NotifyMessageBox.ShowSuccess("Order close successfully.");
            InitializeOrdersGridView();
        }

        private void ordersGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedOrder = ordersGridView.SelectedRows[0].DataBoundItem as OrderDto;

            productsGridView.ClearSelection();
            productsGridView.DataSource = selectedOrder.Products;
            productsGridView.Columns[nameof(ProductDto.Id)].Visible = false;

            var totalPrice = selectedOrder.Products.Sum(x => x.Price * x.Quantity);
            totalPriceLbl.Text = $"${totalPrice}";

            if (selectedOrder.Status == "Closed")
            {
                closeOrderButton.Enabled = false;
            }
            else
            {
                closeOrderButton.Enabled = true;
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
