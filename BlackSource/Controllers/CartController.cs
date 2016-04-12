using BusinessData;
using BusinessData.IdentityModels;
using BusinessService;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BlackSource.Controllers
{
    public class CartController : Controller
    {
        private IRangamoRepository _RangamoRepository;
        public CartController()
        {
            this._RangamoRepository = new RangamoRepository(new ApplicationDbContext());
        }
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        private int isExisting(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.ProductId.Equals(id))
                    return i;
            return -1;
        }
        public ActionResult Buy(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
                if (Session["cart"] != null)
                {
                    List<Item> cart = (List<Item>)Session["cart"];
                    int index = isExisting(id);
                    if (index != -1)
                    {
                        cart[index].Quantity++;
                    }
                    if (index==-1)
                    {
                        cart.Add(new Item { ItemId = (cart.Count + 1), Product = db.Products.Find(id), Quantity = 1 });
                    }
                }

                if (Session["cart"] == null)
                {
                    List<Item> cart = new List<Item>();
                    cart.Add(new Item { ItemId = 1, Product = db.Products.Find(id), Quantity = 1 });
                    Session["cart"] = cart;
                }
            return View("cart");
        }
        public ActionResult Delete(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            int index = BisExisting(id);
            cart.RemoveAt(index);
            if (cart.Count == 0)
            {
                cart = null;
            }
            Session["cart"] = cart;
            return View("cart");
        }

        private int BisExisting(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.ProductId==id)
                    return i;
            return -1;
        }
    }
}