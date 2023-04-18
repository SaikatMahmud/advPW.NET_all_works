using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ProjectRepo : Repo, IRepo<Project, int, Project>
    {
        public bool Delete(int id)
        {
            var exP = Get(id);
            db.Projects.Remove(exP);
            return db.SaveChanges() > 0;
        }

        public List<Project> Get()
        {
            return db.Projects.ToList();
        }

        public Project Get(int id)
        {
            return db.Projects.Find(id);
        }

        public Project Insert(Project obj)
        {
            throw new NotImplementedException();
        }

        public Project Update(Project obj)
        {
            throw new NotImplementedException();
        }
    }
}
