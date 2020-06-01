using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gill.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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
        public ActionResult Client()
        {
            ViewBag.Message = "Your Clints page.";

            return View();
        } 
        public ActionResult Flight()
        {
            ViewBag.Message = "Your Flight page.";

            return View();
        }
       
        public ActionResult Staff()
        {
            ViewBag.Message = "Your Staff page.";

            return View();
        }
        public ActionResult Airline()
        {
            ViewBag.Message = "Your Airline page.";

            return View();
        }

    }
}