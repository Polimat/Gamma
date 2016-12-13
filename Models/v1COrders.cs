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
    
    public partial class v1COrders
    {
        public System.Guid C1COrderID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Number { get; set; }
        public string Shipper { get; set; }
        public string Consignee { get; set; }
        public Nullable<System.Guid> C1COutSubdivisionID { get; set; }
        public int OutBranchID { get; set; }
        public Nullable<System.Guid> C1CInSubdivisionID { get; set; }
        public Nullable<int> InBranchID { get; set; }
        public Nullable<System.DateTime> OutDate { get; set; }
        public Nullable<System.DateTime> InDate { get; set; }
        public string Driver { get; set; }
        public string DriverDocument { get; set; }
        public string VehicleNumber { get; set; }
        public bool IsShipped { get; set; }
        public Nullable<bool> IsConfirmed { get; set; }
        public Nullable<System.Guid> InActivePersonID { get; set; }
        public string InActivePerson { get; set; }
        public Nullable<byte> InShiftId { get; set; }
        public Nullable<int> InPlaceID { get; set; }
        public Nullable<System.Guid> OutActivePersonID { get; set; }
        public string OutActivePerson { get; set; }
        public Nullable<byte> OutShiftID { get; set; }
        public Nullable<int> OutPlaceID { get; set; }
        public int OrderKindID { get; set; }
        public string OrderType { get; set; }
    }
}
