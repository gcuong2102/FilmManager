using SpendingManagement.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpendingManagement.Controllers
{
    public class HomeController : Controller
    {
        FilmDbContext db = new FilmDbContext();
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
        public ActionResult TestConnect()
        {
            if (db.Database.Exists())
            {
                return View("About");
            }
            else
            {
                return View("Contact");
            }
        }
    }
}