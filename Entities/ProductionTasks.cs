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
    
    public partial class ProductionTasks
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductionTasks()
        {
            this.ProductionTaskRWCutting = new HashSet<ProductionTaskRWCutting>();
            this.ProductionTaskBatches = new HashSet<ProductionTaskBatches>();
            this.DocProduction = new HashSet<DocProduction>();
            this.ActiveProductionTasks = new HashSet<ActiveProductionTasks>();
            this.ProductionTaskConvertingSamples = new HashSet<ProductionTaskConvertingSamples>();
            this.DocRepack = new HashSet<DocRepack>();
        }
    
        public System.Guid ProductionTaskID { get; set; }
        public Nullable<int> PlaceID { get; set; }
        public short PlaceGroupID { get; set; }
        public Nullable<System.Guid> C1CNomenclatureID { get; set; }
        public Nullable<System.Guid> C1CCharacteristicID { get; set; }
        public decimal Quantity { get; set; }
        public Nullable<System.DateTime> DateBegin { get; set; }
        public Nullable<System.DateTime> DateEnd { get; set; }
        public Nullable<System.Guid> C1CSpecificationID { get; set; }
        public string Number { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductionTaskRWCutting> ProductionTaskRWCutting { get; set; }
        public virtual ProductionTaskWR ProductionTaskWR { get; set; }
        public virtual ProductionTaskSGB ProductionTaskSGB { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductionTaskBatches> ProductionTaskBatches { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocProduction> DocProduction { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActiveProductionTasks> ActiveProductionTasks { get; set; }
        public virtual Places Places { get; set; }
        public virtual C1CCharacteristics C1CCharacteristics { get; set; }
        public virtual C1CNomenclature C1CNomenclature { get; set; }
        public virtual ProductionTaskConverting ProductionTaskConverting { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductionTaskConvertingSamples> ProductionTaskConvertingSamples { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocRepack> DocRepack { get; set; }
    }
}
