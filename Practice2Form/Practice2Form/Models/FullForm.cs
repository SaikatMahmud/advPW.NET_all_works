using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practice2Form.Models
{
    public class FullForm
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Id { get; set; }
        public string Gender { get; set; }
        public string Profession { get; set; }
        public string[] Hobby { get; set; }
        public DateTime Dob { get; set; }

    }
}