using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public int Project_Id { get; set; }
        [ForeignKey("Project_Id")]
        public virtual Project Project { get; set; }
    }
}
