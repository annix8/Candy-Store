using CandyStore.Client.Util;
using CandyStore.Contracts.Client.Presenters;
using CandyStore.Contracts.Client.Services;
using CandyStore.Contracts.Client.Views;
using System;
using System.Windows.Forms;

namespace CandyStore.Client.Views
{
    public partial class ReceiptView : BaseView, IReceiptView
    {
        private readonly IViewService _viewService;

        public ReceiptView(IReceiptPresenter receiptPresenter, IViewService viewService)
        {
            Presenter = receiptPresenter;
            Presenter.View = this;

            _viewService = viewService;

            InitializeComponent();
            receiptTextBox.SelectionAlignment = HorizontalAlignment.Center;

            CandyStoreUtil.MakeLabelsTransparent(this);
        }

        public IReceiptPresenter Presenter { get; set; }

        public int OrderId { get; set; }


        private void nextCustomerButton_Click(object sender, EventArgs e)
        {
            _viewService.ShowView<IHomeView>(this);
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            receiptTextBox.ReadOnly = true;
            receiptTextBox.Text = Presenter.GetReceiptText();
        }
    }
}
