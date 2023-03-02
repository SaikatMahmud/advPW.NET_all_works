using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirstPractice_Ecom.EF.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required,StringLength(50)]
        public string Name { get; set; }
        public float? Price { get; set; }
        public int Qty { get; set; }
      //  [ForeignKey("Category")] //can be done in 3 ways. better to use column name instead of nav prop.
        public int CatId { get; set; }
        [ForeignKey("CatId")] //good practice to use this
        public virtual Category Category { get; set; }


        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
        public Product()
        {
            ProductOrders = new List<ProductOrder>();
        }

    }
}