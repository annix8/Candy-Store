using CandyStore.Client.Properties;
using CandyStore.Client.Util;
using CandyStore.Contracts.Client.Services;
using CandyStore.Contracts.Client.Views;
using System;
using System.Drawing;

namespace CandyStore.Client.Views
{
    public partial class AdminManagerView : BaseView, IAdminManagerView
    {
        private readonly IViewService _viewService;

        public AdminManagerView(IViewService viewService)
        {
            _viewService = viewService;

            InitializeComponent();

            CandyStoreUtil.MakeLabelsTransparent(this);
        }

        private void inventoryPanelBtn_Click(object sender, EventArgs e)
        {
            _viewService.ShowDialogView<IAdminPanelView>();
        }

        private void makeOrderBtn_Click(object sender, EventArgs e)
        {
            _viewService.ShowDialogView<IOrderView>();
        }

        private void ordersBtn_Click(object sender, EventArgs e)
        {
            _viewService.ShowDialogView<IOrderStatusView>();
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
            _viewService.ShowView<IHomeView>(this);
        }
    }
}
