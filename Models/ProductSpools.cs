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
    
    public partial class ProductSpools
    {
        public ProductSpools()
        {
            this.SourceSpools = new HashSet<SourceSpools>();
            this.SourceSpools1 = new HashSet<SourceSpools>();
            this.SourceSpools2 = new HashSet<SourceSpools>();
        }
    
        public System.Guid ProductID { get; set; }
        public System.Guid C1CNomenclatureID { get; set; }
        public Nullable<System.Guid> C1CCharacteristicID { get; set; }
        public Nullable<int> RealFormat { get; set; }
        public int Diameter { get; set; }
        public int Weight { get; set; }
        public Nullable<int> Length { get; set; }
        public Nullable<decimal> RealBasisWeight { get; set; }
        public Nullable<byte> BreakNumber { get; set; }
    
        public virtual C1CCharacteristics C1CCharacteristics { get; set; }
        public virtual C1CNomenclature C1CNomenclature { get; set; }
        public virtual Products Products { get; set; }
        public virtual ICollection<SourceSpools> SourceSpools { get; set; }
        public virtual ICollection<SourceSpools> SourceSpools1 { get; set; }
        public virtual ICollection<SourceSpools> SourceSpools2 { get; set; }
    }
}
