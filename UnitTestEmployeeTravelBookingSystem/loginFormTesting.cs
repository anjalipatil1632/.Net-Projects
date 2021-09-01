using System;
using EmployeeTravelBooking_BAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestEmployeeTravelBookingSystem
{
    [TestClass]
    public class loginFormTesting
    {
        [TestMethod]
        public void TestMethod1()
        {
            //For Correct Values
            //Arrange
            int expected = 1;
            string loginid = "anjalip";
            string password = "anjali111";

            //Act
            EmpTravelBookingBAL obj = new EmpTravelBookingBAL();
            int returtnvalue = obj.loginformcheck(loginid, password);

            //Assert
            Assert.AreEqual(expected, returtnvalue);
            
        }
       
    }
}
