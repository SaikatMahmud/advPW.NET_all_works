using BLL.DTOs;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
   public class NewsService
    {
        public static List<NewsDTO> Get()
        {
            var data = NewsRepo.Get();
            return Convert(data);

        }
       
        public static NewsDTO Get(int id)
        {
            return Convert(NewsRepo.Get(id));
        }
        public static bool Create(NewsDTO news)
        {
            var data = Convert(news);
            return NewsRepo.Create(data);
        }
      
        static List<NewsDTO> Convert(List<News> news)
        {
            var data = new List<NewsDTO>();
            foreach (var n in news)
            {
                data.Add(new NewsDTO()
                {
                    Title = n.Title,
                    Description= n.Description,
                    CId = n.CId,
                    Date = DateTime.Now
                }
            );
            }
            return data;

        }
        static News Convert(NewsDTO n)
        {
            return new News()
            {
                Title = n.Title,
                Description = n.Description,
                CId = n.CId,
                Date = n.Date
            };
        }
        static NewsDTO Convert(News n)
        {
            return new NewsDTO()
            {
                Id = n.Id,
                Title = n.Title,
                Description = n.Description,
                CId = n.CId,
                Date = n.Date
            };
        }

    }
}
