using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZenView.Core.Helpers;

namespace ZenView.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ZendeskHelper zen = new ZendeskHelper();
            zen.GetTicktets();
            return View();
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