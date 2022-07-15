using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPProject.Models
{
    public class CartOrder
    {
        public string Id { get; set; }
        
        public string Email { get; set; }
        public string Address { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public virtual CartItem CartItem { get; set; }
        public DateTime? DateOrder { get; set; }
        public double Total { get; set; }
        public int Status { get; set; }

        public IList<DeriveProductModel> ProductList;
        public IList<CartItem> CartItemList;
    }
}