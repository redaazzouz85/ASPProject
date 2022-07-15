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
            //OriginalProductModel orm = new OriginalProductModel();
            IList<OriginalProductModel> ormList = new List<OriginalProductModel>();

            foreach(var item in Original_Product)
            {
                OriginalProductModel orm = new OriginalProductModel();
                orm.Id=item.Id;
                orm.Title = item.Title;
                orm.Price = item.Price;
                orm.ImagePath = item.Image;
                orm.getStatut(item.statut);
                orm.Description = item.Description;
                ormList.Add(orm);
            }
            return View(ormList);
        } 
        
        /** Orders **/
        public ActionResult Orders()
        {
            var Orders = from x in dc.ORDERS where x.Status == 1 select x ;
            //OriginalProductModel orm = new OriginalProductModel();
            IList<ORDERS> orderList = new List<ORDERS>();


            return View(Orders);
        }
        [HttpPost]
        public ActionResult Orders(int selectedOption)
        {
            var WaitingOrders = from x in dc.ORDERS where x.Status == 1 select x;
            var FulfilledOrders = from x in dc.ORDERS where x.Status == 0 select x;
            var AllOrders = from x in dc.ORDERS select x;
            if (selectedOption == 0)
            {
                return View(AllOrders);
            }
            else if (selectedOption == 1)
            {
                return View(WaitingOrders);
            }
            else if (selectedOption == 2)
            {
                return View(FulfilledOrders);

            }
            else
            {
                return View();
            }



        }
        public ActionResult OpenOrder(string id)
        {
            var Order = dc.ORDERS.FirstOrDefault(x=>x.Id == id) ;

            
            IList<CartItem> itemList = new List<CartItem>();
            IList<DeriveProductModel> productList = new List<DeriveProductModel>();

          //  var Cart = dc.CART_ITEM.Select(x => x.CartId == Order.CartId);
            var CartItems = from x in dc.CART_ITEM where x.CartId == Order.CartId select x;
            
            double total =0;

            CartOrder SelectedCartOrder = new CartOrder()
            {
                Id = id,
                FullName = Order.FullName,
                Address = Order.Address,
                PhoneNumber = Order.Phone,
                Email = Order.Email,
                DateOrder = Order.Date

            };

            // filling list of cartitem and product
            foreach (var item in CartItems)
            {
               
                

                var product = dc.DERIVE_PRODUCT.FirstOrDefault(x => x.Id == item.ProductId);

                DeriveProductModel DeriveProduct = new DeriveProductModel()
                {
                    Id = product.Id,
                    Product_Type = product.Product_Type,
                    Original_Product = product.Original_Product,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    Image = product.Image
                };
                CartItem cARTITEM = new CartItem()
                {
                    CartId = item.CartId,
                    ItemId = item.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    DateCreated = item.DateCreated,
                    UnitPrice = DeriveProduct.Price,
                    Product = product
                };

                total += Convert.ToDouble( cARTITEM.UnitPrice * cARTITEM.Quantity);
                
                itemList.Add(cARTITEM);
                productList.Add(DeriveProduct);

            }
           

            SelectedCartOrder.CartItemList= itemList;
            SelectedCartOrder.ProductList= productList;
            SelectedCartOrder.Total = total;

            return View(SelectedCartOrder);
        }
        [HttpPost]
        public ActionResult Fulfill(string id)
        {
            try{
                dc.ORDERS.FirstOrDefault(x => x.Id == id).Status = 0;
                dc.SubmitChanges();
                return RedirectToAction("Orders");
            }catch(Exception err)
            {
                return View(err.Message);
            }
            

            
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
        public ActionResult CreateOriginalProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateOriginalProduct(OriginalProductModel oRIGINAL_PRODUCT)
        {
            try
            {
                string fileName = Path.GetFileNameWithoutExtension(oRIGINAL_PRODUCT.ImageFile.FileName);
                string extension = Path.GetExtension(oRIGINAL_PRODUCT.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                oRIGINAL_PRODUCT.ImagePath = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                oRIGINAL_PRODUCT.ImageFile.SaveAs(fileName);

                ORIGINAL_PRODUCT newOriginalProduct = new ORIGINAL_PRODUCT()
                {
                    Title = oRIGINAL_PRODUCT.Title,
                    Price = oRIGINAL_PRODUCT.Price,
                    Description = oRIGINAL_PRODUCT.Description,
                    Image = oRIGINAL_PRODUCT.ImagePath,
                    statut = 1
                    
                };

                dc.ORIGINAL_PRODUCT.InsertOnSubmit(newOriginalProduct);
                dc.SubmitChanges();

                /* using(MyArtDataBaseEntities db = new MyArtDataBaseEntities())
                 {
                     db.ORIGINAL_PRODUCT.Add(oRIGINAL_PRODUCT);
                     db.SaveChanges();
                 }*/
                //ModelState.Clear();
                return RedirectToAction("Index");
                
            }catch
            {
                return View("Index");
            }
        }
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
        public ActionResult CreateDeriveProduct(DeriveProductModel dERIVE_PRODUCT)
        {

            try
            {
                string fileName = Path.GetFileNameWithoutExtension(dERIVE_PRODUCT.ImageFile.FileName);
                string extension = Path.GetExtension(dERIVE_PRODUCT.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                dERIVE_PRODUCT.Image = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                dERIVE_PRODUCT.ImageFile.SaveAs(fileName);

                DERIVE_PRODUCT newDeriveProduct = new DERIVE_PRODUCT()
                {
                    Original_Product = _SelectedOriginalProduct,
                    Product_Type = _SelectedProductType,
                    Name = dERIVE_PRODUCT.Name,
                    Price = dERIVE_PRODUCT.Price,
                    Quantity = dERIVE_PRODUCT.Quantity,
                    Image = dERIVE_PRODUCT.Image

                };

                dc.DERIVE_PRODUCT.InsertOnSubmit(newDeriveProduct);
                dc.SubmitChanges();

                /* using(MyArtDataBaseEntities db = new MyArtDataBaseEntities())
                 {
                     db.ORIGINAL_PRODUCT.Add(oRIGINAL_PRODUCT);
                     db.SaveChanges();
                 }*/
                //ModelState.Clear();
                return RedirectToAction("DeriveIndex");

            }
            catch
            {
                return View("DeriveIndex");
            }
            /*  try
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
              }*/
        }

        // GET: Inventory/Edit/5
        public ActionResult Edit(int id)
        {
            var CurrentOriginalProduct = dc.ORIGINAL_PRODUCT.Single(x => x.Id == id);
            OriginalProductModel editingOriginalProduct = new OriginalProductModel()
            {
                Id = CurrentOriginalProduct.Id,
                Title = CurrentOriginalProduct.Title,
                Price = CurrentOriginalProduct.Price,
                Description = CurrentOriginalProduct.Description,
                statut = CurrentOriginalProduct.statut,
                ImagePath = CurrentOriginalProduct.Image
            };

            return View(editingOriginalProduct);
        }

        // POST: Inventory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, OriginalProductModel collection, string SelectedStatus)
        {
            try
            {
                ORIGINAL_PRODUCT UpdateProduct = dc.ORIGINAL_PRODUCT.Single(x => x.Id == id);

              //  UpdateProduct.Title = collection.Title;
                UpdateProduct.Price = collection.Price;
                UpdateProduct.Description = collection.Description;
                if(SelectedStatus != "")
                {
                    UpdateProduct.statut = Convert.ToInt32(SelectedStatus);
                }
               

                if (collection.ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(collection.ImageFile.FileName);
                    string extension = Path.GetExtension(collection.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    collection.ImagePath = "~/Images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    collection.ImageFile.SaveAs(fileName);
                    UpdateProduct.Image = collection.ImagePath;
                }
                // TODO: Add update logic here

                dc.SubmitChanges ();
                return RedirectToAction("Index");
            }
            catch(Exception err)
            {
                return View(err.Message);
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

                //  var checkDerivedProduct = dc.DERIVE_PRODUCT.Single(x => x.Original_Product.Trim() == CurrentOriginalProduct.Title.Trim());
               
                var checkDerivedProduct = from x in dc.DERIVE_PRODUCT where x.Original_Product.Trim() == CurrentOriginalProduct.Title.Trim() select x ;

                if (checkDerivedProduct.Any()) {
                    ViewBag.Message = "This product have Derived product, it can't be deleted!";
                    //  System.Console.WriteLine("This product have Derived product, it can't be deleted!");
                    return View(CurrentOriginalProduct);
                }
                else
                {
                    dc.ORIGINAL_PRODUCT.DeleteOnSubmit(CurrentOriginalProduct);
                    dc.SubmitChanges();
                    return RedirectToAction("Index");
                    

                }
                

            }
            catch(Exception err)
            {
                return View(err.Message);
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


            
            DeriveProductModel editingDeriveProduct = new DeriveProductModel()
            {
                Id = CurrentDeriveProduct.Id,
                Name = CurrentDeriveProduct.Name,
                Price = CurrentDeriveProduct.Price,
                
                Quantity = CurrentDeriveProduct.Quantity,
                Image = CurrentDeriveProduct.Image
            };
            return View(editingDeriveProduct);
        }

        // POST: Inventory/Edit/5
        [HttpPost]
        public ActionResult Edit_Derive(int id, DeriveProductModel collection)
        {
            try
            {
                  DERIVE_PRODUCT UpdateProduct = dc.DERIVE_PRODUCT.Single(x => x.Id == id);
                UpdateProduct.Name = collection.Name;
                UpdateProduct.Price = collection.Price;
                UpdateProduct.Quantity = collection.Quantity;

                if (collection.ImageFile != null ) {

                    string fileName = Path.GetFileNameWithoutExtension(collection.ImageFile.FileName);
                    string extension = Path.GetExtension(collection.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    collection.Image = "~/Images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    collection.ImageFile.SaveAs(fileName);
                    UpdateProduct.Image = collection.Image;
                }
                
                // TODO: Add update logic here
               
                    
                    
                dc.SubmitChanges();
                return RedirectToAction("DeriveIndex");
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
        public ActionResult Delete_Derive(int id,DERIVE_PRODUCT collection)
        {
            try
            {
                // TODO: Add delete logic here
                var CurrentDeriveProduct = dc.DERIVE_PRODUCT.Single(x => x.Id == id);
                dc.DERIVE_PRODUCT.DeleteOnSubmit(CurrentDeriveProduct);
                dc.SubmitChanges();
                return RedirectToAction("DeriveIndex");
            }
            catch(Exception err)
            {
                return View(err.Message);
            }
        }
    }
}
