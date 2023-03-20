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
            if (ModelState.IsValid)
            {
                var db = new ZeroHungerDb();
                var user = (from u in db.Users
                            where u.Username.Equals(obj.Username) && u.Password.Equals(obj.Password)
                            select u).SingleOrDefault();
                var restaurant = (from r in db.Restaurants
                                  where r.Username.Equals(obj.Username) && r.Password.Equals(obj.Password)
                                  select r).SingleOrDefault();
                if (user != null)
                {
                    Session["user"] = user;
                    var retUrl = Request["ReturnUrl"];
                    if (retUrl != null)
                    {
                        return Redirect(retUrl);
                    }
                    if (user.Type.Equals("Admin"))
                    {
                    return RedirectToAction("AcceptCollectionRq", "Food");
                    }
                }
                if (restaurant != null)
                {
                    Session["restaurant"] = restaurant;
                    var retUrl = Request["ReturnUrl"];
                    if (retUrl != null)
                    {
                        return Redirect(retUrl);
                    }
                    return RedirectToAction("PlaceCollectionRequest", "Food");
                }
                TempData["Msg"] = "Username Password invalid";
            }

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
            if (ModelState.IsValid)
            {
                var db = new ZeroHungerDb();
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