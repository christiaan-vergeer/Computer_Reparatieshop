using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Computer_Reparatieshop.Controllers
{
    public class ReparatieController : Controller
    {
        // GET: Reparatie
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReOpdracht()
        {


            //ViewBag.Message = "tabel met info";
            ViewBag.Message2 = "test";
            ViewBag.pending = "";
            ViewBag.underway = "";
            ViewBag.waitingforpart = "";
            ViewBag.done = "";

            return View();
        }

        public ActionResult ReNewOpdracht()
        {
            return View();
        }
    }
}