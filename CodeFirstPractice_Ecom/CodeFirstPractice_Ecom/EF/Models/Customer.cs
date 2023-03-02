using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstPractice_Ecom.EF.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public Customer()
        {
            Orders = new List<Order>();
        }
    }
}