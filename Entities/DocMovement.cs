//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gamma.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class DocMovement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DocMovement()
        {
            this.DocInProducts = new HashSet<DocInProducts>();
            this.DocOutProducts = new HashSet<DocOutProducts>();
            this.DocMovementOrder = new HashSet<DocMovementOrder>();
        }
    
        public System.Guid DocID { get; set; }
        public Nullable<int> OutPlaceID { get; set; }
        public Nullable<int> InPlaceID { get; set; }
        public Nullable<int> TransferPlaceID { get; set; }
        public Nullable<System.Guid> DocOrderID { get; set; }
        public Nullable<byte> OrderTypeID { get; set; }
        public Nullable<System.DateTime> OutDate { get; set; }
        public Nullable<System.DateTime> InDate { get; set; }
    
        public virtual Docs Docs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocInProducts> DocInProducts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocOutProducts> DocOutProducts { get; set; }
        public virtual DocShipmentOrders DocShipmentOrders { get; set; }
        public virtual Places InPlaces { get; set; }
        public virtual Places OutPlaces { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocMovementOrder> DocMovementOrder { get; set; }
    }
}
