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
    
    public partial class Products
    {
        public Products()
        {
            this.DocProducts = new HashSet<DocProducts>();
        }
    
        public System.Guid ProductID { get; set; }
        public string Number { get; set; }
        public string BarCode { get; set; }
        public Nullable<byte> ProductKindID { get; set; }
    
        public virtual ICollection<DocProducts> DocProducts { get; set; }
        public virtual ProductGroupPacks ProductGroupPacks { get; set; }
        public virtual ProductPallets ProductPallets { get; set; }
        public virtual Rests Rests { get; set; }
        public virtual ProductSpools ProductSpools { get; set; }
    }
}
