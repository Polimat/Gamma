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
    
    public partial class DocBrokeProductRejectionReasons
    {
        public System.Guid DocID { get; set; }
        public System.Guid ProductID { get; set; }
        public System.Guid C1CRejectionReasonID { get; set; }
        public string Comment { get; set; }
    
        public virtual C1CRejectionReasons C1CRejectionReasons { get; set; }
        public virtual DocBrokeProducts DocBrokeProducts { get; set; }
        public virtual Products Products { get; set; }
    }
}
