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
    
    public partial class C1CPlaces
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C1CPlaces()
        {
            this.Places = new HashSet<Places>();
            this.C1CMainSpecifications = new HashSet<C1CMainSpecifications>();
        }
    
        public System.Guid C1CPlaceID { get; set; }
        public Nullable<bool> Marked { get; set; }
        public Nullable<bool> Folder { get; set; }
        public Nullable<System.Guid> ParentID { get; set; }
        public string Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Places> Places { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C1CMainSpecifications> C1CMainSpecifications { get; set; }
    }
}
