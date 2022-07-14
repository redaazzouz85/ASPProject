using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ASPProject.Models
{
    public class CartItem
    {
        private DataClasses1DataContext _db = new DataClasses1DataContext();

        [Key]
        public string ItemId { get; set; }

        public string CartId { get; set; }

        public int? Quantity { get; set; }

        public DateTime DateCreated { get; set; }

        public int? ProductId { get; set; }

        public virtual DERIVE_PRODUCT Product { get; set; }

        public DERIVE_PRODUCT SetProduct (int? id) 
        {
           return Product = _db.DERIVE_PRODUCT.FirstOrDefault(x => x.Id == id);
            
        }

    }
}

