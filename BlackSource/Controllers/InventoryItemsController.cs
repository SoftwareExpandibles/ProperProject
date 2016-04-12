using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessData.IdentityModels;
using BusinessModel;
using BusinessData;
using BusinessService;

namespace BlackSource.Controllers
{
    public class InventoryItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private IRangamoRepository _ranagamoRepository;
        public InventoryItemsController()
        {
            this._ranagamoRepository = new RangamoRepository(new ApplicationDbContext());
        }
        // GET: InventoryItems
        public ActionResult Index()
        {
            var inventory=_ranagamoRepository.GetInventories(); 
            //var inventory = db.Inventory.Include(i => i.Product);
            return View(inventory);
        }

        // GET: InventoryItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryItems inventoryItems = db.Inventory.Find(id);
            if (inventoryItems == null)
            {
                return HttpNotFound();
            }
            return View(inventoryItems);
        }

        // GET: InventoryItems/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Title");
            return View();
        }

        // POST: InventoryItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InventoryId,ReOrderQuantity,ProductId,QuantityOnHand")] InventoryItems inventoryItems)
        {
            if (ModelState.IsValid)
            {
                _ranagamoRepository.InsertInventory(inventoryItems);
                _ranagamoRepository.Save();
                //db.Inventory.Add(inventoryItems);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Title", inventoryItems.ProductId);
            return View(inventoryItems);
        }

        // GET: InventoryItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryItems inventoryItems = db.Inventory.Find(id);
            if (inventoryItems == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Title", inventoryItems.ProductId);
            return View(inventoryItems);
        }

        // POST: InventoryItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InventoryId,ReOrderQuantity,ProductId,QuantityOnHand")] InventoryItems inventoryItems)
        {
            if (ModelState.IsValid)
            {
                _ranagamoRepository.UpdateInventory(inventoryItems);
                _ranagamoRepository.Save();
            //    db.Entry(inventoryItems).State = EntityState.Modified;
              //  db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Title", inventoryItems.ProductId);
            return View(inventoryItems);
        }

        // GET: InventoryItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryItems inventoryItems = db.Inventory.Find(id);
            if (inventoryItems == null)
            {
                return HttpNotFound();
            }
            return View(inventoryItems);
        }

        // POST: InventoryItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InventoryItems inventoryItems = db.Inventory.Find(id);
            _ranagamoRepository.DeleteInventory(id);
            _ranagamoRepository.Save();
            //db.Inventory.Remove(inventoryItems);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _ranagamoRepository.Dispose();
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
