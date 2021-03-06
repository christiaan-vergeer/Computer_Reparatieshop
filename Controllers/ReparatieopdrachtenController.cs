﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
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
            var CreateReparatieViewModel = new CreateRepairViewModel
            {
                Reparatieopdracht = db.reparatieopdrachtens.Find(id),
                Klanten = db.klantens.ToList()
            };
            return View(CreateReparatieViewModel);
        }

        // GET: Reparatieopdrachten/Create
        public ActionResult Create()
        {
            var CreateReparatieViewModel = new CreateRepairViewModel
            {
                Reparatieopdracht = new Reparatieopdracht
                {
                    Startdate = DateTime.Now,
                    Enddate = DateTime.Now
                },
                Klanten = db.klantens.ToList(),
                reparateurs = db.Reparateurs.ToList()
            };
            return View(CreateReparatieViewModel);
        }

        // POST: Reparatieopdrachten/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [DefaultValue(typeof(Status), "1")]
        public ActionResult Create([Bind(Include = "Reparatieopdracht, KlantId, ReparateurId")] CreateRepairViewModel createRepairViewModel)
        {
            if (ModelState.IsValid)
            {
                var reparatieopdracht = createRepairViewModel.Reparatieopdracht;
                reparatieopdracht.Klant = db.klantens.Find(createRepairViewModel.KlantId);
                reparatieopdracht.Reparateur = db.Reparateurs.Find(createRepairViewModel.ReparateurId);
                db.reparatieopdrachtens.Add(reparatieopdracht);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(createRepairViewModel);
        }

        // GET: Reparatieopdrachten/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var CreateReparatieViewModel = new CreateRepairViewModel
            {
                Reparatieopdracht = db.reparatieopdrachtens.Include(r => r.Klant).Include(r => r.Reparateur).FirstOrDefault(r => r.Id == id),
                Klanten = db.klantens.ToList(),
                reparateurs = db.Reparateurs.ToList()
            };
            CreateReparatieViewModel.KlantId = CreateReparatieViewModel.Reparatieopdracht.Klant.Id;
            CreateReparatieViewModel.ReparateurId = CreateReparatieViewModel.Reparatieopdracht.Reparateur.Id;
            return View(CreateReparatieViewModel);
        }

        // POST: Reparatieopdrachten/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Reparatieopdracht, KlantId, ReparateurId,reparateurtime")] CreateRepairViewModel createRepairViewModel)
        {
            if (ModelState.IsValid)
            {
                var reparatieOpdracht = db.reparatieopdrachtens.Include(r => r.Klant).Include(r => r.Reparateur).FirstOrDefault(r => r.Id == createRepairViewModel.Reparatieopdracht.Id);

                reparatieOpdracht.Name = createRepairViewModel.Reparatieopdracht.Name;
                reparatieOpdracht.Startdate = createRepairViewModel.Reparatieopdracht.Startdate;
                reparatieOpdracht.Enddate = createRepairViewModel.Reparatieopdracht.Enddate;
                reparatieOpdracht.Details = createRepairViewModel.Reparatieopdracht.Details;
                reparatieOpdracht.price = reparatieOpdracht.price + (createRepairViewModel.reparateurtime * (db.Reparateurs.FirstOrDefault(k => k.Id == createRepairViewModel.ReparateurId).Wage) / 60);
                reparatieOpdracht.Status = createRepairViewModel.Reparatieopdracht.Status;
                reparatieOpdracht.Klant = db.klantens.FirstOrDefault(k => k.Id == createRepairViewModel.KlantId);
                reparatieOpdracht.Reparateur = db.Reparateurs.FirstOrDefault(k => k.Id == createRepairViewModel.ReparateurId);

                db.Entry(reparatieOpdracht).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(createRepairViewModel);
        }

        // GET: Reparatieopdrachten/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var CreateReparatieViewModel = new CreateRepairViewModel
            {
                Reparatieopdracht = db.reparatieopdrachtens.Find(id),
                Klanten = db.klantens.ToList()
            };
            return View(CreateReparatieViewModel);
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

        // GET: Reparatieopdrachten/Onderdelen/5
        public ActionResult Onderdelen(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Reparatieopdracht reparatieopdracht = db.reparatieopdrachtens.Find(id);
            List<int> partId = new List<int>();
            List<string> partname = new List<string>();
            List<bool> boxsetter = new List<bool>();

            foreach (var listId in db.ComputerParts.ToList())
            {
               partId.Add(listId.Id);
            }

            foreach (var partlistname in db.ComputerParts.ToList())
            {
                partname.Add(partlistname.Name);
            }

            foreach (var part in db.ComputerParts.ToList())
            {
                if (db.reparatieopdrachtens.FirstOrDefault(r => r.Id == id).ComputerParts.Contains(part))
                {
                    boxsetter.Add(true);
                }
                else
                {
                    boxsetter.Add(false);
                }

            }


            var OnderdelenReparatieViewModel = new OnderdelenReparatieViewModel
            {
                MemmoryID = partId,
                checker = boxsetter,
                Partname = partname,

                Reparatieopdracht = db.reparatieopdrachtens.Include(r => r.Klant).Include(r => r.Reparateur).FirstOrDefault(r => r.Id == id)
            };


            return View(OnderdelenReparatieViewModel);
        }

        // POST: Reparatieopdrachten/Onderdelen/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Onderdelen([Bind(Include = "Reparatieopdracht,Partname, checkbox, IsChecked, checker,MemmoryID")] OnderdelenReparatieViewModel onderdelenReparatieViewModel)
        {
           //if (ModelState.IsValid)
           //{

            var reparatieOpdracht = db.reparatieopdrachtens.Include(r => r.ComputerParts).FirstOrDefault(r => r.Id == onderdelenReparatieViewModel.Reparatieopdracht.Id);

            reparatieOpdracht.ComputerParts.Clear();

            foreach (var i in onderdelenReparatieViewModel.MemmoryID)
            {
                int counter = i-1;
                var memID = onderdelenReparatieViewModel.MemmoryID[counter];
                if (onderdelenReparatieViewModel.checker[counter] == true)
                {
                    reparatieOpdracht.ComputerParts.Add(db.ComputerParts.FirstOrDefault(r => r.Id == memID));
                }
            }

            db.Entry(reparatieOpdracht).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");

            //}
            //return View(onderdelenReparatieViewModel);
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
