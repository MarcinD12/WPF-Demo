//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Logistics_project
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vehicle
    {
        public string VehicleID { get; set; }
        public int VehicleCapacity { get; set; }
        public Vehicle(string vId, int cap)
        {
            VehicleID = vId;
            VehicleCapacity = cap;
        }
    }
    
}
