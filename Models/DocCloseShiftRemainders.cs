//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gamma.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DocCloseShiftRemainders
    {
        public System.Guid DocCloseShiftRemainderID { get; set; }
        public System.Guid DocID { get; set; }
        public Nullable<System.Guid> ProductID { get; set; }
        public decimal Quantity { get; set; }
        public Nullable<bool> IsSourceProduct { get; set; }
    
        public virtual Docs Docs { get; set; }
    }
}
