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
    
    public partial class DocCloseShiftMovementProducts
    {
        public System.Guid DocCloseShiftMovementProductID { get; set; }
        public System.Guid DocID { get; set; }
        public System.Guid DocMovementID { get; set; }
        public System.Guid ProductID { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public string MovementPlaceName { get; set; }
        public string MovementPlaceZoneName { get; set; }
        public Nullable<System.DateTime> DateMovement { get; set; }
        public Nullable<bool> IsMovementIn { get; set; }
    
        public virtual DocMovement DocMovement { get; set; }
        public virtual Docs Docs { get; set; }
        public virtual Products Products { get; set; }
    }
}