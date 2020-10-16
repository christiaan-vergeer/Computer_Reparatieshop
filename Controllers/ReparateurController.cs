using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Computer_Reparatieshop.DAL;
using Computer_Reparatieshop.Models;

namespace Computer_Reparatieshop.Controllers
{
    public class ReparateurController : Controller
    {
        private ReparatieContext db = new ReparatieContext();

        // GET: Reparateur
        public ActionResult Index()
        {
            return View(db.Reparateurs.ToList());
        }

        // GET: Reparateur/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reparateur reparateur = db.Reparateurs.Find(id);
            if (reparateur == null)
            {
                return HttpNotFound();
            }
            return View(reparateur);
        }

        // GET: Reparateur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reparateur/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,InFix,LastName,Wage")] Reparateur reparateur)
        {
            if (ModelState.IsValid)
            {
                reparateur.FullName = reparateur.FirstName + " " + reparateur.InFix + " " + reparateur.LastName;
                db.Reparateurs.Add(reparateur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reparateur);
        }

        // GET: Reparateur/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reparateur reparateur = db.Reparateurs.Find(id);
            if (reparateur == null)
            {
                return HttpNotFound();
            }
            return View(reparateur);
        }

        // POST: Reparateur/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,InFix,LastName,Wage")] Reparateur reparateur)
        {
            if (ModelState.IsValid)
            {
                reparateur.FullName = reparateur.FirstName + " " + reparateur.InFix + " " + reparateur.LastName;
                db.Entry(reparateur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reparateur);
        }

        // GET: Reparateur/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reparateur reparateur = db.Reparateurs.Find(id);
            if (reparateur == null)
            {
                return HttpNotFound();
            }
            return View(reparateur);
        }

        // POST: Reparateur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reparateur reparateur = db.Reparateurs.Find(id);
            db.Reparateurs.Remove(reparateur);
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
