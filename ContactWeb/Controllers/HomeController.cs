using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContactWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() 
        {
            return View(); // will return the Index.cshtml in View folder because it has the same name as the ActionResult
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}