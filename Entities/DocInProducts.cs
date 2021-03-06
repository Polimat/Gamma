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
    
    public partial class DocInProducts
    {
        public System.Guid DocID { get; set; }
        public System.Guid ProductID { get; set; }
        public Nullable<bool> IsConfirmed { get; set; }
        public Nullable<System.Guid> PlaceZoneID { get; set; }
        public Nullable<System.Guid> PersonID { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<System.Guid> PlaceZoneCellID { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<byte> StateID { get; set; }
        public Nullable<System.Guid> MovementID { get; set; }
    
        public virtual DocMovement DocMovement { get; set; }
        public virtual Persons Persons { get; set; }
        public virtual PlaceZones PlaceZones { get; set; }
    }
}
