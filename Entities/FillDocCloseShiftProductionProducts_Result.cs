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
    
    public partial class FillDocCloseShiftProductionProducts_Result
    {
        public System.Guid NomenclatureID { get; set; }
        public Nullable<System.Guid> CharacteristicID { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public System.Guid ProductID { get; set; }
        public System.Guid DocID { get; set; }
        public string NomenclatureName { get; set; }
        public string Number { get; set; }
        public System.DateTime Date { get; set; }
        public byte ProductKindID { get; set; }
    }
}
