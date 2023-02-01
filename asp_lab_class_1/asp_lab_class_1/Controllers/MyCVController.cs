using System.Web.Mvc;

namespace asp_lab_class_1.Controllers
{
    public class MyCVController : Controller
    {
        // GET: MyCV
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MyCVhome()
        {
            return View();

        } 
        public ActionResult Education()
        {
            return View();

        }
        public ActionResult Projects()
        {
            return View();
        }
        public ActionResult References()
        {
            return View();
        }
    }
}