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
    
    public partial class DocCloseShiftUtilizationProducts
    {
        public System.Guid DocCloseShiftUtilizationProductID { get; set; }
        public System.Guid DocID { get; set; }
        public System.Guid ProductID { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<bool> IsMaterial { get; set; }
    
        public virtual Docs Docs { get; set; }
        public virtual Products Products { get; set; }
    }
}
