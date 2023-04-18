using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProjectService
    {
        public static List<ProjectDTO> Get()
        {
            var data = DataAccessFactory.ProjectData().Get();
            return Convert(data);
        }
        public static ProjectDTO Get(int id)
        {
            return Convert(DataAccessFactory.ProjectData().Get(id));
        }
        public static bool Insert(ProjectDTO project)
        {
            var data = Convert(project);
            var res = DataAccessFactory.ProjectData().Insert(data);

            if (res != null) return true;
            return false;
        }
        public static bool Update(ProjectDTO project)
        {
            var data = Convert(project);
            var res = DataAccessFactory.ProjectData().Update(data);

            if (res != null) return true;
            return false;
        }
        public static List<ProjectDTO> GetStatusBased(string status)
        {
            var data = DataAccessFactory.ProjectData().Get();
            var fetch = (from f in data
                         where f.Status == status
                         select f).ToList();
            return Convert(fetch);
        }
        public static List<ProjectDTO> GetDateBased(string status, DateTime date)
        {
            var data = DataAccessFactory.ProjectData().Get();
            var fetch = (from f in data
                         where f.Status == status && f.StartDate == date
                         select f).ToList();
            return Convert(fetch);
        }

        static List<ProjectDTO> Convert(List<Project> projects)
        {
            var data = new List<ProjectDTO>();
            foreach (var project in projects)
            {
                data.Add(new ProjectDTO()
                {
                    Id= project.Id,
                    Title = project.Title,
                    Status = project.Status,
                    StartDate = project.StartDate,
                    EndDate = project.EndDate,
                    Members = project.Members.ToList()
                });
            }
            return data;

        }
        static Project Convert(ProjectDTO project)
        {
            return new Project()
            {
                Id = project.Id,
                Title = project.Title,
                Status = project.Status,
                StartDate = project.StartDate,
                EndDate = project.EndDate
            };
        }
        static ProjectDTO Convert(Project project)
        {
            return new ProjectDTO()
            {
                Id = project.Id,
                Title = project.Title,
                Status = project.Status,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                Members = project.Members.ToList()

            };
        }

    }
}
