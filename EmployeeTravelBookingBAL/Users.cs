using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTravelBookingBAL
{
    public class Users
    {

        public int UserId { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public int UserTypeId { get; set; }
        public string Name { get; set; }
        public int ManagerUserId { get; set; }
    }
}
