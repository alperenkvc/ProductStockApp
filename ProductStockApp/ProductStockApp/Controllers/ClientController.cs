using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using PagedList;
using PagedList.Mvc;
using ProductStockApp.Models.Entity;

namespace ProductStockApp.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        MvcDbStokEntities1 db = new MvcDbStokEntities1();
        public ActionResult Index(string p)
        {
            //var values = db.ClientsTable.ToList();
            //var values = db.ClientsTable.ToList().ToPagedList(page, 4);
            //return View(values);

            var values = from d in db.ClientsTable select d;

            if (!string.IsNullOrEmpty(p))
            {
                values = values.Where(m => m.ClientName.Contains(p));
            }

            return View(values.ToList());
        }

        [HttpGet]
        public ActionResult NewClient()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewClient(ClientsTable p1)
        {
            if(!ModelState.IsValid)
            {
                return View("NewClient");
            }
            db.ClientsTable.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteClient(int id)
        {
            var client = db.ClientsTable.Find(id);
            db.ClientsTable.Remove(client);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetClient(int id)
        {
            var client = db.ClientsTable.Find(id);
            return View("GetClient", client);
        }

        public ActionResult UpdateClient(ClientsTable p1)
        {
            var client = db.ClientsTable.Find(p1.ClientID);
            client.ClientName = p1.ClientName;
            client.ClientSurname = p1.ClientSurname;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}