using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;

namespace SisPrestamo.Controllers
{
    public class CalculadoraController : Controller
    {
        //
        // GET: /Calculadora/
      
        public ActionResult Index()
        {
            
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";


            return View();
        }

        public JsonResult CalcularPrestamo(double Monto, double Tasa, int Plazo)
        {
            int p = Plazo * -1;
            Tasa = Tasa/100;
            double b = (1 + Tasa);
            double c = (1 - Math.Pow(b, p));
           
            double res_cuotafija = (Tasa * Monto)/c;
            double interes_anual = (res_cuotafija * 12);
            double res_total= res_cuotafija * Plazo;
            double costo_fin = res_total - Monto;

            CultureInfo rdCulture = new CultureInfo("es-DO");

            return Json(new
            {
                cuota_fija = string.Format("RD {0:C}", res_cuotafija),
                interes = string.Format("RD {0:C}", interes_anual),
                costo_total = string.Format("RD {0:C}", res_total),
                costo_financiamiento = string.Format("RD {0:C}", costo_fin)
            });
        }
    }
}
