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
    public class consultasController : Controller
    {
        private HospitalContext db = new HospitalContext();

        // GET: consultas
        public ActionResult Index()
        {
            var consultas = db.Consultas.Include(c => c.doctor).Include(c => c.patient);
            return View(consultas.ToList());
        }

        // GET: consultas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            consulta consulta = db.Consultas.Find(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        // GET: consultas/Create
        public ActionResult Create()
        {
            ViewBag.doctors_ID = new SelectList(db.doctors, "ID", "cedula");
            ViewBag.patient_ID = new SelectList(db.Patients, "ID", "Cedula");
            return View();
        }

        // POST: consultas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,patient_ID,doctors_ID,Fecha,Hora")] consulta consulta)
        {
            if (ModelState.IsValid)
            {
                db.Consultas.Add(consulta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.doctors_ID = new SelectList(db.doctors, "ID", "cedula", consulta.doctors_ID);
            ViewBag.patient_ID = new SelectList(db.Patients, "ID", "Cedula", consulta.patient_ID);
            return View(consulta);
        }

        // GET: consultas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            consulta consulta = db.Consultas.Find(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            ViewBag.doctors_ID = new SelectList(db.doctors, "ID", "cedula", consulta.doctors_ID);
            ViewBag.patient_ID = new SelectList(db.Patients, "ID", "Cedula", consulta.patient_ID);
            return View(consulta);
        }

        // POST: consultas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,patient_ID,doctors_ID,Fecha,Hora")] consulta consulta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consulta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.doctors_ID = new SelectList(db.doctors, "ID", "cedula", consulta.doctors_ID);
            ViewBag.patient_ID = new SelectList(db.Patients, "ID", "Cedula", consulta.patient_ID);
            return View(consulta);
        }

        // GET: consultas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            consulta consulta = db.Consultas.Find(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        // POST: consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            consulta consulta = db.Consultas.Find(id);
            db.Consultas.Remove(consulta);
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
