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
    
    public partial class DocBrokeDecisionProducts
    {
        public System.Guid DocID { get; set; }
        public System.Guid ProductID { get; set; }
        public byte StateID { get; set; }
        public decimal Quantity { get; set; }
        public string Comment { get; set; }
        public Nullable<System.Guid> C1CNomenclatureID { get; set; }
        public Nullable<System.Guid> C1CCharacteristicID { get; set; }
    
        public virtual DocBroke DocBroke { get; set; }
        public virtual Products Products { get; set; }
        public virtual ProductStates ProductStates { get; set; }
    }
}
