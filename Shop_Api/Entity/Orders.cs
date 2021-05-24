using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop_Api.Entity
{
    public class Orders
    {
        [Key]
        public int OrderId { get; private set; }
        public DateTime DateTime { get; private set; }
        public long Total { get; private set; }
        public string Status { get; private set; }
        public int CustomerId { get; private set; }
        public int SalesPersonId { get; private set; }


        #region Relation
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        [ForeignKey("SalesPersonId")]
        public SalesPersons SalesPersons { get; set; }

        public virtual List<OrderItems> OrderItems { get; set; }
        #endregion

    }
}
