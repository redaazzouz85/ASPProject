using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPProject.Models;
using System.IO;

namespace ASPProject.Controllers
{
    public class InventoryController : Controller
    {
        //private readonly IWebHostEnviroment webHostEnviroment;
        DataClasses1DataContext dc = new DataClasses1DataContext();
        public static string _SelectedOriginalProduct;
        public static string _SelectedProductType;
        

        // GET: Inventory
        public ActionResult Index()
        {
            var Original_Product = from x in dc.ORIGINAL_PRODUCT select x;
            return View(Original_Product);
        }
        public ActionResult DeriveIndex()
        {
            var Derive_Product = from x in dc.DERIVE_PRODUCT select x;
            return View(Derive_Product);
        }

        // GET: Inventory/Details/5
        public ActionResult Details(int id)
        {
            var CurrentOriginalProduct = dc.ORIGINAL_PRODUCT.Single(x => x.Id == id);
            return View(CurrentOriginalProduct);
        }

        // GET: Inventory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventory/Create
        [HttpPost]
        public ActionResult Create(ORIGINAL_PRODUCT collection, HttpPostedFileBase OriginalImage)
        {
            try
            {
              /*  string fileName = Path.GetFileNameWithoutExtension(OriginalImage.FileName);
                string extension = Path.GetExtension(OriginalImage.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string ImagePath = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                OriginalImage.SaveAs(fileName);
                */
                //var path = Path.Combine(Server.MapPath("~/Content/Images"), OriginalImage.FileName);
                // OriginalImage.SaveAs(path);
                //string fileName = Guid.NewGuid().ToString() + "-" + OriginalImage;
                //var path = Path.Combine(UploadDir, fileName);

              //  collection.image = fileName;


                // TODO: Add insert logic here
                dc.ORIGINAL_PRODUCT.InsertOnSubmit(collection);
                dc.SubmitChanges();
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inventory/Create
        public ActionResult CreateDeriveProduct_OriginalSelection()
        {
            
            var OriginalProduct = from x in dc.ORIGINAL_PRODUCT select x;

            return View(OriginalProduct);
        }

        // POST: Inventory/Create
        [HttpPost]
        public ActionResult CreateDeriveProduct_OriginalSelection(string SelectedOriginalProduct)
        {
            try
            {
                // TODO: Add insert logic here
                //dc.DERIVE_PRODUCT.InsertOnSubmit(collection);
                //dc.SubmitChanges();
                //var CurrentOriginalProduct = dc.ORIGINAL_PRODUCT.Single(x => x.Title == SelectedOriginalProduct);
                _SelectedOriginalProduct = SelectedOriginalProduct;
                //ViewBag.SelectedOriginalProduct = CurrentOriginalProduct;
                //System.Console.WriteLine("test1");
                return RedirectToAction("CreateDeriveProduct_TypeSelection");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult CreateDeriveProduct_TypeSelection()
        {

            var TypeProduct = from x in dc.PRODUCT_TYPE select x;


            return View(TypeProduct);
        }

        // POST: Inventory/Create
        [HttpPost]
        public ActionResult CreateDeriveProduct_TypeSelection(string SelectedProductType)
        {
            try
            {
                // TODO: Add insert logic here
                //dc.DERIVE_PRODUCT.InsertOnSubmit(collection);
                //dc.SubmitChanges();
                //var CurrentTypeProduct = dc.PRODUCT_TYPE.Single(x => x.Title == SelectedProductType);
                _SelectedProductType=SelectedProductType;
                //ViewBag.SelectedProductType = CurrentTypeProduct;
                return RedirectToAction("CreateDeriveProduct");
                
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CreateDeriveProduct()
        {
            return View();
        }

        // POST: Inventory/Create
        [HttpPost]
        public ActionResult CreateDeriveProduct(DERIVE_PRODUCT collection)
        {
            try
            {
                DERIVE_PRODUCT NewDeriveProduct = new DERIVE_PRODUCT();

                NewDeriveProduct.Original_Product = _SelectedOriginalProduct;
                NewDeriveProduct.Product_Type = _SelectedProductType;
                NewDeriveProduct.Name = collection.Name;
                NewDeriveProduct.Price = collection.Price;
                NewDeriveProduct.Quantity = collection.Quantity;

                // TODO: Add insert logic here
                dc.DERIVE_PRODUCT.InsertOnSubmit(NewDeriveProduct);
                dc.SubmitChanges();
                return RedirectToAction("DeriveIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inventory/Edit/5
        public ActionResult Edit(int id)
        {
            var CurrentOriginalProduct = dc.ORIGINAL_PRODUCT.Single(x => x.Id == id);

            return View(CurrentOriginalProduct);
        }

        // POST: Inventory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ORIGINAL_PRODUCT collection)
        {
            try
            {
                // TODO: Add update logic here
                ORIGINAL_PRODUCT UpdateProduct = dc.ORIGINAL_PRODUCT.Single(x => x.Id == id);
                UpdateProduct.Title = collection.Title;
                UpdateProduct.Price = collection.Price;
                UpdateProduct.Description = collection.Description;
                UpdateProduct.image = collection.image;
                UpdateProduct.statut = collection.statut;
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inventory/Delete/5
        public ActionResult Delete(int id)
        {
            var CurrentOriginalProduct = dc.ORIGINAL_PRODUCT.Single(x => x.Id == id);

            return View(CurrentOriginalProduct);
        }

        // POST: Inventory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ORIGINAL_PRODUCT collection)
        {
            try
            {
                // TODO: Add delete logic here
                var CurrentOriginalProduct = dc.ORIGINAL_PRODUCT.Single(x => x.Id == id);
                dc.ORIGINAL_PRODUCT.DeleteOnSubmit(CurrentOriginalProduct);
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        /// <summary>
        /// Derive Section
        /// </summary>
        ///
        /// 

        public ActionResult Details_Derive(int id)
        {
            var CurrentDeriveProduct = dc.DERIVE_PRODUCT.Single(x => x.Id == id);
            return View(CurrentDeriveProduct);
        }
        // GET: Inventory/Edit_Derive/5
        public ActionResult Edit_Derive(int id)
        {
            var CurrentDeriveProduct = dc.DERIVE_PRODUCT.Single(x => x.Id == id);

            return View(CurrentDeriveProduct);
        }

        // POST: Inventory/Edit/5
        [HttpPost]
        public ActionResult Edit_Derive(int id, DERIVE_PRODUCT collection)
        {
            try
            {
                // TODO: Add update logic here
                DERIVE_PRODUCT UpdateProduct = dc.DERIVE_PRODUCT.Single(x => x.Id == id);
                UpdateProduct.Name = collection.Name;
                UpdateProduct.Price = collection.Price;
                UpdateProduct.Quantity = collection.Quantity;
                UpdateProduct.Image = collection.Image;
                
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inventory/Delete/5
        public ActionResult Delete_Derive(int id)
        {
            var CurrentDeriveProduct = dc.DERIVE_PRODUCT.Single(x => x.Id == id);

            return View(CurrentDeriveProduct);
        }

        // POST: Inventory/Delete/5
        [HttpPost]
        public ActionResult Delete_Derive(int id, DeriveInfo collection)
        {
            try
            {
                // TODO: Add delete logic here
                var CurrentDeriveProduct = dc.DERIVE_PRODUCT.Single(x => x.Id == id);
                dc.DERIVE_PRODUCT.DeleteOnSubmit(CurrentDeriveProduct);
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
