using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models

{
    public class News
    {
        public int Id {get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CId { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("CId")]
        public virtual Category Category { get; set; }
    }
}
