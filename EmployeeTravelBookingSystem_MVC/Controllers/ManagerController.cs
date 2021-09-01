using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using EmployeeTravelBookingSystem_MVC.Models;
using ManagerMVC.Models;

namespace EmployeeTravelBookingSystem_MVC.Controllers
{
    public class ManagerController : Controller
    {
        IEnumerable<TravelRequestEmp> req = null;
        IEnumerable<ManagerModel> manager = null;
        HttpClient hc = new HttpClient();
        // GET: Manager


        public ActionResult Index()
        {
            //var a = TempData["ManagerId"].ToString();
            //Session["UserName"] = a;

            hc.BaseAddress = new Uri("https://localhost:44348/api/");
            var consumeapi = hc.GetAsync("WebApiManager/GetNewRequest?LoginId=" + Session["ManagerId"].ToString());
            //var consumeapi = hc.GetAsync("WebApiManager/GetNewRequest?LoginId=" + "manager".ToString());
            consumeapi.Wait();
            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<ManagerModel>>();
                displaydata.Wait();
                manager = displaydata.Result;
            }
            ModelState.AddModelError(string.Empty, "Error occurred");
            return View(manager);
        }


        public ActionResult NewRequest()
        {
            

            hc.BaseAddress = new Uri("https://localhost:44348/api/");
            var consumeapi = hc.GetAsync("WebApiManager/GetNewRequest?LoginId=" + Session["ManagerId"].ToString());
            //var consumeapi = hc.GetAsync("WebApiManager/GetNewRequest?LoginId=" + "manager".ToString());
            consumeapi.Wait();
            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<ManagerModel>>();
                displaydata.Wait();
                manager = displaydata.Result;
            }
            ModelState.AddModelError(string.Empty, "Error occurred");
            return View(manager);
        }

        // GET: Manager/Details/5
        public ActionResult ApprovedRequest()
        {
            hc.BaseAddress = new Uri("https://localhost:44348/api/");
            var consumeapi = hc.GetAsync("WebApiManager/GetApprovedRequest/");
            consumeapi.Wait();
            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<TravelRequestEmp>>();
                displaydata.Wait();
                req = displaydata.Result;
            }
            ModelState.AddModelError(string.Empty, "Error occurred");
            return View(req);

        }

        // GET: Manager/Create
        public ActionResult RejectedRequest()
        {
            hc.BaseAddress = new Uri("https://localhost:44348/api/");
            var consumeapi = hc.GetAsync("WebApiManager/GetRejectedRequest");
            consumeapi.Wait();
            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<TravelRequestEmp>>();
                displaydata.Wait();
                req = displaydata.Result;
            }
            ModelState.AddModelError(string.Empty, "Error occurred");
            return View(req);

        }


        public ActionResult ChangeStatus(int id)
        {
            TravelRequestEmp model = null;
            hc.BaseAddress = new Uri("https://localhost:44348/api/");

            var consumeapi = hc.GetAsync("WebApiManager/GetRecordsById?id=" + id.ToString());
            consumeapi.Wait();
            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<TravelRequestEmp>();
                displaydata.Wait();
                model = displaydata.Result;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult ChangeStatus(TravelRequestEmp model)
        {
            hc.BaseAddress = new Uri("https://localhost:44348/api/");
            var update = hc.PutAsJsonAsync<TravelRequestEmp>("WebApiManager", model);
            update.Wait();
            var savedata = update.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("NewRequest");
            }
            else
            {
                ViewBag.Message = "Record not found";
            }
            return View(model);
        }


        public ActionResult History()
        {
            hc.BaseAddress = new Uri("https://localhost:44348/api/");
            var consumeapi = hc.GetAsync("WebApiManager/GetHistoryRecords/");
            consumeapi.Wait();
            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<TravelRequestEmp>>();
                displaydata.Wait();
                req = displaydata.Result;
            }
            ModelState.AddModelError(string.Empty, "Error occurred");
            return View(req);
        }













        // POST: Manager/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Manager/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Manager/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
