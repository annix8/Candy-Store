using CandyStore.Client.Cache;
using CandyStore.Client.Services;
using CandyStore.Client.Util;
using CandyStore.Contracts.Client.Views;
using System;
using System.Windows.Forms;

namespace CandyStore.Client.Views
{
    public partial class ReceiptView : BaseView, IReceiptView
    {
        private double _totalPrice;
        private int _orderID;
        public ReceiptView()
        {
            InitializeComponent();
            receiptTextBox.SelectionAlignment = HorizontalAlignment.Center;

            CandyStoreUtil.MakeLabelsTransparent(this);
        }

        public double TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }

        public int OrderId
        {
            get { return _orderID; }
            set { _orderID = value; }
        }

        private void nextCustomerButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            new ViewService(new SimpleInjector.Container()).ShowView<IHomeView>((IView)this);
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            receiptTextBox.Text += "Candy Store Receipt\n";
            receiptTextBox.Text += "\n";
            receiptTextBox.Text += "Order: " + _orderID.ToString() + "\n";

            foreach (var item in Session.Products)
            {
                string currentLine = $"{item.Key.Name}  ${item.Key.Price:f2} x {item.Value}    ${item.Value * item.Key.Price:f2}" + "\n";
                receiptTextBox.Text += currentLine;
            }

            receiptTextBox.Text += "\nTotal price: " + _totalPrice.ToString("0.00" + "$") + "\n";
            receiptTextBox.ReadOnly = true;

            receiptTextBox.Text += $"\nCustomer: {Session.FirstName} {Session.LastName}\n";
            receiptTextBox.Text += $"\nDate: {DateTime.Now}";
        }
    }
}
