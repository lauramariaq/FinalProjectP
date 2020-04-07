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
    public class ingresosController : Controller
    {
        private HospitalContext db = new HospitalContext();

        // GET: ingresos
        public ActionResult Index()
        {
            var ingresos = db.ingresos.Include(i => i.paciente).Include(i => i.room);
            return View(ingresos.ToList());
        }

        // GET: ingresos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ingresos ingresos = db.ingresos.Find(id);
            if (ingresos == null)
            {
                return HttpNotFound();
            }
            return View(ingresos);
        }

        // GET: ingresos/Create
        public ActionResult Create()
        {
            ViewBag.pacientes_ID = new SelectList(db.Patients, "ID", "Cedula");
            ViewBag.room_id = new SelectList(db.rooms, "ID", "tipo");
            return View();
        }

        // POST: ingresos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,pacientes_ID,room_id,FechaInicio")] ingresos ingresos)
        {
            if (ModelState.IsValid)
            {
                db.ingresos.Add(ingresos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.pacientes_ID = new SelectList(db.Patients, "ID", "Cedula", ingresos.pacientes_ID);
            ViewBag.room_id = new SelectList(db.rooms, "ID", "tipo", ingresos.room_id);
            return View(ingresos);
        }

        // GET: ingresos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ingresos ingresos = db.ingresos.Find(id);
            if (ingresos == null)
            {
                return HttpNotFound();
            }
            ViewBag.pacientes_ID = new SelectList(db.Patients, "ID", "Cedula", ingresos.pacientes_ID);
            ViewBag.room_id = new SelectList(db.rooms, "ID", "tipo", ingresos.room_id);
            return View(ingresos);
        }

        // POST: ingresos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,pacientes_ID,room_id,FechaInicio")] ingresos ingresos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingresos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.pacientes_ID = new SelectList(db.Patients, "ID", "Cedula", ingresos.pacientes_ID);
            ViewBag.room_id = new SelectList(db.rooms, "ID", "tipo", ingresos.room_id);
            return View(ingresos);
        }

        // GET: ingresos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ingresos ingresos = db.ingresos.Find(id);
            if (ingresos == null)
            {
                return HttpNotFound();
            }
            return View(ingresos);
        }

        // POST: ingresos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ingresos ingresos = db.ingresos.Find(id);
            db.ingresos.Remove(ingresos);
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
