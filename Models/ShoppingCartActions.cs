using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPProject.Models;

namespace ASPProject.Models
{

    public class ShoppingCartActions : IDisposable
    {
        public string ShoppingCartId { get; set; }
        public List<CartItem> CartItemList = new List<CartItem>();
        private DataClasses1DataContext _db = new DataClasses1DataContext();

        public const string CartSessionKey = "CartId";

        public void AddToCart(int id)
        {
            // Retrieve the product from the database.           
            ShoppingCartId = GetCartId();

            var cartItem = _db.CART_ITEM.SingleOrDefault(
                c => c.CartId == ShoppingCartId
                && c.ProductId == id && c.Status ==1);
            

            if (cartItem == null)
            {
                var CurrentProduct = _db.DERIVE_PRODUCT.SingleOrDefault(
                   p => p.Id == id);
                
                // Create a new cart item if no cart item exists.
                if(CurrentProduct.Quantity > 0)
                {
                    var newcartItem = new CART_ITEM
                    {
                        Id = Guid.NewGuid().ToString(),
                        ProductId = id,
                        CartId = ShoppingCartId,

                        Quantity = 1,
                        DateCreated = DateTime.Now,
                        Status=1
                    };

                    _db.CART_ITEM.InsertOnSubmit(newcartItem);

                }
                

                //  _db.ShoppingCartItems.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart,                  
                // then add one to the quantity.
                
                cartItem.Quantity++;
            }
            _db.SubmitChanges();
        }

        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
                _db = null;
            }
        }

        public string GetCartId()
        {
            if (HttpContext.Current.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class.     
                    Guid tempCartId = Guid.NewGuid();
                    HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return HttpContext.Current.Session[CartSessionKey].ToString();
        }

        public List<CartItem> GetCartItems()
        {
            ShoppingCartId = GetCartId();
            var cartitem = _db.CART_ITEM.Where(
                c => c.CartId == ShoppingCartId && c.Status == 1);
            foreach(var item in cartitem)
            {
                
                CartItem CurrentCartItem = new CartItem()
                {
                    
                    CartId = item.CartId,
                    ItemId = item.Id,
                    Quantity = item.Quantity,
                    DateCreated = System.Convert.ToDateTime(item.DateCreated),
                    ProductId = item.ProductId,
                    Status = item.Status
                    
                };
                CurrentCartItem.SetProduct(item.ProductId);
                CartItemList.Add(CurrentCartItem);
            }
            
            
            return CartItemList;
        }
    }
}