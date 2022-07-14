using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPProject.Models
{
    public class CartOrder
    {
        public int Id { get; set; }
      
        public string Email { get; set; }
        public string Address { get; set; }
        public string FullName { get; set; }
        public virtual CartItem CartItem { get; set; }

        public string TrackingId { get; set; }

        public IList<DeriveProductModel> ProductList;
    }
}