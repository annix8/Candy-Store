using CandyStore.Client.Cache;
using CandyStore.Client.Messages;
using CandyStore.Client.Util;
using CandyStore.Contracts.Client.Presenters;
using CandyStore.Contracts.Client.Services;
using CandyStore.Contracts.Client.Views;
using CandyStore.Contracts.Infrastructure;
using CandyStore.DataModel.Models;
using CandyStore.Infrastructure.Repositories;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CandyStore.Client.Views
{
    public partial class ShoppingCartView : BaseView, IShoppingCartView
    {
        private readonly IViewService _viewService;
        private readonly ICandyStoreRepository _candyStoreRepository;

        private double _totalPrice = 0;
        private int _selectedRowIndex = 0;

        public ShoppingCartView(IShoppingCartPresenter shoppingCartPresenter, IViewService viewService)
        {
            Presenter = shoppingCartPresenter;
            Presenter.View = this;

            _viewService = viewService;
            // TODO: (04.June.2018) - use dependency injection
            _candyStoreRepository = new CandyStoreRepository(new Infrastructure.CandyStoreDbContext());

            InitializeComponent();

            CandyStoreUtil.MakeLabelsTransparent(this);

            _totalPrice = Presenter.GetTotalPriceOfProducts();
        }

        public IShoppingCartPresenter Presenter { get; set; }

        private void ShoppingCartForm_Load(object sender, EventArgs e)
        {
            LoadDatagridView();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            _viewService.ShowView<ICategoriesView>(this);
        }

        private void LoadDatagridView()
        {
            totalPriceLabel.Text = $"${_totalPrice:f2}";
            var productsForDisplay = Presenter.GetProductsForDisplay();

            productsGridView.DataSource = productsForDisplay;
            productsGridView.ClearSelection();

            if (productsForDisplay.Count > 0) productsGridView.Rows[_selectedRowIndex].Selected = true;
        }

        private void submitOrderButton_Click(object sender, EventArgs e)
        {
            var createdOrderID = CreateOrder();
            if (createdOrderID == -1)
            {
                return;
            }

            var productsInDb = from product in Session.Products
                               join dbProduct in _candyStoreRepository.GetAll<Product>()
                               on product.Key.ProductID equals dbProduct.ProductID
                               select new Product
                               {
                                   ProductID = dbProduct.ProductID,
                                   Count = dbProduct.Count - product.Value
                               };

            _candyStoreRepository.UpdateRange(productsInDb);

            //foreach (var product in Session.Products)
            //{
            //    var productInDb = _candyStoreRepository.GetAll<Product>()
            //        .FirstOrDefault(p => p.ProductID == product.Key.ProductID);

            //    productInDb.Count -= product.Value;
            //    _candyStoreRepository.Update(productInDb);
            //}

            this.Hide();
            var receiptForm = new ReceiptView();
            receiptForm.OrderId = createdOrderID;
            receiptForm.TotalPrice = _totalPrice;
            receiptForm.Show();
        }

        private int CreateOrder()
        {
            var order = new Order()
            {
                Customer = new Customer { FirstName = Session.FirstName, LastName = Session.LastName },
                Date = DateTime.Now,
                TotalPrice = _totalPrice
            };

            try
            {
                var insertedOrder = _candyStoreRepository.Insert(order);
                return insertedOrder.OrderID;
            }
            catch (Exception ex)
            {
                NotifyMessageBox.ShowError(ex.Message);
                return -1;
            }
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            var rowsSelected = productsGridView.SelectedRows;
            if (rowsSelected.Count != 1)
            {
                NotifyMessageBox.ShowWarning("Only 1 row can be edited!");
                return;
            }
            var productName = GetSelectedRowProductName();
            var product = Session.Products.FirstOrDefault(x => x.Key.Name == productName).Key;

            var result = CheckProductInDatabase(product.ProductID, "plus");
            if (!result)
            {
                NotifyMessageBox.ShowWarning("There are no more products on stock");
                return;
            }

            Session.Products[product] += 1;
            _totalPrice += product.Price;
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
            var productName = GetSelectedRowProductName();

            var product = Session.Products.FirstOrDefault(x => x.Key.Name == productName).Key;

            Session.Products[product] -= 1;
            _totalPrice -= product.Price;

            if (Session.Products[product] < 0)
            {
                Session.Products[product] = 0;
                _totalPrice += product.Price;
                var result = PromptMessage.ConfirmationMessage("Are you sure you want to remove the selected product?");
                if (result)
                {
                    Session.Products.Remove(product);
                }
            }
            else
            {
                var resultFromDb = CheckProductInDatabase(product.ProductID, "minus");
            }

            LoadDatagridView();
        }

        private bool CheckProductInDatabase(int productID, string operation)
        {
            var productFromDB = _candyStoreRepository.GetAll<Product>().FirstOrDefault(p => p.ProductID == productID);
            var productQuantityFromSession = Session.Products.FirstOrDefault(p => p.Key.ProductID == productFromDB.ProductID).Value;
            var productCount = productFromDB.Count - productQuantityFromSession;

            if (operation == "plus" && productCount - 1 < 0)
            {
                return false;
            }

            return true;
        }

        private string GetSelectedRowProductName()
        {
            int selectedrowindex = productsGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = productsGridView.Rows[selectedrowindex];
            _selectedRowIndex = selectedrowindex;
            string productName = Convert.ToString(selectedRow.Cells["ProductName"].Value);

            return productName;
        }
    }
}
