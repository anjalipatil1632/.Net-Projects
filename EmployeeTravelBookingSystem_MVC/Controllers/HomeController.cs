using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeTravelBookingSystem_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Homepage()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message ="About Us";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us";

            return View();
        }
    }
}