using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using EmployeeTravelBookingSystem_MVC.Models;

namespace EmployeeTravelBookingSystem_MVC.Controllers
{
    public class Login1Controller : Controller
    {
        public string encrypt(string val)
        {
            //var bytes = Encoding.UTF8.GetBytes(val);
            //string encryptdata = Convert.ToBase64String(SHA256.Create().ComputeHash(bytes));
            //return encryptdata;

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


        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            User user = new User();
            return View(user);
        }

        

        [HttpPost]
        public ActionResult Login(User user)
        {
            Session.Clear();
            try
            {
                using (Sprint2dbEntities1 entities = new Sprint2dbEntities1())
                {
                    var CurrentUser = (from m in entities.Users
                                       where m.LoginId == user.LoginId
                                       select m).ToList();
                    bool CurrentUser_Exists = false;
                    if (CurrentUser.Count > 0)
                    {
                        CurrentUser_Exists = CurrentUser.ElementAt(0).Password.Equals(encrypt(user.Password));
                        //CurrentUser_Exists = CurrentUser.ElementAt(0).Password.Equals(user.Password);


                        if (CurrentUser_Exists)
                        {
                            if (CurrentUser.ElementAt(0).UserTypeId.Equals(1))
                            {
                                TempData["EmployeeId"] = CurrentUser.ElementAt(0).LoginId;
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
                                return RedirectToAction("Index", "TravelAgent");
                            }
                            if (CurrentUser.ElementAt(0).UserTypeId.Equals(4))
                            {
                                Session["AdminId"] = CurrentUser.ElementAt(0).LoginId;
                                return RedirectToAction("AdminHomePage", "TravelMVC");
                            }
                        }
                        else
                        {
                            //ViewBag.Message = "Invalid Username or Password";
                            //TempData["Message"] = "Invalid Username or Password";
                           // return Content("<script language='javascript' type='text/javascript'>alert('Save Successfully');</script>");
                        }

                    }
                    else
                    {
                        // return Content("<script language='javascript' type='text/javascript'>alert('Invalid id and password');</script>");
                        TempData["Message"] = "Invalid Username or Password";
                        //return Content("Inavlid id");
                    }

                }
            }
            catch(ArgumentNullException ex)
            {
                //Response.Write("Error Occured"+ex);
                //ViewBag.Message = "Invalid";
                //return View();
            }
            return RedirectToAction("Login");
        }
    }
}