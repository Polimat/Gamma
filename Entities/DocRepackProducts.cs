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
    
    public partial class DocRepackProducts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DocRepackProducts()
        {
            this.DocWithdrawal = new HashSet<DocWithdrawal>();
        }
    
        public System.Guid DocRepackProductID { get; set; }
        public System.Guid DocID { get; set; }
        public System.Guid ProductID { get; set; }
        public Nullable<bool> IsConfirmed { get; set; }
        public Nullable<System.Guid> PersonID { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<decimal> QuantityGood { get; set; }
        public Nullable<decimal> QuantityBroke { get; set; }
        public Nullable<byte> StateID { get; set; }
        public Nullable<System.Guid> DocBrokeID { get; set; }
        public Nullable<decimal> Quantity { get; set; }
    
        public virtual DocBrokeProducts DocBrokeProducts { get; set; }
        public virtual DocRepack DocRepack { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocWithdrawal> DocWithdrawal { get; set; }
    }
}
