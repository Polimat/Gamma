//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gamma.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DocProduction
    {
        public DocProduction()
        {
            this.DocWithdrawal = new HashSet<DocWithdrawal>();
        }
    
        public System.Guid DocID { get; set; }
        public Nullable<System.Guid> ProductionTaskID { get; set; }
        public Nullable<int> InPlaceID { get; set; }
    
        public virtual Docs Docs { get; set; }
        public virtual Places Places { get; set; }
        public virtual ICollection<DocWithdrawal> DocWithdrawal { get; set; }
        public virtual ProductionTasks ProductionTasks { get; set; }
    }
}
