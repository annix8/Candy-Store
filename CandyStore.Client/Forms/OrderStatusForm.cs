using CandyStore.Client.OrderServiceProxy;
using CandyStore.Client.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CandyStore.Client.Forms
{
    public partial class OrderStatusForm : Form
    {
        private double _totalPrice = 0;
        private int _selectedRowIndex = 0;
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
            _orders = response.Body.GetOrdersByCustomerResult.ToList();

            InitializeOrdersGridView();
        }

        private void InitializeOrdersGridView()
        {
            ordersGridView.DataSource = _orders;

            ordersGridView.ClearSelection();

            if (_orders.Count > 0) ordersGridView.Rows[_selectedRowIndex].Selected = true;
        }

        private void ordersGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var selectedOrder = ordersGridView.SelectedRows[0].DataBoundItem as OrderDto;

            productsGridView.ClearSelection();
            productsGridView.DataSource = selectedOrder.Products;

            var totalPrice = selectedOrder.Products.Sum(x => x.Price * x.Quantity);
            totalPriceLbl.Text = $"${totalPrice}";
        }
    }
}
