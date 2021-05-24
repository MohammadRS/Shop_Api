using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop_Api.Entity
{
    public class Products
    {
        [Key]
        public int ProductId { get; private set; }
        public string ProductName { get; private set; }
        public long Size { get; private set; }
        public string Varienty { get; private set; }
        public string Price { get; private set; }
        public string Status { get; private set; }

        public virtual List<OrderItems> OrderItems { get; set; }
    }
}
