//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeTravelBookingSystem_WebApi.Models
{
    using System;
    
    public partial class spGetNewRequests_Result
    {
        public int RequestId { get; set; }
        public Nullable<System.DateTime> RequestDate { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public string Medium { get; set; }
        public int UserId { get; set; }
        public string CurrentStatus { get; set; }
        public string ManagerStatus { get; set; }
        public string ManagerId { get; set; }
    }
}
