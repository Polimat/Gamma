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
    
    public partial class C1CDocComplectationNomenclature
    {
        public System.Guid C1CDocComplectationID { get; set; }
        public decimal LineNumber { get; set; }
        public System.Guid C1CNomenclatureID { get; set; }
        public System.Guid C1COldCharacteristicID { get; set; }
        public System.Guid C1CNewCharacteristicID { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<System.Guid> C1CMeasureUnitID { get; set; }
        public Nullable<System.Guid> C1CQualityID { get; set; }
    
        public virtual C1CCharacteristics C1CCharacteristics { get; set; }
        public virtual C1CCharacteristics C1CCharacteristics1 { get; set; }
        public virtual C1CDocComplectation C1CDocComplectation { get; set; }
        public virtual C1CMeasureUnits C1CMeasureUnits { get; set; }
        public virtual C1CNomenclature C1CNomenclature { get; set; }
        public virtual C1CQuality C1CQuality { get; set; }
    }
}
