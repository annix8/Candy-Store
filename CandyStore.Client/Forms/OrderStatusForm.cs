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

        private async void OrderStatusForm_Load(object sender, EventArgs e)
        {
            var response = await _orderService.GetOrdersByCustomerAsync(Constants.Customer);
            _orders = response.Body.GetOrdersByCustomerResult.
                OrderByDescending(x => x.OrderedDate)
                .ToList();

            InitializeOrdersGridView();
        }

        private void InitializeOrdersGridView()
        {
            ordersGridView.DataSource = _orders;
            ordersGridView.ClearSelection();
        }

        private void ordersGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedOrder = ordersGridView.SelectedRows[0].DataBoundItem as OrderDto;

            productsGridView.ClearSelection();
            productsGridView.DataSource = selectedOrder.Products;

            var totalPrice = selectedOrder.Products.Sum(x => x.Price * x.Quantity);
            totalPriceLbl.Text = $"${totalPrice}";
        }

        private void searchSuppliersTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
                var found = _orders.Where(x => x.Supplier.ToLower().Contains(searchSuppliersTextBox.Text.ToLower()))
                    .ToList();
                ordersGridView.DataSource = found;
        }
    }
}
