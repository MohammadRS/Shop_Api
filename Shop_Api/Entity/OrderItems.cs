using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop_Api.Entity
{
    public class OrderItems
    {
        [Key]
        public int OrderItemId { get; private set; }
        public int OrderId { get; private set; }
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }

        #region Relation
        [ForeignKey("OrderId")]
        public Orders Orders { get; set; }

        [ForeignKey("ProductId")]
        public Products Products { get; set; }
        #endregion
    }
}
