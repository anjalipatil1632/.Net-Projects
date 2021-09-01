using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTravelBookingBAL
{
    public class TravelRequests
    {
        public int RequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Medium { get; set; }
        

        public int UserId { get; set; }
        public string CurrentStatus { get; set; }
        public string ManagerStatus { get; set; }   
    }

}
