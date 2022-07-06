using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPProject.Controllers
{
    public class InventoryController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        // GET: Inventory
        public ActionResult Index()
        {
            var Original_Product = from x in dc.ORIGINAL_PRODUCT select x;
            return View(Original_Product);
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
        public ActionResult Create(ORIGINAL_PRODUCT collection)
        {
            try
            {
                // TODO: Add insert logic here
                dc.ORIGINAL_PRODUCT.InsertOnSubmit(collection);
                dc.SubmitChanges();
                return RedirectToAction("Index");
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
                UpdateProduct.Name = collection.Name;
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
    }
}
