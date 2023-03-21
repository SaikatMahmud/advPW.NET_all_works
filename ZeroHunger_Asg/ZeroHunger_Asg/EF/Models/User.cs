using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHunger_Asg.EF.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<Food> Foods { get; set; }
        public User()
        {
            Foods = new List<Food>();
        }

    }
}