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
    
    public partial class Docs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Docs()
        {
            this.DocChangeStateProducts = new HashSet<DocChangeStateProducts>();
            this.DocCloseShiftRemainders = new HashSet<DocCloseShiftRemainders>();
            this.DocProducts = new HashSet<DocProducts>();
            this.DocCloseShiftDocs = new HashSet<Docs>();
            this.DocCloseShift = new HashSet<Docs>();
            this.DocCloseShiftWithdrawals = new HashSet<DocWithdrawal>();
            this.DocCloseShiftSamples = new HashSet<DocCloseShiftSamples>();
            this.DocShipments = new HashSet<DocShipments>();
        }
    
        public System.Guid DocID { get; set; }
        public Nullable<int> DocTypeID { get; set; }
        public string Number { get; set; }
        public bool IsConfirmed { get; set; }
        public Nullable<System.Guid> UserID { get; set; }
        public string PrintName { get; set; }
        public Nullable<int> PlaceID { get; set; }
        public Nullable<byte> ShiftID { get; set; }
        public System.DateTime Date { get; set; }
        public string Comment { get; set; }
        public Nullable<bool> IsFromOldGamma { get; set; }
        public Nullable<bool> IsMarked { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocChangeStateProducts> DocChangeStateProducts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocCloseShiftRemainders> DocCloseShiftRemainders { get; set; }
        public virtual DocMovement DocMovement { get; set; }
        public virtual DocProduction DocProduction { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocProducts> DocProducts { get; set; }
        public virtual DocTypes DocTypes { get; set; }
        public virtual Users Users { get; set; }
        public virtual DocWithdrawal DocWithdrawal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Docs> DocCloseShiftDocs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Docs> DocCloseShift { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocWithdrawal> DocCloseShiftWithdrawals { get; set; }
        public virtual Places Places { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocCloseShiftSamples> DocCloseShiftSamples { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocShipments> DocShipments { get; set; }
    }
}
