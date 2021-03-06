﻿using Orders.Infrastructure;
using Orders.Infrastructure.DTO;
using System.Collections.Generic;
using System.Web.Services;

namespace Orders.WebServices
{
    /// <summary>
    /// Summary description for OrderService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class OrderService : System.Web.Services.WebService
    {
        private readonly SupplierRepository _supplierRepo;
        private readonly OrderRepository _orderRepo;
        private readonly ProductRepository _productRepo;

        public OrderService()
        {
            _supplierRepo = new SupplierRepository();
            _orderRepo = new OrderRepository();
            _productRepo = new ProductRepository();
        }

        [WebMethod]
        public List<SupplierDto> GetAllSuppliers()
        {
            return new List<SupplierDto>(_supplierRepo.GetAll());
        }

        [WebMethod]
        public List<ProductDto> GetProductsBySupplier(string supplierName)
        {
            return new List<ProductDto>(_productRepo.GetBySupplier(supplierName));
        }

        [WebMethod]
        public List<OrderDto> GetOrdersByCustomer(CustomerDto customer)
        {
            return new List<OrderDto>(_orderRepo.GetByCustomer(customer.Name, customer.IdentificationNumber));
        }

        [WebMethod]
        public void PlaceOrder(CustomerDto customer, string supplierName, List<ProductDto> products)
        {
            _orderRepo.PlaceOrder(customer, supplierName, products);
        }

        [WebMethod]
        public void CloseOrder(int orderId)
        {
            _orderRepo.CloseOrder(orderId);
        }
    }
}
