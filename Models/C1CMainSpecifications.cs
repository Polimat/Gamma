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
    
    public partial class C1CMainSpecifications
    {
        public System.Guid ID { get; set; }
        public Nullable<System.DateTime> Period { get; set; }
        public Nullable<System.Guid> C1CNomenclatureID { get; set; }
        public Nullable<System.Guid> C1CCharacteristicID { get; set; }
        public Nullable<System.Guid> C1CSpecificationID { get; set; }
        public Nullable<System.Guid> C1CPlaceID { get; set; }
    
        public virtual C1CCharacteristics C1CCharacteristics { get; set; }
        public virtual C1CNomenclature C1CNomenclature { get; set; }
        public virtual C1CSpecifications C1CSpecifications { get; set; }
        public virtual C1CPlaces C1CPlaces { get; set; }
    }
}