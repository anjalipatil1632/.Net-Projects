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
            try
            {
                hc.BaseAddress = new Uri("https://localhost:44348/api/");
                var consumeapi = hc.GetAsync("WebApiManager/GetNewRequest?LoginId=" + Session["ManagerId"].ToString());

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
            catch (HttpException ex)
            {

                return Content("Service is closed" + ex.HResult);
            }
            catch (Exception ex)
            {

                return Content("Error occurred" + ex);
            }

        }


        public ActionResult NewRequest()
        {
            try
            {

                hc.BaseAddress = new Uri("https://localhost:44348/api/");
                var consumeapi = hc.GetAsync("WebApiManager/GetNewRequest?LoginId=" + Session["ManagerId"].ToString());

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
            catch (HttpException ex)
            {

                return Content("Service is closed" + ex.HResult);
            }
            catch (Exception ex)
            {

                return Content("Error occurred" + ex);
            }

        }

        // GET: Manager/Details/5
        public ActionResult ApprovedRequest()
        {
            try
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
            catch (HttpException ex)
            {

                return Content("Service is closed" + ex.HResult);
            }
            catch (Exception ex)
            {

                return Content("Error occurred" + ex);
            }


        }

        // GET: Manager/Create
        public ActionResult RejectedRequest()
        {
            try
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
            catch (HttpException ex)
            {

                return Content("Service is closed" + ex.HResult);
            }
            catch (Exception ex)
            {

                return Content("Error occurred" + ex);
            }

        }


        public ActionResult ChangeStatus(int id)
        {
            try
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
        public ActionResult ChangeStatus(TravelRequestEmp model)
        {
            try
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
            catch (HttpException ex)
            {

                return Content("Service is closed" + ex.HResult);
            }
            catch (Exception ex)
            {

                return Content("Error occurred" + ex);
            }

        }


        public ActionResult History()
        {
            try
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
