using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirstPractice_Ecom.EF.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public float Amount { get; set; }
        public int CusId { get; set; }
        [ForeignKey("CusId")]
        public virtual Customer Customer { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
        public Order()
        {
            ProductOrders = new List<ProductOrder>();
        }

    }
}