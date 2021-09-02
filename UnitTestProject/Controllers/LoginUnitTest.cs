using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeTravelBookingSystem_MVC.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using EmployeeTravelBookingSystem_MVC.Models;
using EmployeeTravelBookingSystem_MVC;

namespace UnitTestProject.Controllers
{
    /// <summary>
    /// Summary description for LoginUnitTest
    /// </summary>
    [TestClass]
    public class LoginUnitTest
    {
        [TestMethod]
        public void Login()
        {
            Sprint2dbEntities db = new Sprint2dbEntities();
            //var model = new User() { LoginId = "employee", Password = "employee111" };
            LoginController controller = new LoginController();
            User user = new User();
            user.LoginId = "employee";
            user.Password = "employee111";


            var result = controller.Login() as ViewResult;

            Assert.AreEqual("", result.ViewName);
            //Assert.AreEqual("employee111", result.ViewName);
        }
    }
}
