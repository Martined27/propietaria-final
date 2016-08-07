using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SisPrestamo.Models;

namespace SisPrestamo.Controllers
{
    public class Tipo_PrestamoController : Controller
    {
        private SisPrestamoContext db = new SisPrestamoContext();

        //
        // GET: /Tipo_Prestamo/

        public ActionResult Index()
        {
            return View(db.tipo_prestamo.ToList());
        }

        //
        // GET: /Tipo_Prestamo/Details/5

        public ActionResult Details(int id = 0)
        {
            tipo_prestamo tipo_prestamo = db.tipo_prestamo.Find(id);
            if (tipo_prestamo == null)
            {
                return HttpNotFound();
            }
            return View(tipo_prestamo);
        }

        //
        // GET: /Tipo_Prestamo/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Tipo_Prestamo/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tipo_prestamo tipo_prestamo)
        {
            if (ModelState.IsValid)
            {
                db.tipo_prestamo.Add(tipo_prestamo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_prestamo);
        }

        //
        // GET: /Tipo_Prestamo/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tipo_prestamo tipo_prestamo = db.tipo_prestamo.Find(id);
            if (tipo_prestamo == null)
            {
                return HttpNotFound();
            }
            return View(tipo_prestamo);
        }

        //
        // POST: /Tipo_Prestamo/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tipo_prestamo tipo_prestamo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_prestamo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_prestamo);
        }

        //
        // GET: /Tipo_Prestamo/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tipo_prestamo tipo_prestamo = db.tipo_prestamo.Find(id);
            if (tipo_prestamo == null)
            {
                return HttpNotFound();
            }
            return View(tipo_prestamo);
        }

        //
        // POST: /Tipo_Prestamo/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipo_prestamo tipo_prestamo = db.tipo_prestamo.Find(id);
            db.tipo_prestamo.Remove(tipo_prestamo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}