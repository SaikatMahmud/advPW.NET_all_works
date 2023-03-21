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
            if (ModelState.IsValid)
            {
                var db = new ZeroHungerDb();
                var res = (Restaurant)Session["restaurant"];
                // Food f = new Food();
                f.RestaurantId = res.Id;
                f.RequestTime = DateTime.Now;
                f.Status = "Open";
                f.DistributedOn = "Not yet";
                db.Foods.Add(f);
                db.SaveChanges();
                return RedirectToAction("PlaceCollectionRequest");
            }
            return View(f);
        }
        [RestaurantAccess]
        public ActionResult RestaurantHistory()
        {
            var db = new ZeroHungerDb();
            var res = (Restaurant)Session["restaurant"];
            var history = (from h in db.Foods
                           where h.RestaurantId == res.Id
                           select h).ToList();
            return View(history);
        }
        [AdminAccess]
        public ActionResult PendingList()
        {
            var db = new ZeroHungerDb();
            var pending = (from f in db.Foods
                           where f.Status == "Open"
                           select f).ToList();
            return View(pending);
        }
        [AdminAccess]
        [HttpGet]
        public ActionResult AcceptCollectionRq(int id)
        {
            var db = new ZeroHungerDb();
            var staff = (from s in db.Users select s).ToList();
            var food = (from f in db.Foods
                        where f.Id == id
                        select f).SingleOrDefault();
            ViewBag.Staff = staff;
            return View(food);
        }
        [AdminAccess]
        [HttpPost]
        public ActionResult AcceptCollectionRq(FormCollection form)
        {
            var db = new ZeroHungerDb();
            var f = db.Foods.Find(int.Parse(form["Id"]));
            f.CollectionStaffId = int.Parse(form["CollectionStaffId"]);
            f.Status = "Collecting";
            db.Entry(f).CurrentValues.SetValues(f);
            db.SaveChanges();
            return RedirectToAction("PendingList");
        }
        public ActionResult AllList()
        {
            var db = new ZeroHungerDb();
            var all = (from f in db.Foods select f).ToList();
            return View(all);
        }
        [AdminAccess]
        public ActionResult FullDetails(int id)
        {
            var db = new ZeroHungerDb();
            var f = db.Foods.Find(id);
            return View(f);
        }
        [AdminAccess]
        public ActionResult ToDistributeList()
        {
            var db = new ZeroHungerDb();
            var distribute = (from f in db.Foods
                           where f.Status == "Collected"
                           select f).ToList();
            return View(distribute);
        }
        [AdminAccess]
        [HttpGet]
        public ActionResult AssignDistributor(int id)
        {
            var db = new ZeroHungerDb();
            var staff = (from s in db.Users select s).ToList();
            var food = (from f in db.Foods
                        where f.Id == id
                        select f).SingleOrDefault();
            ViewBag.Staff = staff;
            return View(food);
        }
        [AdminAccess]
        [HttpPost]
        public ActionResult AssignDistributor(FormCollection form)
        {
            var db = new ZeroHungerDb();
            var f = db.Foods.Find(int.Parse(form["Id"]));
            f.DistributeStaffId = int.Parse(form["DistributeStaffId"]);
            f.Status = "Distributing";
            db.Entry(f).CurrentValues.SetValues(f);
            db.SaveChanges();
            return RedirectToAction("ToDistributeList");
        }



        [EmployeeAccess]
        public ActionResult ToCollectListEmp()
        {
            var db = new ZeroHungerDb();
            var emp = (User)Session["user"];
            var collect = (from f in db.Foods
                           where f.CollectionStaffId == emp.Id && f.Status == "Collecting"
                           select f).ToList();
            return View(collect);
        }
        [EmployeeAccess]
        public ActionResult MarkAsCollected(int id)
        {
            var db = new ZeroHungerDb();
            var f = db.Foods.Find(id);
            f.Status = "Collected";
            db.Entry(f).CurrentValues.SetValues(f);
            db.SaveChanges();
            return RedirectToAction("EmpDashboard", "User");
        }

        [EmployeeAccess]
        public ActionResult ToDistributeListEmp()
        {
            var db = new ZeroHungerDb();
            var emp = (User)Session["user"];
            var distribute = (from f in db.Foods
                           where f.DistributeStaffId == emp.Id && f.Status == "Distributing"
                              select f).ToList();
            return View(distribute);
        }

        [EmployeeAccess]
        [HttpGet]
        public ActionResult AddDistributionPlace(int id)
        {
            var db = new ZeroHungerDb();
            var food = (from f in db.Foods
                        where f.Id == id
                        select f).SingleOrDefault();
            return View(food);
        }
        [EmployeeAccess]
        [HttpPost]
        public ActionResult AddDistributionPlace(FormCollection form)
        {
            var db = new ZeroHungerDb();
            var f = db.Foods.Find(int.Parse(form["Id"]));
            f.DistributedOn = form["Place"];
            f.DistributeTime = DateTime.Now;
            f.Status = "Complete";
            db.Entry(f).CurrentValues.SetValues(f);
            db.SaveChanges();
            return RedirectToAction("EmpDashboard", "User");
        }

    }
}