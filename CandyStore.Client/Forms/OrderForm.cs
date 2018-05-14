using CandyStore.Client.Messages;
using CandyStore.Client.OrderServiceProxy;
using CandyStore.Client.Prompt;
using CandyStore.Client.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CandyStore.Client.Forms
{
    public partial class OrderForm : Form
    {
        private Dictionary<SupplierDto, List<ProductDto>> _productsBySupplierHash;
        private Dictionary<ComboBox, TextBox> _productsQuantityHash;
        private readonly OrderServiceSoapClient _orderService;

        public OrderForm()
        {
            InitializeComponent();
            InitializeProductsQuantityHash();

            CandyStoreUtil.SetAutoCompleteOnComboBoxes(this);
            CandyStoreUtil.MakeLabelsTransparent(this);

            _orderService = new OrderServiceSoapClient();
            _productsBySupplierHash = new Dictionary<SupplierDto, List<ProductDto>>();
        }

        private void productsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            var label = Controls.OfType<Label>().FirstOrDefault(l => l.Tag.ToString().Equals(comboBox.Name));
            var productDto = comboBox.SelectedValue as ProductDto;

            if (label == null || productDto == null)
            {
                return;
            }

            label.Text = $"${productDto.Price}";
        }

        private void suppliersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var supplierDto = suppliersComboBox.SelectedValue as SupplierDto;

            var supplier = _productsBySupplierHash
                .FirstOrDefault(x => x.Key.Name == supplierDto.Name);

            suppliersAddress.Text = supplier.Key.Address;
            suppliersPhone.Text = supplier.Key.PhoneNumber;

            ClearProductsQuantityAndPrice();
        }

        private void productsComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            var comboBox = sender as ComboBox;

            var supplierDto = suppliersComboBox.SelectedValue as SupplierDto;
            var suppliersProducts = _productsBySupplierHash
                .FirstOrDefault(x => x.Key.Name == supplierDto.Name)
                .Value;

            comboBox.DataSource = new List<ProductDto>(suppliersProducts);
            comboBox.DisplayMember = nameof(ProductDto.Name);
        }

        private async void OrderForm_Load(object sender, EventArgs e)
        {
            var suppliersResponse = await _orderService.GetAllSuppliersAsync();
            var suppliers = suppliersResponse.Body.GetAllSuppliersResult;

            foreach (var supplier in suppliers)
            {
                var suppliersProductsResponse = await _orderService.GetProductsBySupplierAsync(supplier.Name);
                var suppliersProducts = suppliersProductsResponse.Body.GetProductsBySupplierResult.ToList();

                if (!_productsBySupplierHash.ContainsKey(supplier))
                {
                    _productsBySupplierHash.Add(supplier, suppliersProducts);
                }
            }

            suppliersComboBox.DisplayMember = "Name";
            suppliersComboBox.DataSource = suppliers;
        }

        private async void submitOrderBtn_Click(object sender, EventArgs e)
        {
            var selectedProductBoxesAndQuantitiesHash = _productsQuantityHash
                .Where(x => x.Key.SelectedValue != null)
                .ToDictionary(x => x.Key, x => x.Value);

            if (!selectedProductBoxesAndQuantitiesHash.Any())
            {
                MessageForm.ShowWarning("No products selected.");
                return;
            }

            var selectedSupplierDto = suppliersComboBox.SelectedValue as SupplierDto;

            var products = new Dictionary<int, ProductDto>();
            foreach (var item in selectedProductBoxesAndQuantitiesHash)
            {
                var parsed = int.TryParse(item.Value.Text, out int quantity);
                if (!parsed || quantity < 1)
                {
                    MessageForm.ShowError("Quantity must be a whole positive number.");
                    return;
                }

                var currentProduct = item.Key.SelectedValue as ProductDto;
                if (!products.ContainsKey(currentProduct.Id))
                {
                    currentProduct.Quantity = quantity;
                    products.Add(currentProduct.Id, currentProduct);
                }
                else
                {
                    products[currentProduct.Id].Quantity += quantity;
                }
            }

            var totalPrice = products.Sum(x => x.Value.Price * x.Value.Quantity);
            var confirmation = PromptMessage.ConfirmationMessage($"Are you sure you want to order? Your total price is: ${totalPrice}");
            if (!confirmation)
            {
                return;
            }

            await _orderService.PlaceOrderAsync(Constants.Customer, selectedSupplierDto.Name, products.Values.ToArray());

            MessageForm.ShowSuccess("Order request sent.");
            ClearProductsQuantityAndPrice();
        }

        private void InitializeProductsQuantityHash()
        {
            _productsQuantityHash = new Dictionary<ComboBox, TextBox>()
            {
                [productsComboBox1] = quantityBox1,
                [productsComboBox2] = quantityBox2,
                [productsComboBox3] = quantityBox3,
                [productsComboBox4] = quantityBox4,
                [productsComboBox5] = quantityBox5,
                [productsComboBox6] = quantityBox6,
                [productsComboBox7] = quantityBox7,
                [productsComboBox8] = quantityBox8,
                [productsComboBox9] = quantityBox9,
                [productsComboBox10] = quantityBox10
            };
        }

        private void ClearProductsQuantityAndPrice()
        {
            foreach (var comboBox in this.Controls.OfType<ComboBox>().Where(cb => cb.Name.StartsWith("products")))
            {
                comboBox.SelectedIndex = -1;
            }

            foreach (var textBox in this.Controls.OfType<TextBox>().Where(cb => cb.Name.StartsWith("quantity")))
            {
                textBox.Text = "";
            }

            foreach (var label in Controls.OfType<Label>().Where(l => l.Tag != null))
            {
                label.Text = "$0";
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
