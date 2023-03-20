using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZeroHunger_Asg.EF.Models
{
    public class Food
    {
        public int Id { get; set; }
        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }
        public DateTime RequestTime { get; set; }
        public string FoodType { get; set; }
        public string Quantity { get; set; }
        public string Status { get; set; }
        public int PreserveTime { get; set; }
        public string DistributedOn { get; set; }
        public DateTime? DistributeTime { get; set; }
        [ForeignKey("CollectionStaff")]
        public int? CollectionStaffId { get; set; }
        [ForeignKey("DistributeStaff")]
        public int? DistributeStaffId { get; set; }
        public virtual User CollectionStaff { get; set; }
        public virtual User DistributeStaff { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}