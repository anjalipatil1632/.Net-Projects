using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeTravelBookingSystem_MVC.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeTravelBookingSystem_MVC.Models;
using System.Web.Mvc;

namespace UnitTestProject.Controllers
{
    /// <summary>
    /// Summary description for AdminUnitTest
    /// </summary>
    [TestClass]
    public class AdminUnitTest
    {
        [TestMethod]
        public void TestAdminHomePage()
        {
            AdminController controller = new AdminController();
            ViewResult result = controller.AdminHomePage() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestCreate()
        {
            AdminController controller = new AdminController();
            ViewResult result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestCreateManager()
        {
            AdminController controller = new AdminController();
            ViewResult result = controller.CreateManager() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestCreateTravelAgent()
        {
            AdminController controller = new AdminController();
            ViewResult result = controller.CreateTravelAgent() as ViewResult;
            Assert.IsNotNull(result);
        }



    }


    [TestClass]
    public class Emp
    {
        public TravelClass getEmp()
        {
            TravelClass travel = new TravelClass()
            {

                LoginId = "employee",
                Password = "employee111",
                Name = "Employee"

            };
            return travel;
        }

        [TestMethod]
        public void TestCreateEmp()
        {
            AdminController controller = new AdminController();
            var result = controller.Create(getEmp()) as ViewResult;
            Assert.AreEqual("", result.ViewName);
        }
    }
}
