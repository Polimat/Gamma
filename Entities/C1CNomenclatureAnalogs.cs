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
    
    public partial class C1CNomenclatureAnalogs
    {
        public System.Guid ID { get; set; }
        public Nullable<System.Guid> C1CNomenclatureID { get; set; }
        public Nullable<System.Guid> C1CCharacteristicID { get; set; }
        public Nullable<System.Guid> C1CNomenclatureAnalogID { get; set; }
        public Nullable<System.Guid> C1CCharacteristicAnalogID { get; set; }
        public Nullable<System.Guid> C1COutputNomenclatureID { get; set; }
        public Nullable<System.Guid> C1COutputCharacteristicID { get; set; }
        public Nullable<System.Guid> C1CSpecificationID { get; set; }
        public Nullable<decimal> Priority { get; set; }
        public Nullable<System.Guid> C1CMeasureUnitID { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<System.Guid> C1CMeasureUnitAnalogID { get; set; }
        public Nullable<decimal> AmountAnalog { get; set; }
    
        public virtual C1CSpecifications C1CSpecifications { get; set; }
        public virtual C1CMeasureUnits C1CMeasureUnits { get; set; }
        public virtual C1CMeasureUnits C1CAnalogMeasureUnits { get; set; }
        public virtual C1CCharacteristics C1CCharacteristics { get; set; }
        public virtual C1CCharacteristics C1CCharacteristics1 { get; set; }
        public virtual C1CCharacteristics C1CCharacteristics2 { get; set; }
        public virtual C1CNomenclature C1CNomenclature { get; set; }
        public virtual C1CNomenclature C1CAnalogNomenclature { get; set; }
        public virtual C1CNomenclature C1CNomenclature2 { get; set; }
    }
}
