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
    
    public partial class SpoolInstallLog
    {
        public System.Guid SpoolInstallLogID { get; set; }
        public Nullable<int> PlaceID { get; set; }
        public Nullable<byte> ShiftID { get; set; }
        public Nullable<byte> UnwinderID { get; set; }
        public Nullable<System.Guid> ProductID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual Places Places { get; set; }
        public virtual Products Products { get; set; }
    }
}
