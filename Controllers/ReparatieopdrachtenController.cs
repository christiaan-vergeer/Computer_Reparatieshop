using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Computer_Reparatieshop.DAL;
using Computer_Reparatieshop.Models;
using Computer_Reparatieshop.ViewModels;

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
            ViewBag.pending = Countstate(Status.Pending);
            ViewBag.underway = Countstate(Status.InProgress);
            ViewBag.waitingforpart = Countstate(Status.WaitingForParts);
            ViewBag.done = Countstate(Status.Done);


            return View(db.reparatieopdrachtens.ToList());
        }

        public int Countstate(Status statusRepair)
        {
            int count = 0;
            var dbReparatiesList = db.reparatieopdrachtens.ToList();

            for (int i = 0; i < dbReparatiesList.Count; i++)
            {
                if (dbReparatiesList[i].Status == statusRepair)
                {
                    count++;
                }
            }

            return count;
        }

        // GET: Reparatieopdrachten/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reparatieopdracht reparatieopdrachten = db.reparatieopdrachtens.Find(id);
            if (reparatieopdrachten == null)
            {
                return HttpNotFound();
            }
            return View(reparatieopdrachten);
        }

        // GET: Reparatieopdrachten/Create
        public ActionResult Create()
        {
            var CreateReparatieViewModel = new CreateRepairViewModel
            {
                Reparatieopdracht = new Reparatieopdracht(),
                Klanten = db.klantens.ToList()
            };
            return View(CreateReparatieViewModel);
        }

        // POST: Reparatieopdrachten/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [DefaultValue(typeof(Status), "1")]
        public ActionResult Create([Bind(Include = "Reparatieopdracht, KlantId")] CreateRepairViewModel createRepairViewModel)
        {
            if (ModelState.IsValid)
            {
                var reparatieopdracht = createRepairViewModel.Reparatieopdracht;
                reparatieopdracht.Klant = db.klantens.Find(createRepairViewModel.KlantId);
                db.reparatieopdrachtens.Add(reparatieopdracht);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(createRepairViewModel);
        }
        //[Bind(Include = "Id,Name,Startdate,Enddate,Status,Details")]

        // GET: Reparatieopdrachten/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reparatieopdracht reparatieopdrachten = db.reparatieopdrachtens.Find(id);
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
        public ActionResult Edit([Bind(Include = "Id,Name,Startdate,Enddate,Status,Details")] Reparatieopdracht reparatieopdrachten)
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
            Reparatieopdracht reparatieopdrachten = db.reparatieopdrachtens.Find(id);
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
            Reparatieopdracht reparatieopdrachten = db.reparatieopdrachtens.Find(id);
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
