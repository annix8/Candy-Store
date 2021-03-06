﻿using CandyStore.Client.Messages;
using CandyStore.Client.Util;
using CandyStore.Contracts.Client.Presenters;
using CandyStore.Contracts.Client.Services;
using CandyStore.Contracts.Client.Views;
using CandyStore.DataModel.CandyStoreModels;
using CandyStore.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CandyStore.Client.Views
{
    public partial class ShoppingCartView : BaseView, IShoppingCartView
    {
        private readonly IViewService _viewService;

        private double _totalPrice = 0;
        private int _selectedRowIndex = 0;

        public ShoppingCartView(IShoppingCartPresenter shoppingCartPresenter, IViewService viewService)
        {
            Presenter = shoppingCartPresenter;
            Presenter.View = this;

            _viewService = viewService;

            InitializeComponent();

            CandyStoreUtil.MakeLabelsTransparent(this);
        }

        public IShoppingCartPresenter Presenter { get; set; }

        public void UpdateTotalPrice(double priceQuantity)
        {
            _totalPrice += priceQuantity;
        }

        public bool ConfirmShoppingCartProductRemoval()
        {
            return PromptMessage.ConfirmationMessage("Are you sure you want to remove the selected product?");
        }

        private void ShoppingCartForm_Load(object sender, EventArgs e)
        {
            LoadDatagridView();
        }

        protected override void OnActivated(EventArgs e)
        {
            LoadDatagridView();
            base.OnActivated(e);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            _viewService.ShowView<ICategoriesView>(this);
        }

        private void LoadDatagridView()
        {
            _totalPrice = Presenter.GetTotalPriceOfProducts();
            totalPriceLabel.Text = $"${_totalPrice:f2}";
            var productsForDisplay = Presenter.GetProductsForDisplay();

            productsGridView.DataSource = productsForDisplay;
            productsGridView.ClearSelection();

            if (productsForDisplay.Count > 0)
            {
                _selectedRowIndex = _selectedRowIndex >= productsForDisplay.Count ? 0 : _selectedRowIndex;
                productsGridView.Rows[_selectedRowIndex].Selected = true;
            }
        }

        private void submitOrderButton_Click(object sender, EventArgs e)
        {
            var createdOrder = Presenter.CreateOrder();

            var values = new Dictionary<string, object>
            {
                { nameof(IReceiptView.OrderId), createdOrder.OrderID }
            };

            _viewService.ShowViewWithPropertyInjection<IReceiptView>(this, values);
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            var rowsSelected = productsGridView.SelectedRows;
            if (rowsSelected.Count != 1)
            {
                NotifyMessageBox.ShowWarning("Only 1 row can be edited!");
                return;
            }

            var result = Presenter.PerformProdcutQuantityChange(GetSelectedRowProductId(), Constants.PLUS_OPERATION);
            if (!result.Valid)
            {
                NotifyMessageBox.ShowWarning(result.GetAllErrorMessages());
                return;
            }

            var product = result.Object as Product;
            Presenter.UpdateProductQuantityInCart(product.ProductID, 1);
            LoadDatagridView();
        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            var rowsSelected = productsGridView.SelectedRows;
            if (rowsSelected.Count != 1)
            {
                NotifyMessageBox.ShowWarning("Only 1 row can be edited!");
                return;
            }

            var result = Presenter.PerformProdcutQuantityChange(GetSelectedRowProductId(), Constants.MINUS_OPERATION);
            if (!result.Valid)
            {
                NotifyMessageBox.ShowWarning(result.GetAllErrorMessages());
                return;
            }

            var product = result.Object as Product;
            LoadDatagridView();
        }

        private int GetSelectedRowProductId()
        {
            int selectedrowindex = productsGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = productsGridView.Rows[selectedrowindex];
            _selectedRowIndex = selectedrowindex;
            string productId = Convert.ToString(selectedRow.Cells[nameof(ShoppingCartProductViewModel.ProductId)].Value);

            return int.Parse(productId);
        }
    }
}
