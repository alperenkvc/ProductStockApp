using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductStockApp.Models.Entity;

namespace ProductStockApp.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        MvcDbStokEntities1 db = new MvcDbStokEntities1();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NewSale()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewSale(SalesTable p1)
        {
            db.SalesTable.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}