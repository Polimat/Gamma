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
    
    public partial class DocMaterialTankGroups
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DocMaterialTankGroups()
        {
            this.DocMaterialTankGroups1 = new HashSet<DocMaterialTankGroups>();
            this.DocMaterialTanks = new HashSet<DocMaterialTanks>();
            this.C1CNomenclature = new HashSet<C1CNomenclature>();
        }
    
        public int DocMaterialTankGroupID { get; set; }
        public string Name { get; set; }
        public int PlaceID { get; set; }
        public Nullable<int> NextDocMaterialTankGroupID { get; set; }
        public Nullable<int> DocMaterialProductionTypeID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocMaterialTankGroups> DocMaterialTankGroups1 { get; set; }
        public virtual DocMaterialTankGroups DocMaterialTankGroups2 { get; set; }
        public virtual Places Places { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocMaterialTanks> DocMaterialTanks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C1CNomenclature> C1CNomenclature { get; set; }
    }
}