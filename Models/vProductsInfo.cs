//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gamma.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class vProductsInfo
    {
        public System.Guid DocID { get; set; }
        public System.Guid ProductID { get; set; }
        public byte ProductKindID { get; set; }
        public string Number { get; set; }
        public System.DateTime Date { get; set; }
        public string BarCode { get; set; }
        public string PrintName { get; set; }
        public Nullable<System.Guid> C1CNomenclatureID { get; set; }
        public Nullable<System.Guid> C1CCharacteristicID { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public string BaseMeasureUnit { get; set; }
        public Nullable<decimal> BaseMeasureUnitQuantity { get; set; }
        public decimal ProductionQuantity { get; set; }
        public Nullable<decimal> GrossQuantity { get; set; }
        public Nullable<decimal> BaseMeasureUnitGrossQuantity { get; set; }
        public string NomenclatureName { get; set; }
        public string ShortNomenclatureName { get; set; }
        public string Place { get; set; }
        public Nullable<int> PlaceID { get; set; }
        public short PlaceGroupID { get; set; }
        public Nullable<byte> ShiftID { get; set; }
        public byte StateID { get; set; }
        public Nullable<decimal> ChangeStateQuantity { get; set; }
        public string RejectionReason { get; set; }
        public Nullable<bool> IsConfirmed { get; set; }
        public Nullable<bool> IsWrittenOff { get; set; }
        public string State { get; set; }
        public Nullable<System.Guid> C1CQualityID { get; set; }
    }
}
