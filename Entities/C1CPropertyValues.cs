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
    
    public partial class C1CPropertyValues
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C1CPropertyValues()
        {
            this.C1CCharacteristicProperties = new HashSet<C1CCharacteristicProperties>();
            this.C1CNomenclatureProperties = new HashSet<C1CNomenclatureProperties>();
            this.C1CPropertyValueGammaPropertyValue = new HashSet<C1CPropertyValueGammaPropertyValue>();
        }
    
        public System.Guid C1CPropertyValueID { get; set; }
        public string C1CCode { get; set; }
        public Nullable<System.Guid> C1CPropertyID { get; set; }
        public Nullable<byte> ValueType { get; set; }
        public Nullable<bool> Marked { get; set; }
        public Nullable<bool> Folder { get; set; }
        public Nullable<System.Guid> ParentID { get; set; }
        public string Description { get; set; }
        public string PrintDescription { get; set; }
        public Nullable<decimal> ValueNumeric { get; set; }
        public string SortValue { get; set; }
        public Nullable<bool> NotForName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C1CCharacteristicProperties> C1CCharacteristicProperties { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C1CNomenclatureProperties> C1CNomenclatureProperties { get; set; }
        public virtual C1CProperties C1CProperties { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C1CPropertyValueGammaPropertyValue> C1CPropertyValueGammaPropertyValue { get; set; }
    }
}
