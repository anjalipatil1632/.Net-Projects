using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeTravelBookingSystem_MVC.Controllers;
using EmployeeTravelBooking_UnitTestProject.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using EmployeeTravelBookingSystem_MVC.Models;

namespace EmployeeTravelBooking_UnitTestProject.Controllers
{
    [TestClass]
    public class LoginUnitTest
    {
        [TestMethod]
        public void Login()
        {
            Sprint2dbEntities1 db = new Sprint2dbEntities1();
            //var model = new User() { LoginId = "employee", Password = "employee111" };
            Login1Controller controller = new Login1Controller();
            User user = new User();
            user.LoginId = "employee";
            user.Password = "employee111";

           
            var result = controller.Login() as ViewResult;

            Assert.AreEqual("", result.ViewName);
            //Assert.AreEqual("employee111", result.ViewName);
        }
    }
}
