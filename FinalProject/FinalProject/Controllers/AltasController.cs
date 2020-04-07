using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class altasController : Controller
    {
        private HospitalContext db = new HospitalContext();

        // GET: altas
        public ActionResult Index()
        {
            var altas = db.altas.Include(a => a.ingreso);
            return View(altas.ToList());
        }

        // GET: altas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            altas altas = db.altas.Find(id);
            if (altas == null)
            {
                return HttpNotFound();
            }
            return View(altas);
        }

        // GET: altas/Create
        public ActionResult Create()
        {
            ViewBag.ingresos_id = new SelectList(db.ingresos, "id", "id");
            return View();
        }

        // POST: altas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ingresos_id,monto")] altas altas)
        {
            if (ModelState.IsValid)
            {
                db.altas.Add(altas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ingresos_id = new SelectList(db.ingresos, "id", "id", altas.ingresos_id);
            return View(altas);
        }

        // GET: altas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            altas altas = db.altas.Find(id);
            if (altas == null)
            {
                return HttpNotFound();
            }
            ViewBag.ingresos_id = new SelectList(db.ingresos, "id", "id", altas.ingresos_id);
            return View(altas);
        }

        // POST: altas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ingresos_id,monto")] altas altas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(altas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ingresos_id = new SelectList(db.ingresos, "id", "id", altas.ingresos_id);
            return View(altas);
        }

        // GET: altas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            altas altas = db.altas.Find(id);
            if (altas == null)
            {
                return HttpNotFound();
            }
            return View(altas);
        }

        // POST: altas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            altas altas = db.altas.Find(id);
            db.altas.Remove(altas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
