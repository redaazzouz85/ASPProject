using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPProject.Models
{
    public class ProductTypeModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductTypeModel()
        {
            this.DERIVE_PRODUCT = new HashSet<DERIVE_PRODUCT>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DERIVE_PRODUCT> DERIVE_PRODUCT { get; set; }
    }
}