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
    
    public partial class C1CMeasureUnitQualifiers
    {
        public C1CMeasureUnitQualifiers()
        {
            this.C1CMeasureUnits = new HashSet<C1CMeasureUnits>();
            this.C1CNomenclature = new HashSet<C1CNomenclature>();
        }
    
        public System.Guid C1CMeasureUnitQualifierID { get; set; }
        public string C1CCode { get; set; }
        public Nullable<bool> IsInteger { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<C1CMeasureUnits> C1CMeasureUnits { get; set; }
        public virtual ICollection<C1CNomenclature> C1CNomenclature { get; set; }
    }
}
