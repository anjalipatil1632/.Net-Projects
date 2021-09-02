using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using EmployeeTravelBookingSystem_MVC.Models;


namespace EmployeeTravelBookingSystem_MVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: TravelMVC

        //view emp details

        public ActionResult AdminHomePage()
        {
            return View();
        }
        public ActionResult Index()
        {
            IEnumerable<TravelClass> empobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44348/api/");

            var consumeapi = hc.GetAsync("Travel/getemp");
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<TravelClass>>();
                displaydata.Wait();
                empobj = displaydata.Result;
            }
            return View(empobj);
        }

        //create emp
        public ActionResult Create()
        {
            TravelClass travel = new TravelClass();
            return View(travel);
        }

        [HttpPost]
        public ActionResult Create(TravelClass tc)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44348/api/");

            var insertrec = hc.PostAsJsonAsync<TravelClass>("Travel/addemp", tc);
            insertrec.Wait();

            var savedata = insertrec.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        //view particular details
        //public ActionResult Details(int id)
        //{
        //    TravelClass travelClass = null;
        //    HttpClient hc = new HttpClient();
        //    hc.BaseAddress = new Uri("https://localhost:44395/api/");

        //    var consumeapi = hc.GetAsync("Travel/getempid?id=" + id.ToString());
        //    consumeapi.Wait();

        //    var readdata = consumeapi.Result;
        //    if (readdata.IsSuccessStatusCode)
        //    {
        //        var displayempdetails = readdata.Content.ReadAsAsync<TravelClass>();
        //        displayempdetails.Wait();
        //        travelClass = displayempdetails.Result;
        //    }
        //    return View(travelClass);
        //}

        public ActionResult Update(int id)
        {
            TravelClass travelClass = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44348/api/");

            var consumeapi = hc.GetAsync("Travel/getempid?id=" + id.ToString());
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displayempdetails = readdata.Content.ReadAsAsync<TravelClass>();
                displayempdetails.Wait();
                travelClass = displayempdetails.Result;
            }
            return View(travelClass);
        }

        [HttpPost]
        public ActionResult Update(TravelClass tc)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44348/api/");

            var updateemp = hc.PutAsJsonAsync<TravelClass>("Travel/Put", tc);
            updateemp.Wait();

            var savedata = updateemp.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(tc);
        }

        public ActionResult Delete(int id)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44348/api/");

            var deleteemp = hc.DeleteAsync("Travel/delete?id=" + id.ToString());
            deleteemp.Wait();

            var savedata = deleteemp.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        public ActionResult Manager()
        {
            IEnumerable<TravelClass> empobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44348/api/");

            var consumeapi = hc.GetAsync("Travel/viewmanager");
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<TravelClass>>();
                displaydata.Wait();
                empobj = displaydata.Result;
            }
            return View(empobj);
        }

        public ActionResult CreateManager()
        {
            TravelClass travel = new TravelClass();
            return View(travel);
        }

        [HttpPost]
        public ActionResult CreateManager(TravelClass tc)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44348/api/");

            var insertrec = hc.PostAsJsonAsync<TravelClass>("Travel/addmanager", tc);
            insertrec.Wait();

            var savedata = insertrec.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Manager");
            }
            return View();
        }

        public ActionResult UpdateManager(int id)
        {
            TravelClass travelClass = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44348/api/");

            var consumeapi = hc.GetAsync("Travel/getmanager?id=" + id.ToString());
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displayempdetails = readdata.Content.ReadAsAsync<TravelClass>();
                displayempdetails.Wait();
                travelClass = displayempdetails.Result;
            }
            return View(travelClass);
        }

        [HttpPost]
        public ActionResult UpdateManager(TravelClass tc)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44348/api/");

            var updateMng = hc.PutAsJsonAsync<TravelClass>("Travel/Put1", tc);
            updateMng.Wait();

            var savedata = updateMng.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Manager");
            }
            return View(tc);
        }

        public ActionResult DeleteManager(int id)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44348/api/");

            var deletemng = hc.DeleteAsync("Travel/deletemanager?id=" + id.ToString());
            deletemng.Wait();

            var savedata = deletemng.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Manager");
            }
            return View("Manager");
        }

        public ActionResult UserDetails()
        {
            IEnumerable<TravelClass> empobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44348/api/");

            var consumeapi = hc.GetAsync("Travel/getusers");
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<TravelClass>>();
                displaydata.Wait();
                empobj = displaydata.Result;
            }
            return View(empobj);
        }

        public ActionResult AssignManager(int id)
        {
            TravelClass travelClass = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44348/api/");

            var consumeapi = hc.GetAsync("Travel/getuser?id=" + id.ToString());
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displayuser = readdata.Content.ReadAsAsync<TravelClass>();
                displayuser.Wait();
                travelClass = displayuser.Result;
            }
            return View(travelClass);
        }

        [HttpPost]
        public ActionResult AssignManager(TravelClass tc)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44348/api/");

            var assignMng = hc.PutAsJsonAsync<TravelClass>("Travel/Put2", tc);
            assignMng.Wait();

            var savedata = assignMng.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("UserDetails");
            }
            return View(tc);
        }

        public ActionResult ChangeManager(int id)
        {
            TravelClass travelClass = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44348/api/");

            var consumeapi = hc.GetAsync("Travel/getuser?id=" + id.ToString());
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displayuser = readdata.Content.ReadAsAsync<TravelClass>();
                displayuser.Wait();
                travelClass = displayuser.Result;
            }
            return View(travelClass);
        }

        [HttpPost]
        public ActionResult ChangeManager(TravelClass tc)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44348/api/");

            var changeMng = hc.PutAsJsonAsync<TravelClass>("Travel/Put3", tc);
            changeMng.Wait();

            var savedata = changeMng.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("UserDetails");
            }
            return View(tc);
        }

        public ActionResult TravelAgent()
        {
            IEnumerable<TravelClass> empobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44348/api/");

            var consumeapi = hc.GetAsync("Travel/viewtravelagentdetails");
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<TravelClass>>();
                displaydata.Wait();
                empobj = displaydata.Result;
            }
            return View(empobj);
        }

        public ActionResult CreateTravelAgent()
        {
            TravelClass travel = new TravelClass();
            return View(travel);
        }

        [HttpPost]
        public ActionResult CreateTravelAgent(TravelClass tc)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44348/api/");

            var insertrec = hc.PostAsJsonAsync<TravelClass>("Travel/addtravelagent", tc);
            insertrec.Wait();

            var savedata = insertrec.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("TravelAgent");
            }
            return View();
        }

        public ActionResult UpdateTravelAgent(int id)
        {
            TravelClass travelClass = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44348/api/");

            var consumeapi = hc.GetAsync("Travel/gettravelagent?id=" + id.ToString());
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydetails = readdata.Content.ReadAsAsync<TravelClass>();
                displaydetails.Wait();
                travelClass = displaydetails.Result;
            }
            return View(travelClass);
        }

        [HttpPost]
        public ActionResult UpdateTravelAgent(TravelClass tc)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44348/api/");

            var updateTravelagn = hc.PutAsJsonAsync<TravelClass>("Travel/Put4", tc);
            updateTravelagn.Wait();

            var savedata = updateTravelagn.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("TravelAgent");
            }
            return View(tc);
        }



        public ActionResult DeleteTravelAgent(int id)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44348/api/");

            var deletemng = hc.DeleteAsync("Travel/deletetravelagent?id=" + id.ToString());
            deletemng.Wait();

            var savedata = deletemng.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("TravelAgent");
            }
            return View("TravelAgent");
        }
    }
}