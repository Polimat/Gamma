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
    
    public partial class C1CDocComplectation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C1CDocComplectation()
        {
            this.C1CDocComplectationNomenclature = new HashSet<C1CDocComplectationNomenclature>();
            this.DocComplectation = new HashSet<DocComplectation>();
        }
    
        public System.Guid C1CDocComplectationID { get; set; }
        public string C1CCode { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.Guid> C1CWarehouseID { get; set; }
        public Nullable<bool> Marked { get; set; }
        public Nullable<bool> Posted { get; set; }
    
        public virtual C1CWarehouses C1CWarehouses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C1CDocComplectationNomenclature> C1CDocComplectationNomenclature { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocComplectation> DocComplectation { get; set; }
    }
}
