using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPProject.Models;
namespace ASPProject.Controllers
{
    public class CartController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        public List<CartItem> CartItemList = new List<CartItem>();
        ShoppingCartActions actions = new ShoppingCartActions();
        // GET: Cart
        public ActionResult Index(Nullable<int> id)
        {
            try
            {
                // var CartItems = from x in dc.CART_ITEM where x.CartId == id select x;
                if (id == null)
                {

                    IList<CartItem> ItemList = actions.GetCartItems();


                    return View(ItemList);



                }
                else
                {
                    using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
                    {
                        var cartId = usersShoppingCart.GetCartId();
                        usersShoppingCart.AddToCart(Convert.ToInt16(id));
                        IList<CartItem> ItemList = actions.GetCartItems();


                        return View(ItemList);

                    }

                }

            }
            catch (Exception err)
            {
                return View(err.Message);
            }
           



        }
        public ActionResult UpdateOrder(int quantity, string idCart, int? idProduct)
        {

           var currentItem = dc.CART_ITEM.FirstOrDefault(x => x.CartId == idCart && x.ProductId == idProduct);

            currentItem.Quantity = quantity;
            dc.SubmitChanges();
            IList<CartItem> ItemList = actions.GetCartItems();



            return RedirectToAction("Index");
        }
        public ActionResult Order(string userFullName, string userAddress, string userEmail,string PhoneNumber, double total)
        {
            IList<CartItem> ItemList = actions.GetCartItems();
            if (total != 0)
            {
                CartOrder cartOrder = new CartOrder()
            {
                Id = Guid.NewGuid().ToString(),
                FullName = userFullName,
                Address = userAddress,
                Email = userEmail,
                PhoneNumber = PhoneNumber,
                CartItemList = ItemList,
                DateOrder = DateTime.Now
               
               

            };
           
                cartOrder.Total = total;
                return View(cartOrder);
            }
            else
            {
                TempData["msgErr"] = "Your Cart is Empty!";
                ViewData["msg"] = TempData["msgErr"];
                return RedirectToAction("Index");
            }
        
            
        }

        public ActionResult ConfirmOrder(string FullName,string CartId,string PhoneNumber,string Address,string Email,DateTime DateOrder)
        {
            try
            {
                if (CartId != null)
                {
                    ORDERS oRDER = new ORDERS()
                    {
                        Id = Guid.NewGuid().ToString(),
                        FullName = FullName,
                        Address = Address,
                        Phone = PhoneNumber,
                        Email = Email,
                        CartId = CartId,
                        Date = DateOrder,
                        Status = 1
                        
                        
                    };

                    dc.ORDERS.InsertOnSubmit(oRDER);
                    dc.SubmitChanges();

                    if (dc.ORDERS.Contains(oRDER))
                    {
                        var CartItems = from x in dc.CART_ITEM where x.CartId == oRDER.CartId select x;
                        
                        List<CART_ITEM> CartItemsList = CartItems.ToList();

                        foreach (var item in CartItems)
                        {
                            var product = dc.DERIVE_PRODUCT.FirstOrDefault(x => x.Id == item.ProductId);

                            product.Quantity -= item.Quantity;
                            item.Status = 0;
                           // dc.CART_ITEM.DeleteOnSubmit(item);


                        }
                        dc.SubmitChanges();
                        return RedirectToAction("OrderSuccess");
                    }
                    else
                    {
                        return RedirectToAction("OrderFailed");
                    }

                }
                else
                {
                    ViewBag.Message = "Your Cart is empty.";
                    return View();
                }

            }
            catch (Exception err)
            {
                return View(err.Message);
            }
           
                
            


           
        }

        public ActionResult OrderFailed()
        {
            return View();
        }
        public ActionResult OrderSuccess()
        {
            return View();
        }


    }
}