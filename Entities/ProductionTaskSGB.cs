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
    using System.Collections.Generic;
    
    public partial class ProductionTaskSGB
    {
        public System.Guid ProductionTaskID { get; set; }
        public Nullable<int> Diameter { get; set; }
        public Nullable<int> DiameterPlus { get; set; }
        public Nullable<int> DiameterMinus { get; set; }
        public Nullable<int> Crepe { get; set; }
        public string TechSpecification { get; set; }
        public string QualitySpecification { get; set; }
    
        public virtual ProductionTasks ProductionTasks { get; set; }
    }
}
