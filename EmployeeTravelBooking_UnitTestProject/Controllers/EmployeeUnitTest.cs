using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeTravelBookingSystem_MVC.Controllers;
using EmployeeTravelBooking_UnitTestProject.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace EmployeeTravelBooking_UnitTestProject.Controllers
{
    [TestClass]
    public class EmployeeUnitTest
    {
        [TestMethod]
        public void Contact()
        {
            HomeController home = new HomeController();
            ViewResult result = home.Contact() as ViewResult;
            Assert.IsNotNull(result);   // for test case pass
            //Assert.IsNull(result);   // for test case fail
        }
    }
}
