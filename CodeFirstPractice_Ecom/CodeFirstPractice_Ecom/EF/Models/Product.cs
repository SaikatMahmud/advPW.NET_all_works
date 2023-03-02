using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstPractice_Ecom.EF.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Qty { get; set; }
        public int CatId { get; set; }
        public virtual Category Category { get; set; } ////
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
        public Product()
        {
            ProductOrders = new List<ProductOrder>();
        }

    }
}