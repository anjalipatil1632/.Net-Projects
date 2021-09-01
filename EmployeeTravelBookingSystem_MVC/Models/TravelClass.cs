using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeTravelBookingSystem_MVC.Models
{
    public class TravelClass
    {
        public int UserId { get; set; }


        [Required(ErrorMessage = "This field is required")]
        public string LoginId { get; set; }


        [Required(ErrorMessage = "This field is required")]
        public string Password { get; set; }

        public string Salt { get; set; }
        public Nullable<int> UserTypeId { get; set; }


        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }

        public Nullable<int> ManagerUserId { get; set; }
        public Nullable<int> Ticket_Count { get; set; }

        //public virtual UserType UserType { get; set; }
    }
}