using ProductCustomer_lab.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductCustomer_lab.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult List()
        {
            var db = new ECom_asp_testEntities();
            var ord = db.Orders.ToList();
            return View(ord);
        }
        public ActionResult Details(int id)
        {
            var db = new ECom_asp_testEntities();
            var ord = (from o in db.ProductOrders
                           where o.OrderId == id 
                           select o).ToList();
            return View(ord);
        }
    }
}