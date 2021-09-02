using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerMVC.Models
{
    public class ManagerModel
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

      //  public virtual User User { get; set; }
    }
}