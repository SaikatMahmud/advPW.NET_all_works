using Practice2Form.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice2Form.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        //public ActionResult Index(int a=0) // 1. HttpRequestBase class
        //{
        //    ViewBag.Uname = Request["Uname"];
        //    ViewBag.Pass = Request["Pass"];
        //    return View();
        //}
        //public ActionResult Index(FormCollection form) // 2. FormCollection object
        //{
        //    ViewBag.Uname = form["Uname"];
        //    ViewBag.Pass = form["Pass"];
        //    return View();
        //}

        //public ActionResult Index(string Uname,string Pass) // 3. Variable name mapping
        //{
        //    ViewBag.Uname = Uname;
        //    ViewBag.Pass = Pass;
        //    return View();
        //}

        public ActionResult Index(FormSubmit obj) // 4. Model binding
        {
           // ViewBag.Data = obj; // sent using viewbag
            return View(obj); //sent direct, access via Model
        }

        public ActionResult StdList()
        {
            List<Student> students = new List<Student>();
            Random random = new Random();
            for (int i = 0; i <= 50; i++)
            {
                students.Add(new Student()
                {
                    Id = "Id-" + i,
                    Name = "Student " + random.Next(100, 500),
                    Roll = i
                }) ;
            }
            ViewBag.stds = students;
            return View();
            // return View(students); //if something pass directly inside View in should be accesed as Model
        }
    }
}