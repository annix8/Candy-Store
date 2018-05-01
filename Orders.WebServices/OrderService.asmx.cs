using Orders.DataModel.Models;
using Orders.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public OrderService()
        {
            _supplierRepo = new SupplierRepository();
            _orderRepo = new OrderRepository();
        }

        [WebMethod]
        public List<Supplier> GetAllSuppliers()
        {
            return new List<Supplier>(_supplierRepo.GetAll());
        }

        [WebMethod]
        public List<Order> GetOrdersByCustomer(string customerName, string identificationNumber)
        {
            return new List<Order>(_orderRepo.GetByCustomer(customerName, identificationNumber));
        }
    }
}
