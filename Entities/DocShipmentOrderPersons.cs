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
    
    public partial class DocShipmentOrderPersons
    {
        public System.Guid DocShipmentOrderPersonID { get; set; }
        public System.Guid DocOrderID { get; set; }
        public System.Guid PersonID { get; set; }
        public bool IsInActive { get; set; }
    
        public virtual DocShipmentOrders DocShipmentOrders { get; set; }
        public virtual Persons Persons { get; set; }
    }
}
