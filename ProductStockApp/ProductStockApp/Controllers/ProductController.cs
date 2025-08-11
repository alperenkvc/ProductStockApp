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
    public class ProductController : Controller
    {
        // GET: Product
        MvcDbStokEntities1 db = new MvcDbStokEntities1();
        public ActionResult Index()
        {
            var values = db.ProductsTable.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewProduct()
        {
            List<SelectListItem> values = db.CategoriesTable
            .Select(i => new SelectListItem
            {
                Text = i.CategoryName,
                Value = i.CategoryID.ToString()
            }).ToList();

            ViewBag.Values = values;
            return View();
        }

        [HttpPost]
        public ActionResult NewProduct(ProductsTable p1)
        {
            var category = db.CategoriesTable.Where(m => m.CategoryID == p1.CategoriesTable.CategoryID).FirstOrDefault();
            p1.CategoriesTable = category;
            db.ProductsTable.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(int id)
        {
            var product = db.ProductsTable.Find(id);
            db.ProductsTable.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetProduct(int? id)
        {
            var product = db.ProductsTable.Find(id);

            List<SelectListItem> values = db.CategoriesTable
           .Select(i => new SelectListItem
           {
               Text = i.CategoryName,
               Value = i.CategoryID.ToString()
           }).ToList();

            ViewBag.Values = values;

            return View("GetProduct", product);
        }

        public ActionResult UpdateProduct(ProductsTable p1)
        {
            var product = db.ProductsTable.Find(p1.ProductID);
            product.ProductName = p1.ProductName;
            product.Brand = p1.Brand;
            product.Amount = p1.Amount;
            product.Price = p1.Price;
            product.ProductCategory = p1.CategoriesTable.CategoryID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}