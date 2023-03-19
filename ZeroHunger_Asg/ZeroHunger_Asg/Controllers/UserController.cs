using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger_Asg.EF;
using ZeroHunger_Asg.EF.Models;
using ZeroHunger_Asg.Models;

namespace ZeroHunger_Asg.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login obj)
        {
            return View(obj);
        }
        [HttpGet]
        public ActionResult Reg()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Reg(Restaurant obj)
        {
            var db = new ZeroHungerDb();
            if (ModelState.IsValid)
            {
                db.Restaurants.Add(obj);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(obj);
        }
        public ActionResult Logout()
        {
            return RedirectToAction("Login");
        }
    }
}