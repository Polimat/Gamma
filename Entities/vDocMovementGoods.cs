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
    
    public partial class vDocMovementGoods
    {
        public System.Guid DocMovementID { get; set; }
        public System.Guid C1CNomenclatureID { get; set; }
        public Nullable<System.Guid> C1CCharacteristicID { get; set; }
        public string NomenclatureName { get; set; }
        public Nullable<decimal> OutQuantity { get; set; }
        public Nullable<decimal> InQuantity { get; set; }
        public Nullable<System.Guid> C1CQualityID { get; set; }
        public Nullable<decimal> AcceptedQuantity { get; set; }
        public Nullable<System.Guid> DocOrderID { get; set; }
        public Nullable<int> BreakNumber { get; set; }
        public Nullable<int> CountProduct { get; set; }
        public Nullable<long> CountProductSpools { get; set; }
        public Nullable<int> CountProductSpoolsWithBreak { get; set; }
        public Nullable<int> OutQuantityUnits { get; set; }
        public Nullable<int> InQuantityUnits { get; set; }
        public Nullable<int> InPlaceID { get; set; }
        public Nullable<int> OutPlaceID { get; set; }
    }
}
