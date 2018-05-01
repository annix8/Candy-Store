using System.Collections.Generic;

namespace Orders.Infrastructure.DTO
{
    public class SupplierDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
