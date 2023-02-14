using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practice2Form.Models;

namespace Practice2Form.Controllers
{
    public class FullFormController : Controller
    {
        // GET: FullForm
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FullForm obj)
        {
            return View(obj);
        }
    }
}