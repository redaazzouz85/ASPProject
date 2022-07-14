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
        public ActionResult Order(string userFullName, string userAddress, string userEmail)
        {
            IList<CartItem> ItemList = actions.GetCartItems();



            return View();
        }
    }
}