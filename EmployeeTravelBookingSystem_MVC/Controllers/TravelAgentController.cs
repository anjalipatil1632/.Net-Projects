using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using EmployeeTravelBookingSystem_MVC.Models;

namespace EmployeeTravelBookingSystem_MVC.Controllers
{
    public class TravelAgentController : Controller
    {
        IEnumerable<TravelRequestEmp> travelRequests = null;
        //IEnumerable<TravelClass> user = null;
        HttpClient hc = new HttpClient();
        // GET: Employee
        public ActionResult Index()
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
        public ActionResult Details(int id)
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



        [HttpGet]
        public ActionResult ChangeStatus(int id)
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

        [HttpPost]
        public ActionResult ChangeStatus(TravelRequestEmp ec)
        {
            TravelClass tc;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44348/api/");

            var updaterec = hc.PutAsJsonAsync<TravelRequestEmp>("WebApiTravelAgent/Put?LoginId=" + Session["TravelAgentId"].ToString(), ec);
            updaterec.Wait();

            var savedata = updaterec.Result;
            if (savedata.IsSuccessStatusCode)
            {
                //var count = hc.GetAsync("WebApiTravelAgent/changeTicketCount?LoginId=" + Session["TravelAgentId"].ToString());
                //count.Wait();
                //var save = count.Result;
                //if (save.IsSuccessStatusCode)
                //{
                //    return RedirectToAction("Index");
                //}
                //Session["C"] = count;
                return RedirectToAction("Index");
            }
            return View(ec);
        }


        public ActionResult CheckTicket()
        {
            IEnumerable<TravelClass> user = null;
            hc.BaseAddress = new Uri("https://localhost:44348/api/");

            var consumeapi = hc.GetAsync("WebApiTravelAgent/getTicketCount?LoginId="+Session["TravelAgentId"].ToString());
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



        //[HttpPost]
        //public ActionResult Check_Ticket(UserClass uc)
        //{
        //    return RedirectToAction("Index");
        //}

        public ActionResult ConfirmedRequest()
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


    }
}