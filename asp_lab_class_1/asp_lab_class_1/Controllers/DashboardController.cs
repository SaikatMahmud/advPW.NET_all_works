using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asp_lab_class_1.Models;

namespace asp_lab_class_1.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {

            Student[] students = new Student[2];

            students[0] = new Student();
            students[0].Id = 1;
            students[0].Name = "John Doe";

            students[1] = new Student();
            students[1].Id = 2;
            students[1].Name = "saikat doe";
            ViewBag.obj = students;
            return View();
        }
    }
}