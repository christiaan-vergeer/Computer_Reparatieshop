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
    public class KlantenController : Controller
    {
        private ReparatieContext db = new ReparatieContext();

        // GET: Klanten
        public ActionResult Index()
        {
            return View(db.klantens.ToList());
        }

        // GET: Klanten/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klant klanten = db.klantens.Find(id);
            if (klanten == null)
            {
                return HttpNotFound();
            }
            return View(klanten);
        }

        // GET: Klanten/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Klanten/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Firstname,Middlename,Lastname,Phonenumber,Adress,City")] Klant klanten)
        {
            if (ModelState.IsValid)
            {
                klanten.Fullname = klanten.Firstname + " " + klanten.Middlename + " " +  klanten.Lastname;
                db.klantens.Add(klanten);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(klanten);
        }

        // GET: Klanten/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klant klanten = db.klantens.Find(id);
            if (klanten == null)
            {
                return HttpNotFound();
            }
            return View(klanten);
        }

        // POST: Klanten/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Firstname,Middlename,Lastname,Phonenumber,Adress,City")] Klant klanten)
        {
            if (ModelState.IsValid)
            {
                klanten.Fullname = klanten.Firstname + " " + klanten.Middlename + " " + klanten.Lastname;
                db.Entry(klanten).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(klanten);
        }

        // GET: Klanten/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klant klanten = db.klantens.Find(id);
            if (klanten == null)
            {
                return HttpNotFound();
            }
            return View(klanten);
        }

        // POST: Klanten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           
            
            foreach(var item in db.reparatieopdrachtens.ToList())
            {
                if(id == item.Klant.Id)
                {
                    db.reparatieopdrachtens.Remove(item);
                }
                db.SaveChanges();
            }

            Klant klanten = db.klantens.Find(id);
            klanten.isdeleted = true;
            db.Entry(klanten).State = EntityState.Modified;
            //db.klantens.Remove(klanten);
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
