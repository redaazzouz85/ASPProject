using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ASPProject.Models
{
    public class OriginalProductModel
    {
      
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
       /* public ORIGINAL_PRODUCT()
        {
            this.DERIVE_PRODUCT = new HashSet<DERIVE_PRODUCT>();
        }
       */
        public int Id { get; set; }
        public string Title { get; set; }
        public Nullable<double> Price { get; set; }
        public string Description { get; set; }
        public Nullable<int> statut { get; set; }
        [DisplayName("Upload file")]
        public string ImagePath { get; set; }
        [DisplayName("Status")]
        public string statusS { get; set; }

        public string getStatut(int? statusInt)
        {
            
            if(statusInt == 0)
            {
                statusS = "Sold";
            }else if(statusInt == 1)
            {
                statusS = "Available";
            }
            return statusS;
        }
        public HttpPostedFileBase ImageFile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DERIVE_PRODUCT> DERIVE_PRODUCT { get; set; }
    }
}
