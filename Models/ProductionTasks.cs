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
    
    public partial class ProductionTasks
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductionTasks()
        {
            this.DocProduction = new HashSet<DocProduction>();
            this.ProductionTaskRWCutting = new HashSet<ProductionTaskRWCutting>();
            this.ProductionTaskBatches = new HashSet<ProductionTaskBatches>();
        }
    
        public System.Guid ProductionTaskID { get; set; }
        public Nullable<int> PlaceID { get; set; }
        public short PlaceGroupID { get; set; }
        public Nullable<System.Guid> C1CNomenclatureID { get; set; }
        public Nullable<System.Guid> C1CCharacteristicID { get; set; }
        public decimal Quantity { get; set; }
        public Nullable<System.DateTime> DateBegin { get; set; }
        public Nullable<System.DateTime> DateEnd { get; set; }
    
        public virtual C1CCharacteristics C1CCharacteristics { get; set; }
        public virtual C1CNomenclature C1CNomenclature { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocProduction> DocProduction { get; set; }
        public virtual Places Places { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductionTaskRWCutting> ProductionTaskRWCutting { get; set; }
        public virtual ProductionTaskSGB ProductionTaskSGB { get; set; }
        public virtual ProductionTaskWR ProductionTaskWR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductionTaskBatches> ProductionTaskBatches { get; set; }
    }
}
