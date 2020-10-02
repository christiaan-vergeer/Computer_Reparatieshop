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
    public class ReparatieopdrachtenController : Controller
    {
        private ReparatieContext db = new ReparatieContext();

        // GET: Reparatieopdrachten
        public ActionResult Index()
        {

            //ViewBag.Message = "tabel met info";
            ViewBag.Message2 = "test";
            ViewBag.pending = "test1";
            ViewBag.underway = "test2";
            ViewBag.waitingforpart = "test3";
            ViewBag.done = "test4";

            
            return View(db.reparatieopdrachtens.ToList());
        }

        // GET: Reparatieopdrachten/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reparatieopdrachten reparatieopdrachten = db.reparatieopdrachtens.Find(id);
            if (reparatieopdrachten == null)
            {
                return HttpNotFound();
            }
            return View(reparatieopdrachten);
        }

        // GET: Reparatieopdrachten/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reparatieopdrachten/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Startdate,Enddate,Status")] Reparatieopdrachten reparatieopdrachten)
        {
            if (ModelState.IsValid)
            {
                db.reparatieopdrachtens.Add(reparatieopdrachten);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reparatieopdrachten);
        }

        // GET: Reparatieopdrachten/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reparatieopdrachten reparatieopdrachten = db.reparatieopdrachtens.Find(id);
            if (reparatieopdrachten == null)
            {
                return HttpNotFound();
            }
            return View(reparatieopdrachten);
        }

        // POST: Reparatieopdrachten/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Startdate,Enddate,Status")] Reparatieopdrachten reparatieopdrachten)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reparatieopdrachten).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reparatieopdrachten);
        }

        // GET: Reparatieopdrachten/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reparatieopdrachten reparatieopdrachten = db.reparatieopdrachtens.Find(id);
            if (reparatieopdrachten == null)
            {
                return HttpNotFound();
            }
            return View(reparatieopdrachten);
        }

        // POST: Reparatieopdrachten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reparatieopdrachten reparatieopdrachten = db.reparatieopdrachtens.Find(id);
            db.reparatieopdrachtens.Remove(reparatieopdrachten);
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
