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
    
    public partial class PlaceRemotePrinters
    {
        public int PlaceRemotePrinterID { get; set; }
        public int PlaceID { get; set; }
        public int ModbusDeviceID { get; set; }
        public int RemotePrinterID { get; set; }
        public Nullable<bool> IsEnabled { get; set; }
        public Nullable<bool> IsDefaultPrinterForGamma { get; set; }
    
        public virtual ModbusDevices ModbusDevices { get; set; }
        public virtual Places Places { get; set; }
        public virtual RemotePrinters RemotePrinters { get; set; }
    }
}
