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
    
    public partial class GetProductionTaskBatchProducts_Result
    {
        public System.Guid DocID { get; set; }
        public Nullable<byte> ProductKindID { get; set; }
        public System.Guid ProductID { get; set; }
        public string Number { get; set; }
        public System.DateTime Date { get; set; }
        public string Place { get; set; }
        public string NomenclatureName { get; set; }
        public Nullable<System.Guid> NomenclatureID { get; set; }
        public Nullable<System.Guid> CharacteristicID { get; set; }
        public Nullable<int> Quantity { get; set; }
    }
}
