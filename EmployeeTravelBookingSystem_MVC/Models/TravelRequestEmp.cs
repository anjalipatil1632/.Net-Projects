using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeTravelBookingSystem_MVC.Models
{
    public class TravelRequestEmp
    {
        
        public int RequestId { get; set; }

        public Nullable<System.DateTime> RequestDate { get; set; }

        [Required(ErrorMessage = "Enter From Location!")]
        public string FromLocation { get; set; }

        [Required(ErrorMessage = "Enter To Location!")]
        public string ToLocation { get; set; }

        [Required(ErrorMessage = "Select Your From Date!")]
        public Nullable<System.DateTime> FromDate { get; set; }

        [Required(ErrorMessage = "Select Your To Date!")]
        public Nullable<System.DateTime> ToDate { get; set; }

        [Required(ErrorMessage = "Enter Medium!")]
        public string Medium { get; set; }

        [Required(ErrorMessage = "Enter your UserId!")]
        public int UserId { get; set; }
        public string CurrentStatus { get; set; }
        public string ManagerStatus { get; set; }
        public string ManagerId { get; set; }
    }
}