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
    public class altas1Controller : Controller
    {
        private HospitalContext db = new HospitalContext();

        // GET: altas1
        public ActionResult Index([Bind(Include = "ingreso_id")] altas altas)
        {
            return View(db.altas.ToList());
        }

        // GET: altas1/Details/5
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

        // GET: altas1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: altas1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,monto")] altas altas)
        {
            if (ModelState.IsValid)
            {
                db.altas.Add(altas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(altas);
        }

        // GET: altas1/Edit/5
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
            return View(altas);
        }

        // POST: altas1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,monto")] altas altas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(altas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(altas);
        }

        // GET: altas1/Delete/5
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

        // POST: altas1/Delete/5
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
