using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ZeroHunger_Asg.EF.Models;

namespace ZeroHunger_Asg.EF
{
    public class ZeroHungerDb : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Staff> Staffs { get; set; }
    }
}