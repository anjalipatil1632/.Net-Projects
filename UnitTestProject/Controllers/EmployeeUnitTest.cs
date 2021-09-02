using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeTravelBookingSystem_MVC.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace UnitTestProject.Controllers
{
    /// <summary>
    /// Summary description for EmployeeUnitTest
    /// </summary>
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
