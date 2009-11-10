using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPM.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Wellcome to EPM";
            return RedirectToAction("index", "Project");
           
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
