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
    
    public partial class DocProduction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DocProduction()
        {
            this.DocWithdrawal = new HashSet<DocWithdrawal>();
        }
    
        public System.Guid DocID { get; set; }
        public Nullable<System.Guid> ProductionTaskID { get; set; }
        public Nullable<int> InPlaceID { get; set; }
    
        public virtual Docs Docs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocWithdrawal> DocWithdrawal { get; set; }
        public virtual Places Places { get; set; }
        public virtual ProductionTasks ProductionTasks { get; set; }
    }
}
