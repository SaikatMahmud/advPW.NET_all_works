using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstPractice_Ecom.EF.Models
{
    public class Order
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public int CusId { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
        public Order()
        {
            ProductOrders = new List<ProductOrder>();
        }
        public virtual Customer Customer { get; set; }
    }
}