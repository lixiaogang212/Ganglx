using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            if (System.Web.HttpContext.Current.Session["UserProfile"] != null)
            {
                ViewBag.Message = "欢迎来到ASPMVC";
                return View();
            }
            else
            {
                System.Web.HttpContext.Current.Session["UserProfile"] = "Test";
                System.Web.HttpContext.Current.Session.Timeout = 20;
                return RedirectToAction("LogOn", "Account");
            }
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
