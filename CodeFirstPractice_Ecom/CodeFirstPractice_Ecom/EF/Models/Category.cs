using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstPractice_Ecom.EF.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CatName { get; set; }
       // [ForeignKey("CatId")] // can be declared here. but not good
        public virtual ICollection<Product> Products { get; set; }
        public Category()
        {
            Products = new List<Product>();
        }
    }
}