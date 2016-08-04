using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using TimeSheet2017.Models;

namespace TimeSheet2017.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.CurrentLoggedInUser = User.Identity.Name;
 

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