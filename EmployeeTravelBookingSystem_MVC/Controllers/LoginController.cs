using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace EmployeeTravelBookingSystem_MVC.Controllers
{
    public class LoginController : Controller
    {

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        
           
        public string encrypt(string val)
        {
            

            using (SHA256 sha2 = SHA256.Create())
            {
                var hash = sha2.ComputeHash(Encoding.UTF8.GetBytes(val));
                string hexString = string.Empty;

                for (int i = 0; i < hash.Length; i++)
                {
                    hexString += hash[i].ToString("X2"); //Convert the byte to Hexadecimal representation, Notice that we use "X2" instead of "X"
                }

                sha2.Dispose();
                return hexString;
            }
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            Session.Clear();

            using (Sprint2dbEntities entities = new Sprint2dbEntities())
            {
                var CurrentUser = (from m in entities.Users
                                   where m.LoginId == user.LoginId
                                   select m).ToList();
                bool CurrentUser_Exists = false;
                if (CurrentUser.Count > 0)
                {
                    CurrentUser_Exists = CurrentUser.ElementAt(0).Password.Equals(encrypt(user.Password));
                }
                if (CurrentUser_Exists)
                {
                    if (CurrentUser.ElementAt(0).UserTypeId.Equals(1))
                    {
                        Session["EmployeeId"] = CurrentUser.ElementAt(0).LoginId;
                        return RedirectToAction("Index1", "Employee");
                    }
                    if (CurrentUser.ElementAt(0).UserTypeId.Equals(2))
                    {
                        Session["ManagerId"] = CurrentUser.ElementAt(0).LoginId;
                        return RedirectToAction("Index", "Manager");
                    }
                    if (CurrentUser.ElementAt(0).UserTypeId.Equals(3))
                    {
                        Session["TravelAgentId"] = CurrentUser.ElementAt(0).LoginId;
                        return RedirectToAction("Index", "TravelAgent1");
                    }
                    if (CurrentUser.ElementAt(0).UserTypeId.Equals(4))
                    {
                        Session["AdminId"] = CurrentUser.ElementAt(0).LoginId;
                        return RedirectToAction("AdminHomePage", "Admin");
                    }
                }
                else
                {
                    ViewBag.Message = "Invalid Username or Password";
                    return View();
                }
            }
            return RedirectToAction("Login");
        }
    }
}