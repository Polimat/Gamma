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
    
    public partial class GetDocCloseShiftWarehouseMovements_Result
    {
        public System.Guid ProductID { get; set; }
        public System.Guid NomenclatureID { get; set; }
        public Nullable<System.Guid> CharacteristicID { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public string Number { get; set; }
        public string Nomenclature { get; set; }
        public string ProductKindName { get; set; }
        public string OrderTypeName { get; set; }
        public string InPlace { get; set; }
        public string InPlaceZone { get; set; }
        public string OutPlace { get; set; }
        public string OutPlaceZone { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string State { get; set; }
        public Nullable<byte> StateID { get; set; }
    }
}
