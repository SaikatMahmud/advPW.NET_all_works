using ProductCustomer_lab.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductCustomer_lab.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Product
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer cus)
        {
            var db = new ECom_asp_testEntities();
            if (ModelState.IsValid)
            {
                db.Customers.Add(cus);
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(cus);
        }

        public ActionResult List()
        {
            var db = new ECom_asp_testEntities();
            var cus = db.Customers.ToList();
            return View(cus);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new ECom_asp_testEntities();
            var cus = (from c in db.Customers
                       where c.Id == id //id has spelling mistake in DB
                       select c).SingleOrDefault();
            return View(cus);
        }
        [HttpPost]
        public ActionResult Edit(Customer updated)
        {
            var db = new ECom_asp_testEntities();
            var extCus = (from c in db.Customers
                          where c.Id == updated.Id
                          select c).SingleOrDefault();
            db.Entry(extCus).CurrentValues.SetValues(updated);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult Delete(int id)
        {
            var db = new ECom_asp_testEntities();
            var delCus = (from c in db.Customers
                          where c.Id == id //id has spelling mistake in DB
                          select c).SingleOrDefault();
            db.Customers.Remove(delCus);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}