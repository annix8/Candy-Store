using CandyStore.Client.Messages;
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
        private Dictionary<string, List<ProductDto>> _productsBySupplierNameHash;
        private readonly OrderServiceSoapClient _orderService;

        public OrderForm()
        {
            InitializeComponent();

            CandyStoreUtil.SetAutoCompleteOnComboBoxes(this);
            CandyStoreUtil.MakeLabelsTransparent(this);

            _orderService = new OrderServiceSoapClient();
            _productsBySupplierHash = new Dictionary<SupplierDto, List<ProductDto>>();
            _productsBySupplierNameHash = new Dictionary<string, List<ProductDto>>();
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

        private void suppliersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            productsComboBox.SelectedIndex = -1;

            var supplierDto = suppliersComboBox.SelectedValue as SupplierDto;

            var supplier = _productsBySupplierHash
                .FirstOrDefault(x => x.Key.Name == supplierDto.Name);

            suppliersAddress.Text = supplier.Key.Address;
            suppliersPhone.Text = supplier.Key.PhoneNumber;

            productsComboBox.DisplayMember = "Name";
            productsComboBox.ValueMember = "Id";
            productsComboBox.DataSource = supplier.Value;
        }

        private void addProductBtn_Click(object sender, EventArgs e)
        {
            var parsed = int.TryParse(productQuantityBox.Text, out int productQuantity);

            if(!parsed || productQuantity < 1)
            {
                Logger.ShowError("Insert quantity value larger than 0.");
                return;
            }

            var supplierDto = suppliersComboBox.SelectedValue as SupplierDto;

            if (!_productsBySupplierNameHash.ContainsKey(supplierDto.Name))
            {
                _productsBySupplierNameHash.Add(supplierDto.Name, new List<ProductDto>());
            }

            var existingItem = _productsBySupplierNameHash[supplierDto.Name]
                .FirstOrDefault(x => x.Id == (int)productsComboBox.SelectedValue);

            if(existingItem == null)
            {
                var product = productsComboBox.SelectedItem as ProductDto;
                product.Quantity = int.Parse(productQuantityBox.Text);
                _productsBySupplierNameHash[supplierDto.Name].Add(product);
            }
            else
            {
                existingItem.Quantity += int.Parse(productQuantityBox.Text);
            }

            //TODO: add method for refreshing (initializing the datagrid)
        }
    }
}
