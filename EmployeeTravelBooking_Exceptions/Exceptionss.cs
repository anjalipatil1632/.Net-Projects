using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTravelBooking_Exceptions
{
    public class Exceptionss : ApplicationException
    {
        public Exceptionss() : base()
        {

        }

        public Exceptionss(string message) : base(message)
        {

        }
        public Exceptionss(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
