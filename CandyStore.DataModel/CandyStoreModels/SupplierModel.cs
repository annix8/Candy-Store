using System.Collections.Generic;

namespace CandyStore.DataModel.CandyStoreModels
{
    public class SupplierModel
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public ProductModel[] Products { get; set; }
    }
}
