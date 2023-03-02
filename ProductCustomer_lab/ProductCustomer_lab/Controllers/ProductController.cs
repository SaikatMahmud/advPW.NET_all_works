using ProductCustomer_lab.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductCustomer_lab.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        [HttpGet]
        public ActionResult Create()
        {
            var db = new ECom_asp_testEntities();
            var cat = (from c in db.Categories select c).ToList();
            return View(cat);
        }
        [HttpPost]
        public ActionResult Create(Product pd)
        {
            var db =new ECom_asp_testEntities();
            if (ModelState.IsValid)
            {
                db.Products.Add(pd);
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(pd);
        }
        public ActionResult List()
        {
            var db = new ECom_asp_testEntities();
            var pd = db.Products.ToList();
            return View(pd);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new ECom_asp_testEntities();
            var product = (from p in db.Products
                           where p.ld == id //id has spelling mistake in DB
                           select p).SingleOrDefault();
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product updated)
        {
            var db = new ECom_asp_testEntities();
            var extProduct = (from p in db.Products
                              where p.ld == updated.ld
                              select p).SingleOrDefault();
            db.Entry(extProduct).CurrentValues.SetValues(updated);
            db.SaveChanges();
            return RedirectToAction("List");
            //db.Students.Remove(extstudent);
        }
        public ActionResult Delete(int id)
        {
            var db = new ECom_asp_testEntities();
            var delProduct = (from p in db.Products
                              where p.ld == id //id has spelling mistake in DB
                              select p).SingleOrDefault();
            db.Products.Remove(delProduct);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}