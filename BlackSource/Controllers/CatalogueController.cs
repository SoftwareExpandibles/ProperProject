using BusinessData;
using BusinessData.IdentityModels;
using BusinessService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlackSource.Controllers
{
    public class CatalogueController : Controller
    {
        private IRangamoRepository _RangamoRepository;
        public CatalogueController()
        {
            this._RangamoRepository = new RangamoRepository(new ApplicationDbContext());
        }
        // GET: Catalogue
        public ActionResult Index()
        {
            ViewBag.ListProducts = _RangamoRepository.GetProducts();
            return View();
        }
    }
}