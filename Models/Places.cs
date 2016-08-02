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
    
    public partial class Places
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Places()
        {
            this.DocMovement = new HashSet<DocMovement>();
            this.DocMovement1 = new HashSet<DocMovement>();
            this.DocProduction = new HashSet<DocProduction>();
            this.Docs = new HashSet<Docs>();
            this.DocWithdrawal = new HashSet<DocWithdrawal>();
            this.ProductionTasks = new HashSet<ProductionTasks>();
            this.Rests = new HashSet<Rests>();
            this.SpoolInstallLog = new HashSet<SpoolInstallLog>();
            this.Users = new HashSet<Users>();
        }
    
        public int PlaceID { get; set; }
        public Nullable<System.Guid> PlaceGuid { get; set; }
        public int BranchID { get; set; }
        public Nullable<int> BranchUnitID { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
        public short DepartmentID { get; set; }
        public Nullable<short> PlaceGroupID { get; set; }
        public Nullable<bool> IsProductionPlace { get; set; }
        public Nullable<bool> IsWarehouse { get; set; }
        public Nullable<System.Guid> C1CPlaceID { get; set; }
        public Nullable<int> UnwindersCount { get; set; }
    
        public virtual Branches Branches { get; set; }
        public virtual Departments Departments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocMovement> DocMovement { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocMovement> DocMovement1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocProduction> DocProduction { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Docs> Docs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocWithdrawal> DocWithdrawal { get; set; }
        public virtual PlaceGroups PlaceGroups { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductionTasks> ProductionTasks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rests> Rests { get; set; }
        public virtual SourceSpools SourceSpools { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SpoolInstallLog> SpoolInstallLog { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Users> Users { get; set; }
        public virtual C1CPlaces C1CPlaces { get; set; }
    }
}
