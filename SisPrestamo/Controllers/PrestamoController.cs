using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SisPrestamo.Controllers
{
    public class PrestamoController : Controller
    {
        private prestamodbEntities db = new prestamodbEntities();

        //
        // GET: /Prestamo/

        public ActionResult Index()
        {
            var prestamos = db.Prestamos.Include(p => p.Cliente).Include(p => p.tipo_prestamo1);
            return View(prestamos.ToList());
        }

        //
        // GET: /Prestamo/Details/5

        public ActionResult Details(int id = 0)
        {
            Prestamo prestamo = db.Prestamos.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);
        }

        //
        // GET: /Prestamo/Create

        public ActionResult Create()
        {
            ViewBag.id_cliente = new SelectList(db.Clientes, "id", "Nombre");
            ViewBag.tipo_prestamo = new SelectList(db.tipo_prestamo, "id", "tipo");
            return View();
        }

        //
        // POST: /Prestamo/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                db.Prestamos.Add(prestamo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cliente = new SelectList(db.Clientes, "id", "Nombre", prestamo.id_cliente);
            ViewBag.tipo_prestamo = new SelectList(db.tipo_prestamo, "id", "tipo", prestamo.tipo_prestamo);
            return View(prestamo);
        }

        //
        // GET: /Prestamo/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Prestamo prestamo = db.Prestamos.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cliente = new SelectList(db.Clientes, "id", "Nombre", prestamo.id_cliente);
            ViewBag.tipo_prestamo = new SelectList(db.tipo_prestamo, "id", "tipo", prestamo.tipo_prestamo);
            return View(prestamo);
        }

        //
        // POST: /Prestamo/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prestamo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cliente = new SelectList(db.Clientes, "id", "Nombre", prestamo.id_cliente);
            ViewBag.tipo_prestamo = new SelectList(db.tipo_prestamo, "id", "tipo", prestamo.tipo_prestamo);
            return View(prestamo);
        }

        //
        // GET: /Prestamo/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Prestamo prestamo = db.Prestamos.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);
        }

        //
        // POST: /Prestamo/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prestamo prestamo = db.Prestamos.Find(id);
            db.Prestamos.Remove(prestamo);
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