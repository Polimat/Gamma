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
    
    public partial class DocComplectation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DocComplectation()
        {
            this.DocProduction = new HashSet<DocProduction>();
            this.DocWithdrawal = new HashSet<DocWithdrawal>();
        }
    
        public System.Guid DocComplectationID { get; set; }
        public System.Guid C1CDocComplectationID { get; set; }
        public Nullable<bool> IsReturned { get; set; }
    
        public virtual C1CDocComplectation C1CDocComplectation { get; set; }
        public virtual Docs Docs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocProduction> DocProduction { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocWithdrawal> DocWithdrawal { get; set; }
    }
}
