using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPProject.Models
{
    public class DeriveProductModel
    {
        public int Id { get; set; }
        public string Product_Type { get; set; }
        public string Original_Product { get; set; }
        public string Name { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string Image { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

        public virtual ORIGINAL_PRODUCT ORIGINAL_PRODUCT1 { get; set; }
        public virtual PRODUCT_TYPE PRODUCT_TYPE1 { get; set; }
    }
}