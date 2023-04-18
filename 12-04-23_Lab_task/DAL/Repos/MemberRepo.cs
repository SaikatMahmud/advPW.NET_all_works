using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class MemberRepo : Repo, IRepo<Member, int, Member>
    {
        public bool Delete(int id)
        {
            var exP = Get(id);
            db.Members.Remove(exP);
            return db.SaveChanges() > 0;
        }

        public List<Member> Get()
        {
            return db.Members.ToList();
        }

        public Member Get(int id)
        {
            return db.Members.Find(id);
        }

        public Member Insert(Member obj)
        {
            throw new NotImplementedException();
        }

        public Member Update(Member obj)
        {
            throw new NotImplementedException();
        }
    }
}
