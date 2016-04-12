using BusinessModel;
using BusinessModel.Models;
using System;
using System.Collections.Generic;

namespace BusinessData
{
   public  interface IRangamoRepository:IDisposable
    {
        IEnumerable<InventoryItems> GetInventories();
        InventoryItems GetInventoryById(int inventoryId);
        void InsertInventory(InventoryItems inventory);
        void DeleteInventory(int inventoryId);
        void UpdateInventory(InventoryItems inventory);
        IEnumerable<Product> GetProducts();
        Product GetProductById(int productId);
        void InsertProduct(Product product);
        void DeleteProduct(int productId);
        void UpdateProduct(Product product);
        void Save();
    }
}
