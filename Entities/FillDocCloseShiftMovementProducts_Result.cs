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
    
    public partial class FillDocCloseShiftMovementProducts_Result
    {
        public string NomenclatureName { get; set; }
        public string Number { get; set; }
        public System.Guid ProductID { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public string ProductKindName { get; set; }
        public string OrderTypeName { get; set; }
        public string InPlace { get; set; }
        public string InPlaceZone { get; set; }
        public Nullable<System.DateTime> InDate { get; set; }
        public string OutPlace { get; set; }
        public string OutPlaceZone { get; set; }
        public Nullable<System.DateTime> OutDate { get; set; }
        public Nullable<bool> IsMovementIn { get; set; }
        public Nullable<bool> IsMovementOut { get; set; }
        public System.Guid DocMovementID { get; set; }
        public System.Guid NomenclatureID { get; set; }
        public Nullable<System.Guid> CharacteristicID { get; set; }
        public string MeasureUnit { get; set; }
        public Nullable<System.Guid> MeasureUnitID { get; set; }
        public Nullable<byte> NomenclatureKindID { get; set; }
        public Nullable<bool> IsProductionProduct { get; set; }
        public Nullable<bool> IsMaterial { get; set; }
        public byte ProductKindID { get; set; }
    }
}
