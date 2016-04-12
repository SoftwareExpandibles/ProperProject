using BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using BusinessData;
using System.Data.Entity;
using BusinessData.IdentityModels;

namespace BusinessService
{
    public class RangamoRepository:IRangamoRepository
    {
        private ApplicationDbContext _context;
        public RangamoRepository(ApplicationDbContext rangamoContext)
        {
            this._context = rangamoContext;
        }
        public IEnumerable<InventoryItems> GetInventories()
        {
            return _context.Inventory.ToList();
        }
        public InventoryItems GetInventoryById(int inventoryId)
        {
            return _context.Inventory.Find(inventoryId);
        }
        public void InsertInventory(InventoryItems inventory)
        {
            _context.Inventory.Add(inventory);
        }
        public void DeleteInventory(int inventoryId)
        {
            InventoryItems inventory = _context.Inventory.Find(inventoryId);
            _context.Inventory.Remove(inventory);
        }
        public void UpdateInventory(InventoryItems inventory)
        {
            _context.Entry(inventory).State = EntityState.Modified;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
        public Product GetProductById(int productId)
        {
            return _context.Products.Find(productId);
        }
        public void InsertProduct(Product product)
        {
            _context.Products.Add(product);
        }
        public void DeleteProduct(int productId)
        {
            Product product = _context.Products.Find(productId);
            _context.Products.Remove(product);
        }
        public void UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
        }
        public void ProductSave()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}