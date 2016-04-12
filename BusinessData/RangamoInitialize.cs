using System.Collections.Generic;
using BusinessModel;
using System.Data.Entity;
using BusinessData.IdentityModels;

namespace BusinessData
{
    public class RangamoInitialize : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var products = new List<Product>
            {
                new Product {ProductId=1,InventoryId=1,Title="afDress",Colour="Purple",Genre="For Women",Photo="afDress.jpg",Size="Medium",SellingPrice=50},
                new Product {ProductId=2,InventoryId=2,Title="anotherGreyDress",Colour="Grey",Genre="For Women",Photo="anotherGreyD.jpg",Size="Medium",SellingPrice=110},
                new Product {ProductId=3,InventoryId=3,Title="BandMeDress",Colour="Orange amd Brown",Genre="For Women and Traditional",Photo="BandMerDress.jpg",Size="Medium",SellingPrice=150},
                new Product {ProductId=4,InventoryId=4,Title="BDesignDress",Colour="Brown and Yellow",Genre="For Women and Traditional",Photo="BDesignDress.jpg",Size="Medium",SellingPrice=180},
                new Product {ProductId=5,InventoryId=5,Title="BlackDress",Colour="Black",Genre="For Women and Weddings",Photo="BlacDress.jpg",Size="Large",SellingPrice=350},
                new Product {ProductId=6,InventoryId=6,Title="BlueMenSuit",Colour="Blue",Genre="For Men",Photo="BlueMenSuit.jpg",Size="Medium",SellingPrice=1200},
                new Product {ProductId=7,InventoryId=7,Title="Blue-T",Colour="Blue",Genre="For Men",Photo="blueTMen.jpg",Size="Medium",SellingPrice=50}
            };
            products.ForEach(p => context.Products.Add(p));
            var inventories = new List<InventoryItems>
            {
                new InventoryItems {InventoryId=1,ProductId=1,QuantityOnHand=100,ReOrderQuantity=25 },
                new InventoryItems {InventoryId=7,ProductId=7,QuantityOnHand=100,ReOrderQuantity=25 }
            };
            inventories.ForEach(d => context.Inventory.Add(d));
            context.SaveChanges();
        }
    }
}