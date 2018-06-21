using CandyStore.Client.Cache;
using CandyStore.Client.DTOs;
using CandyStore.Client.Messages;
using CandyStore.Client.Prompt;
using CandyStore.Client.Util;
using CandyStore.Contracts.Infrastructure;
using CandyStore.DataModel.Models;
using CandyStore.Infrastructure;
using CandyStore.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CandyStore.Client.Forms
{
    public partial class ShoppingCartForm : Form
    {
        private readonly ICandyStoreRepository _candyStoreRepository;

        private double _totalPrice = 0;
        private int _selectedRowIndex = 0;

        public ShoppingCartForm()
        {
            // TODO: (04.June.2018) - use dependency injection
            _candyStoreRepository = new CandyStoreRepository();

            InitializeComponent();

            CandyStoreUtil.MakeLabelsTransparent(this);

            _totalPrice = Session.Products.Sum(x => x.Key.Price * x.Value);
        }

        private void ShoppingCartForm_Load(object sender, EventArgs e)
        {
            LoadDatagridView();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var categoriesForm = new CategoriesForm();
            categoriesForm.Show();
        }

        private void LoadDatagridView()
        {
            totalPriceLabel.Text = $"${_totalPrice:f2}";
            var productdtoList = new List<ProductDTO>();

            if (Session.Products != null)
            {
                foreach (var product in Session.Products)
                {
                    var newProductDTO = new ProductDTO();
                    //TODO: think of a way to make this more efficient by not accessing the db on each iteration
                    var categoryName = GetProductCategory(product.Key.ProductID);
                    newProductDTO.ProductCategory = categoryName;
                    newProductDTO.ProductName = product.Key.Name;
                    newProductDTO.ProductPrice = product.Key.Price;
                    newProductDTO.ProductQuantity = product.Value;
                    productdtoList.Add(newProductDTO);
                }
            }
            productsGridView.DataSource = productdtoList;
            productsGridView.ClearSelection();

            if (productdtoList.Count > 0) productsGridView.Rows[_selectedRowIndex].Selected = true;
        }

        private string GetProductCategory(int productID)
        {
            var categoryName = "";
            using (var context = new CandyStoreDbContext())
            {
                categoryName = context.Products
                    .FirstOrDefault(p => p.ProductID == productID).Category.Name;
            }

            return categoryName;
        }

        private void submitOrderButton_Click(object sender, EventArgs e)
        {
            var createdOrderID = CreateOrder();
            if (createdOrderID == -1)
            {
                return;
            }

            foreach (var product in Session.Products)
            {
                var productInDb = _candyStoreRepository.GetAll<Product>()
                    .FirstOrDefault(p => p.ProductID == product.Key.ProductID);

                productInDb.Count -= product.Value;
                _candyStoreRepository.Update(productInDb);
            }

            this.Hide();
            var receiptForm = new ReceiptForm();
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
                MessageForm.ShowError(ex.Message);
                return -1;
            }
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            var rowsSelected = productsGridView.SelectedRows;
            if (rowsSelected.Count != 1)
            {
                MessageForm.ShowWarning("Only 1 row can be edited!");
                return;
            }
            var productName = GetSelectedRowProductName();
            var product = Session.Products.FirstOrDefault(x => x.Key.Name == productName).Key;

            var result = CheckProductInDatabase(product.ProductID, "plus");
            if (!result)
            {
                MessageForm.ShowWarning("There are no more products on stock");
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
                MessageForm.ShowWarning("Only 1 row can be edited!");
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
