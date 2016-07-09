using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SisPrestamo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Presta+ fue desarrollado por Martin E. De Leon y Efrain Toribio ";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contactanos";

            return View();
        }
    }
}
