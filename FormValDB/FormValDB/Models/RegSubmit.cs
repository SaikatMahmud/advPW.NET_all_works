using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormValDB.Models
{
    public class RegSubmit
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Id { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Profession { get; set; }
        [Required]
        public string[] Hobby { get; set; }
        [Required]
        public DateTime Dob { get; set; }
    }
}