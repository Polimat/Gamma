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
    
    public partial class DocWithdrawalProducts
    {
        public System.Guid DocID { get; set; }
        public System.Guid ProductID { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<bool> CompleteWithdrawal { get; set; }
    
        public virtual DocWithdrawal DocWithdrawal { get; set; }
        public virtual Products Products { get; set; }
    }
}
