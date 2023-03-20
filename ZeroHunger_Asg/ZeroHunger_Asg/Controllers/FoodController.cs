using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger_Asg.Auth;
using ZeroHunger_Asg.EF;
using ZeroHunger_Asg.EF.Models;

namespace ZeroHunger_Asg.Controllers
{
    [Logged]
    public class FoodController : Controller
    {
        public ActionResult UserDashboard()
        {
            return View();
        }
        public ActionResult RestaurantDashboard()
        {
            return View();
        }
        [RestaurantAccess]
        [HttpGet]
        public ActionResult PlaceCollectionRequest()
        {
 
            return View();
        }
        [RestaurantAccess]
        [HttpPost]
        public ActionResult PlaceCollectionRequest(Food f)
        {
            if(ModelState.IsValid)
            {
                var db = new ZeroHungerDb();
                var res = (Restaurant)Session["restaurant"];
               // Food f = new Food();
                f.RestaurantId = res.Id;
                f.RequestTime = DateTime.Now;
                f.Status = "Pickup pending";
                f.DistributedOn = "Not yet";
                db.Foods.Add(f);
                db.SaveChanges();
                return RedirectToAction("RestaurantDashboard");
            }
            return View(f);
        }
        public ActionResult RestaurantHistory()
        {
            var db = new ZeroHungerDb();
            var res = (Restaurant)Session["restaurant"];
            var history = (from h in db.Foods
                           where h.RestaurantId == res.Id
                           select h).ToList();
            return View(history);
        }
        public ActionResult AcceptCollectionRq()
        {
            var db = new ZeroHungerDb();
            var pending = (from f in db.Foods
                           where f.Status == "Pickup pending"
                           select f).ToList();
            return View(pending);

        }
    }
}