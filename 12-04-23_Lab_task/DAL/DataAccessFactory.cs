using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Project, int, Project> ProjectData()
        {
            return new ProjectRepo();
        }
        public static IRepo<Member, int, Member> MemberData()
        {
            return new MemberRepo();
        }
    }
}
