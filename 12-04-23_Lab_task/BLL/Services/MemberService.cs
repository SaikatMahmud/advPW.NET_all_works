using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    internal class MemberService
    {
        public static List<MemberDTO> Get()
        {
            var data = DataAccessFactory.MemberData().Get();
            return Convert(data);
        }
        public static MemberDTO Get(int id)
        {
            return Convert(DataAccessFactory.MemberData().Get(id));
        }
        public static bool Insert(MemberDTO member)
        {
            var data = Convert(member);
            var res = DataAccessFactory.MemberData().Insert(data);

            if (res != null) return true;
            return false;
        }
        public static bool Update(MemberDTO member)
        {
            var data = Convert(member);
            var res = DataAccessFactory.MemberData().Update(data);

            if (res != null) return true;
            return false;
        }


        static List<MemberDTO> Convert(List<Member> members)
        {
            var data = new List<MemberDTO>();
            foreach (var member in members)
            {
                data.Add(new MemberDTO()
                {
                    Id = member.Id,
                    Role= member.Role,
                    Name = member.Name,
                    Project_Id = member.Project_Id
                });
            }
            return data;

        }
        static Member Convert(MemberDTO member)
        {
            return new Member()
            {
                Id = member.Id,
                Role = member.Role,
                Name = member.Name,
                Project_Id = member.Project_Id
            };
        }
        static MemberDTO Convert(Member member)
        {
            return new MemberDTO()
            {
                Id = member.Id,
                Role = member.Role,
                Name = member.Name,
                Project_Id = member.Project_Id
            };
        }
    }
}
