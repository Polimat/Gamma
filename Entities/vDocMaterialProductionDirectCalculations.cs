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
    
    public partial class vDocMaterialProductionDirectCalculations
    {
        public System.Guid DocID { get; set; }
        public System.Guid C1CNomenclatureID { get; set; }
        public Nullable<System.Guid> C1CCharacteristicID { get; set; }
        public Nullable<System.Guid> C1CMeasureUnitID { get; set; }
        public Nullable<bool> WithdrawByFact { get; set; }
        public string NomenclatureName { get; set; }
        public string MeasureUnitName { get; set; }
        public Nullable<bool> QuantityIsReadOnly { get; set; }
        public Nullable<decimal> QuantityRemainderAtBegin { get; set; }
        public Nullable<decimal> QuantityIn { get; set; }
        public Nullable<decimal> QuantityOut { get; set; }
        public Nullable<decimal> QuantityUtil { get; set; }
        public Nullable<decimal> QuantityExperimental { get; set; }
        public Nullable<decimal> QuantityRemainderAtEnd { get; set; }
        public Nullable<decimal> QuantitySend { get; set; }
        public Nullable<decimal> StandardQuantity { get; set; }
        public Nullable<System.Guid> ParentID { get; set; }
        public string ParentName { get; set; }
        public Nullable<decimal> QuantitySendAtBegin { get; set; }
        public Nullable<decimal> QuantitySendAtEnd { get; set; }
    }
}
