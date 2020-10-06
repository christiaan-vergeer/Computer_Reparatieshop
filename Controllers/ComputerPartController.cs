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
    public class ComputerPartController : Controller
    {
        private ReparatieContext db = new ReparatieContext();

        // GET: ComputerPart
        public ActionResult Index()
        {
            return View(db.ComputerParts.ToList());
        }

        // GET: ComputerPart/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComputerPart computerPart = db.ComputerParts.Find(id);
            if (computerPart == null)
            {
                return HttpNotFound();
            }
            return View(computerPart);
        }

        // GET: ComputerPart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComputerPart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Amount,Price,Vendor")] ComputerPart computerPart)
        {
            if (ModelState.IsValid)
            {
                db.ComputerParts.Add(computerPart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(computerPart);
        }

        // GET: ComputerPart/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComputerPart computerPart = db.ComputerParts.Find(id);
            if (computerPart == null)
            {
                return HttpNotFound();
            }
            return View(computerPart);
        }

        // POST: ComputerPart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Amount,Price,Vendor")] ComputerPart computerPart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(computerPart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(computerPart);
        }

        // GET: ComputerPart/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComputerPart computerPart = db.ComputerParts.Find(id);
            if (computerPart == null)
            {
                return HttpNotFound();
            }
            return View(computerPart);
        }

        // POST: ComputerPart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComputerPart computerPart = db.ComputerParts.Find(id);
            db.ComputerParts.Remove(computerPart);
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
