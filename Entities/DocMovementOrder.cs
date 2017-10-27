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
    
    public partial class DocMovementOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DocMovementOrder()
        {
            this.DocMovementOrderNomenclature = new HashSet<DocMovementOrderNomenclature>();
            this.DocMovement = new HashSet<DocMovement>();
        }
    
        public System.Guid DocID { get; set; }
        public Nullable<System.Guid> C1CDocID { get; set; }
        public Nullable<int> PlaceFrom { get; set; }
        public int PlaceTo { get; set; }
    
        public virtual Docs Docs { get; set; }
        public virtual Places PlacesFrom { get; set; }
        public virtual Places PlacesTo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocMovementOrderNomenclature> DocMovementOrderNomenclature { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocMovement> DocMovement { get; set; }
    }
}
