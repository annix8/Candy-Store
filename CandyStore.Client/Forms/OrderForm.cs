using CandyStore.Client.OrderServiceProxy;
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
        private readonly OrderServiceSoapClient _orderService;

        public OrderForm()
        {
            InitializeComponent();

            CandyStoreUtil.MakeLabelsTransparent(this);

            CandyStoreUtil.SetAutoCompleteOnComboBoxes(this);
            CandyStoreUtil.MakeLabelsTransparent(this);

            _orderService = new OrderServiceSoapClient();
            _productsBySupplierHash = new Dictionary<SupplierDto, List<ProductDto>>();

        }

        private void productsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
        }

        private void suppliersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var supplierDto = suppliersComboBox.SelectedValue as SupplierDto;

            var supplier = _productsBySupplierHash
                .FirstOrDefault(x => x.Key.Name == supplierDto.Name);

            suppliersAddress.Text = supplier.Key.Address;
            suppliersPhone.Text = supplier.Key.PhoneNumber;

            foreach (var comboBox in this.Controls.OfType<ComboBox>().Where(cb => cb.Name.StartsWith("products")))
            {
                comboBox.SelectedIndex = -1;
            }

            foreach (var textBox in this.Controls.OfType<TextBox>().Where(cb => cb.Name.StartsWith("quantity")))
            {
                textBox.Text = "";
            }
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
    }
}
