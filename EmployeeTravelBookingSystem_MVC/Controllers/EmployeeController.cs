using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using EmployeeTravelBookingSystem_MVC.Models;

namespace EmployeeTravelBookingSystem_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index(string LoginID)
        {
            return View();
        }
        
        public ActionResult Index1()
        {
            var a = TempData["EmployeeId"].ToString();
            Session["UserName"] = a;
            IEnumerable<TravelRequestEmp> empobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44348/api/");
             var consumeapi = hc.GetAsync("webapi/gettravelrequest?loginid=" + TempData["EmployeeId"].ToString());
          //  var consumeapi = hc.GetAsync("webapi?loginid=" + "snehalb".ToString());
            consumeapi.Wait();
            var readdatta = consumeapi.Result;
            if (readdatta.IsSuccessStatusCode)
            {
                var displaydata = readdatta.Content.ReadAsAsync<IList<TravelRequestEmp>>();
                displaydata.Wait();
                empobj = displaydata.Result;
            }
            ModelState.AddModelError(string.Empty, "Error Occured While raising new ticket! Try Again in Some Time");
            return View(empobj);

        }
        public ActionResult Displaystatus()
        {
            IEnumerable<TravelRequestEmp> empobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44348/api/");
            var consumeapi = hc.GetAsync("webapi/gettravelrequest?loginid=" + Session["UserName"].ToString());
            consumeapi.Wait();
            var readdatta = consumeapi.Result;
            if (readdatta.IsSuccessStatusCode)
            {
                var displaydata = readdatta.Content.ReadAsAsync<IList<TravelRequestEmp>>();
                displaydata.Wait();
                empobj = displaydata.Result;
            }
            ModelState.AddModelError(string.Empty, "Error Occured While raising new ticket! Try Again in Some Time");
            return View(empobj);
        }
        [HttpGet]
        public ActionResult RaiseTicket()
        {
            TravelRequestEmp travel = new TravelRequestEmp();
            return View(travel);
        }
        [HttpPost]
        public ActionResult RaiseTicket(TravelRequestEmp travelRequest)
        {
            var List = new List<string>() { "Flight", "Train" };
            ViewBag.list = List;
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44348/api/");
            var insertrecord = httpClient.PostAsJsonAsync<TravelRequestEmp>("webapi/raiseticket", travelRequest);
            insertrecord.Wait();
            var readdatta = insertrecord.Result;
            if (readdatta.IsSuccessStatusCode)
            {
                return RedirectToAction("Displaystatus");
            }
            ModelState.AddModelError(string.Empty, "Error Occured While raising new ticket! Try Again in Some Time");
            return View("RaiseTicket");
        }
        public ActionResult ViewForDelete()
        {          
            IEnumerable<TravelRequestEmp> empobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44348/api/");
            var consumeapi = hc.GetAsync("webapi/viewCancel?loginid=" + Session["UserName"].ToString());
            consumeapi.Wait();
            var readdatta = consumeapi.Result;
            if (readdatta.IsSuccessStatusCode)
            {
                var displaydata = readdatta.Content.ReadAsAsync<IList<TravelRequestEmp>>();
                displaydata.Wait();
                empobj = displaydata.Result;
            }
            ModelState.AddModelError(string.Empty, "Error Occured While raising new ticket! Try Again in Some Time");
            return View(empobj);
        }
        public ActionResult Delete(int id)
        {

                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("https://localhost:44348/api/");
                var cancelapi = hc.DeleteAsync("webapi/cancelticket?id=" + id.ToString());
                cancelapi.Wait();
                var readdatta = cancelapi.Result;
                if (readdatta.IsSuccessStatusCode)
                {
                    return RedirectToAction("ViewForDelete1");
                }
                ModelState.AddModelError(string.Empty, "Error occured While canceling ticket! Try Again in Some Time ");
                return View("ViewForDelete1");
           
           
        }
        public ActionResult ViewForDelete1()
        {
            return View();
        }



    }
}