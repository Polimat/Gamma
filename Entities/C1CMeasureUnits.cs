//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gamma.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class C1CMeasureUnits
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C1CMeasureUnits()
        {
            this.C1CNomenclatureGroups = new HashSet<C1CNomenclatureGroups>();
            this.C1CNomenclatureAnalogs = new HashSet<C1CNomenclatureAnalogs>();
            this.C1CNomenclatureAnalogs1 = new HashSet<C1CNomenclatureAnalogs>();
            this.C1CSpecificationInputNomenclature = new HashSet<C1CSpecificationInputNomenclature>();
            this.C1CDocShipmentOrderGoods = new HashSet<C1CDocShipmentOrderGoods>();
            this.C1CCharacteristics = new HashSet<C1CCharacteristics>();
            this.C1CCharacteristics1 = new HashSet<C1CCharacteristics>();
        }
    
        public System.Guid C1CMeasureUnitID { get; set; }
        public Nullable<System.Guid> C1CNomenclatureID { get; set; }
        public Nullable<System.Guid> C1CMeasureUnitQualifierID { get; set; }
        public string C1CCode { get; set; }
        public Nullable<decimal> Coefficient { get; set; }
        public string Name { get; set; }
    
        public virtual C1CMeasureUnitQualifiers C1CMeasureUnitQualifiers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C1CNomenclatureGroups> C1CNomenclatureGroups { get; set; }
        public virtual C1CNomenclature C1CNomenclature { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C1CNomenclatureAnalogs> C1CNomenclatureAnalogs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C1CNomenclatureAnalogs> C1CNomenclatureAnalogs1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C1CSpecificationInputNomenclature> C1CSpecificationInputNomenclature { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C1CDocShipmentOrderGoods> C1CDocShipmentOrderGoods { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C1CCharacteristics> C1CCharacteristics { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C1CCharacteristics> C1CCharacteristics1 { get; set; }
    }
}