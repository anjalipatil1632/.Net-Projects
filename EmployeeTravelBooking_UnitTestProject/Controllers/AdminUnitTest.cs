using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeTravelBookingSystem_MVC.Controllers;
using EmployeeTravelBooking_UnitTestProject.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeTravelBookingSystem_MVC.Models;
using System.Web.Mvc;

namespace EmployeeTravelBooking_UnitTestProject.Controllers
{
    
    [TestClass]
    public class AdminUnitTest
    {
        [TestMethod]
        public void TestAdminHomePage()
        {
            TravelMVCController controller = new TravelMVCController();
            ViewResult result = controller.AdminHomePage() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestCreate()
        {
            TravelMVCController controller = new TravelMVCController();
            ViewResult result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestCreateManager()
        {
            TravelMVCController controller = new TravelMVCController();
            ViewResult result = controller.CreateManager() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestCreateTravelAgent()
        {
            TravelMVCController controller = new TravelMVCController();
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
            TravelMVCController controller = new TravelMVCController();
            var result = controller.Create(getEmp()) as ViewResult;
            Assert.AreEqual("", result.ViewName);
        }
    }
}
