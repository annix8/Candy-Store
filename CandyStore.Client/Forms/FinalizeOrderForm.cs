using CandyStore.Client.Cache;
using CandyStore.Client.DTOs;
using CandyStore.Client.Messages;
using CandyStore.Client.Prompt;
using CandyStore.DataModel;
using CandyStore.DataModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CandyStore.Client.Forms
{
    public partial class FinalizeOrderForm : Form
    {
        private double _totalPrice = 0;
        private int _selectedRowIndex = 0;

        public FinalizeOrderForm()
        {
            InitializeComponent();
            dataGridView1.ReadOnly = true;

            if (Session.Products != null)
            {
                foreach (var item in Session.Products)
                {
                    double currentProductPrice = item.Key.Price * item.Value;
                    _totalPrice += currentProductPrice;
                }
            }

            this.WindowState = FormWindowState.Maximized;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var categoriesForm = new CategoriesForm();
            categoriesForm.Show();
        }

        private void FinalizeOrderForm_Load(object sender, EventArgs e)
        {
            LoadDatagridView();
            foreach (Label lbl in this.Controls.OfType<Label>())
            {
                lbl.BackColor = Color.Transparent;
            }
        }

        private void LoadDatagridView()
        {
            totalPriceLabel.Text = _totalPrice.ToString("0.00" + "$");
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
            dataGridView1.DataSource = productdtoList;
            dataGridView1.ClearSelection();

            if (productdtoList.Count > 0) dataGridView1.Rows[_selectedRowIndex].Selected = true;
        }

        private string GetProductCategory(int productID)
        {
            var categoryName = "";
            using (var context = new CandyStoreDbContext())
            {
                categoryName = context.Products.FirstOrDefault(p => p.ProductID == productID).Category.Name;
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
            this.Hide();
            var orderForm = new OrderReceiptForm(createdOrderID, _totalPrice);
            orderForm.Show();
        }

        private int CreateOrder()
        {
            var orderID = 0;

            var order = new Order()
            {
                Customer = new Customer { FirstName = Session.FirstName, LastName = Session.LastName },
                Date = DateTime.Now,
                TotalPrice = _totalPrice
            };

            using (var context = new CandyStoreDbContext())
            {
                try
                {
                    context.Orders.Add(order);
                    context.SaveChanges();
                    orderID = order.OrderID;
                }
                catch (Exception ex)
                {
                    Logger.ShowError(ex.Message);
                    return -1;
                }

                return orderID;
            }
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            var rowsSelected = dataGridView1.SelectedRows;
            if (rowsSelected.Count > 1 || rowsSelected.Count < 1)
            {
                Logger.ShowWarning("Only 1 row can be edited!");
                return;
            }
            var productName = GetSelectedRowProductQuantity();
            var product = Session.Products.FirstOrDefault(x => x.Key.Name == productName).Key;

            var result = CheckProductInDatabase(product.ProductID, "plus");
            if (!result)
            {
                Logger.ShowWarning("There are no more products on stock");
                return;
            }

            Session.Products[product] += 1;
            _totalPrice += product.Price;
            LoadDatagridView();
        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            var rowsSelected = dataGridView1.SelectedRows;
            if (rowsSelected.Count > 1 || rowsSelected.Count < 1)
            {
                Logger.ShowWarning("Only 1 row can be edited!");
                return;
            }
            var productName = GetSelectedRowProductQuantity();

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
            using (var context = new CandyStoreDbContext())
            {
                var productFromDB = context.Products.FirstOrDefault(p => p.ProductID == productID);
                var productFromDbCount = productFromDB.Count;

                switch (operation)
                {
                    case "plus":
                        {
                            productFromDbCount -= 1;
                            if (productFromDbCount < 0)
                            {
                                return false;
                            }
                            productFromDB.Count = productFromDbCount;
                        }
                        break;
                    case "minus":
                        {
                            productFromDbCount += 1;
                            productFromDB.Count = productFromDbCount;
                        }
                        break;
                }
                context.SaveChanges();
            }

            return true;
        }

        private string GetSelectedRowProductQuantity()
        {
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            _selectedRowIndex = selectedrowindex;
            string productName = Convert.ToString(selectedRow.Cells["ProductName"].Value);

            return productName;
        }
    }
}
