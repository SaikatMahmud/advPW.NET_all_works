using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;




namespace asp_lab_class_1.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult HomePage()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult LoginPage()
        {
            return View();
        }
        public ActionResult LoginSubmit()
        {  
            TempData["msg"] = "Login Successfull";
            return RedirectToAction("Index", "Dashboard");
        }
    }
}