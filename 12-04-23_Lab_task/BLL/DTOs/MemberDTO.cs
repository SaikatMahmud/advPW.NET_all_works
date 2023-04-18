using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class MemberDTO
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public int Project_Id { get; set; }
    }
}
