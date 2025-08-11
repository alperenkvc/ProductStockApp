using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductStockApp.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace ProductStockApp.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        MvcDbStokEntities1 db = new MvcDbStokEntities1();
        public ActionResult Index(int page=1)
        {
            //var values = db.CategoriesTable.ToList();
            var values = db.CategoriesTable.ToList().ToPagedList(page, 4);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCategory(CategoriesTable p1)
        {
            if (!ModelState.IsValid)
            {
                return View("NewCategory");
            }
            db.CategoriesTable.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var category = db.CategoriesTable.Find(id);
            db.CategoriesTable.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetCategory(int id)
        {
            var category = db.CategoriesTable.Find(id);
            return View("GetCategory", category);
        }

        public ActionResult UpdateCategory(CategoriesTable p1)
        {
            var category = db.CategoriesTable.Find(p1.CategoryID);
            category.CategoryName = p1.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}