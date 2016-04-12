using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlackSource.Models;
using BusinessModel;
using BusinessData;
using BusinessData.IdentityModels;
using BusinessService;

namespace BlackSource.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private IRangamoRepository _rangamoRepository;
        // GET: Products
        public ProductsController()
        {
            this._rangamoRepository = new RangamoRepository(new ApplicationDbContext());
        }
        public ActionResult Index()
        {
            var products = from product in _rangamoRepository.GetProducts() select product;
            //return View(db.Products.ToList());
            return View(products);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           // Product product = _rangamoRepository.GetProductById(id);
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,Title,Genre,Photo,Size,Colour,SellingPrice,InventoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                _rangamoRepository.InsertProduct(product);
                _rangamoRepository.Save();
               // db.Products.Add(product);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Title,Genre,Photo,Size,Colour,SellingPrice,InventoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                _rangamoRepository.UpdateProduct(product);
                _rangamoRepository.Save();
                //db.Entry(product).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            _rangamoRepository.DeleteProduct(id);
            _rangamoRepository.Save();
            //db.Products.Remove(product);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _rangamoRepository.Dispose();
               // db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
