using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPProject.Models;

namespace ASPProject.Controllers
{
    public class UserController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        // GET: User
        public ActionResult Index()
        {
            var Original_Product = from x in dc.ORIGINAL_PRODUCT select x;
            //OriginalProductModel orm = new OriginalProductModel();
            IList<OriginalProductModel> ormList = new List<OriginalProductModel>();

            foreach (var item in Original_Product)
            {
                OriginalProductModel orm = new OriginalProductModel();
                orm.Id = item.Id;
                orm.Title = item.Title;
                orm.Price = item.Price;
                orm.ImagePath = item.Image;
                orm.getStatut(item.statut);
                orm.Description = item.Description;
                ormList.Add(orm);
            }
            return View(ormList);

        }
        public ActionResult DeriveIndex(string originalProduct)
        {
            var Derive_Product = from x in dc.DERIVE_PRODUCT where x.Original_Product.Trim() == originalProduct.Trim() select x;
            return View(Derive_Product);
        }
    }
}