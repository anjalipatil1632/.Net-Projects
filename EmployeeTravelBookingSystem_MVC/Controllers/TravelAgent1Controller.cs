using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using EmployeeTravelBookingSystem_MVC.Models;

namespace EmployeeTravelBookingSystem_MVC.Controllers
{
    public class TravelAgent1Controller : Controller
    {
        IEnumerable<TravelRequestEmp> travelRequests = null;
        //IEnumerable<TravelClass> user = null;
        HttpClient hc = new HttpClient();
        // GET: Employee
        public ActionResult Index()
        {
            try
            {
                hc.BaseAddress = new Uri("https://localhost:44348/api/");

                var consumeapi = hc.GetAsync("WebApiTravelAgent/getemp");
                consumeapi.Wait();

                var readdata = consumeapi.Result;
                if (readdata.IsSuccessStatusCode)
                {
                    var displaydata = readdata.Content.ReadAsAsync<IList<TravelRequestEmp>>();
                    displaydata.Wait();
                    travelRequests = displaydata.Result;
                }
                return View(travelRequests);
            }
            catch (HttpException ex)
            {

                return Content("Service is closed" + ex.HResult);
            }
            catch (Exception ex)
            {

                return Content("Error occurred" + ex);
            }

        }
        public ActionResult Details(int id)
        {
            try
            {
                TravelRequestEmp ec = null;
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("https://localhost:44348/api/");

                var consumeapi = hc.GetAsync("WebApiTravelAgent/getdetails?id=" + id.ToString());
                consumeapi.Wait();

                var readdata = consumeapi.Result;
                if (readdata.IsSuccessStatusCode)
                {
                    var display = readdata.Content.ReadAsAsync<TravelRequestEmp>();
                    display.Wait();
                    ec = display.Result;
                }
                return View(ec);
            }
            catch (HttpException ex)
            {

                return Content("Service is closed" + ex.HResult);
            }
            catch (Exception ex)
            {

                return Content("Error occurred" + ex);
            }

        }



        [HttpGet]
        public ActionResult ChangeStatus(int id)
        {
            try
            {
                //TravelRequest travelRequests = null;
                TravelRequestEmp ec = null;
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("https://localhost:44348/api/");

                var consumeapi = hc.GetAsync("WebApiTravelAgent/getdetails?id=" + id.ToString());
                consumeapi.Wait();

                var readdata = consumeapi.Result;
                if (readdata.IsSuccessStatusCode)
                {
                    var display1 = readdata.Content.ReadAsAsync<TravelRequestEmp>();
                    display1.Wait();
                    ec = display1.Result;
                }
                return View(ec);
            }
            catch (HttpException ex)
            {

                return Content("Service is closed" + ex.HResult);
            }
            catch (Exception ex)
            {

                return Content("Error occurred" + ex);
            }

        }

        [HttpPost]
        public ActionResult ChangeStatus(TravelRequestEmp ec)
        {
            try
            {
                //TravelClass tc;
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("https://localhost:44348/api/");

                var updaterec = hc.PutAsJsonAsync<TravelRequestEmp>("WebApiTravelAgent/Put?LoginId=" + Session["TravelAgentId"].ToString(), ec);
                updaterec.Wait();

                var savedata = updaterec.Result;
                if (savedata.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
                return View(ec);
            }
            catch (HttpException ex)
            {

                return Content("Service is closed" + ex.HResult);
            }
            catch (Exception ex)
            {

                return Content("Error occurred" + ex);
            }

        }


        public ActionResult CheckTicket()
        {
            IEnumerable<TravelClass> user = null;
            hc.BaseAddress = new Uri("https://localhost:44348/api/");

            var consumeapi = hc.GetAsync("WebApiTravelAgent/getTicketCount?LoginId=" + Session["TravelAgentId"].ToString());
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<TravelClass>>();
                displaydata.Wait();
                user = displaydata.Result;
            }
            return View(user);
        }




        public ActionResult ConfirmedRequest()
        {
            try
            {
                hc.BaseAddress = new Uri("https://localhost:44348/api/");

                var consumeapi = hc.GetAsync("WebApiTravelAgent/GetConfirmedRequest/");
                consumeapi.Wait();

                var readdata = consumeapi.Result;
                if (readdata.IsSuccessStatusCode)
                {
                    var display = readdata.Content.ReadAsAsync<IList<TravelRequestEmp>>();
                    display.Wait();
                    travelRequests = display.Result;
                }
                ModelState.AddModelError(string.Empty, "Error occurred");
                return View(travelRequests);
            }
            catch (HttpException ex)
            {

                return Content("Service is closed" + ex.HResult);
            }
            catch (Exception ex)
            {

                return Content("Error occurred" + ex);
            }

        }
    }
}