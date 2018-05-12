using System;
using System.Collections.Generic;

namespace Orders.Infrastructure.DTO
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public string Supplier { get; set; }
        public DateTime OrderedDate { get; set; }
        public DateTime ExpectedDate { get; set; }
        public string Status { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
