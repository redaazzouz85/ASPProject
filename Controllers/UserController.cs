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
        public ActionResult DeriveProduct_Index()
        {
            var Derive_Product = from x in dc.DERIVE_PRODUCT select x;
            
            IList<DeriveProductModel> dpmList = new List<DeriveProductModel>();

            // Get Product types without duplication
            // 
            List<string> Types = new List<string>() ;
            foreach (var x in Derive_Product)
            {
                Types.Add(x.Product_Type);
            }
            IEnumerable<string> noDuplicate_typeList = Types.Distinct();
            ViewBag.noDuplicate_typeList = noDuplicate_typeList;

            foreach (var item in Derive_Product)
            {
                DeriveProductModel dpm = new DeriveProductModel();
                dpm.Id = item.Id;
                dpm.Name = item.Name;
                dpm.Product_Type = item.Product_Type;
                dpm.Original_Product = item.Original_Product;
                dpm.Price= item.Price;
                dpm.Quantity = item.Quantity;
                dpm.Image = item.Image;
                
               // dpm.noDuplicate_typeList = Types.Distinct();

                dpmList.Add(dpm);
            }
            return View(dpmList);
            
        }
        [HttpPost]
        
        public ActionResult DeriveProduct_Index(string SelectedDeriveCollection)
        {
            try
            {
                IList<DeriveProductModel> dpmList = new List<DeriveProductModel>();

                var All_Derive_Product = from x in dc.DERIVE_PRODUCT select x;
                var ByType_Derive_Product = from x in dc.DERIVE_PRODUCT where x.Product_Type.Trim() == SelectedDeriveCollection.Trim() select x;
                var ByOrigin_Derive_Product = from x in dc.DERIVE_PRODUCT where x.Original_Product.Trim() == SelectedDeriveCollection.Trim() select x;
                // Get Product types without duplication and pass it with viewBag, Original list too
                // 
                List<string> Types = new List<string>();
                List<string> Origins = new List<string>();
                foreach (var x in All_Derive_Product)
                {
                    Types.Add(x.Product_Type);
                    Origins.Add(x.Original_Product);
                }
                IEnumerable<string> noDuplicate_typeList = Types.Distinct();
                ViewBag.noDuplicate_typeList = noDuplicate_typeList;
                ViewBag.OriginList = Origins;

                if (ByOrigin_Derive_Product.Count() > 0)
                {
                    foreach (var item in ByOrigin_Derive_Product)
                    {
                        DeriveProductModel dpm = new DeriveProductModel();
                        dpm.Id = item.Id;
                        dpm.Name = item.Name;
                        dpm.Product_Type = item.Product_Type;
                        dpm.Original_Product = item.Original_Product;
                        dpm.Price = item.Price;
                        dpm.Quantity = item.Quantity;
                        dpm.Image = item.Image;

                        dpmList.Add(dpm);
                    }
                    return View(dpmList);
                }
                else if (ByType_Derive_Product.Count() > 0)
                {
                    foreach (var item in ByType_Derive_Product)
                    {
                        DeriveProductModel dpm = new DeriveProductModel();
                        dpm.Id = item.Id;
                        dpm.Name = item.Name;
                        dpm.Product_Type = item.Product_Type;
                        dpm.Original_Product = item.Original_Product;
                        dpm.Price = item.Price;
                        dpm.Quantity = item.Quantity;
                        dpm.Image = item.Image;

                        dpmList.Add(dpm);
                    }
                    return View(dpmList);
                }
                else if (SelectedDeriveCollection == "0")
                {
                    foreach (var item in All_Derive_Product)
                    {
                        DeriveProductModel dpm = new DeriveProductModel();
                        dpm.Id = item.Id;
                        dpm.Name = item.Name;
                        dpm.Product_Type = item.Product_Type;
                        dpm.Original_Product = item.Original_Product;
                        dpm.Price = item.Price;
                        dpm.Quantity = item.Quantity;
                        dpm.Image = item.Image;

                        dpmList.Add(dpm);
                    }
                    return View(dpmList);
                }
                else
                {
                    return View();
                }

            }
            catch (Exception err)
            {
                return View(err.Message);
            }
            
            
        }
    }
}