using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class NewsRepo
    {
        static CatNewsDb db;
        static NewsRepo()
        {
            db = new CatNewsDb();
        }
        public static List<News> Get()
        {
            return db.News.ToList();
        }
        public static News Get(int id)
        {
            return db.News.Find(id);
        }
        public static bool Create(News news)
        {
            db.News.Add(news);
            return db.SaveChanges() > 0;
        }
    
    }
}
