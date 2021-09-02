using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeTravelBookingSystem_WebApi.Controllers
{
    public class WebApiTravelAgentController : ApiController
    {
        EmpTravelBookingSystemEntities db = new EmpTravelBookingSystemEntities();

        //get travel requests of employee
        public IHttpActionResult getemp()
        {
            var results = db.usp_TravelRequests_Travelagent().ToList();
            if (results == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("Travel requests not found ")),
                    ReasonPhrase = "Travel requests not found"
                };

                throw new HttpResponseException(response);
            }
            return Ok(results);
        }


        //get records using id
        [HttpGet]
        public IHttpActionResult getdetails(int id)
        {
            var empdetails = db.GetDetails(id).Select(x => new TravelRequest()
            {
                RequestId = (x.RequestId),
                RequestDate = (DateTime)x.RequestDate,
                FromLocation = x.FromLocation,
                ToLocation = x.ToLocation,
                FromDate = (DateTime)x.FromDate,
                ToDate = (DateTime)x.ToDate,
                Medium = x.Medium,
                UserId = (x.UserId),
                CurrentStatus = x.CurrentStatus,
                ManagerStatus = x.ManagerStatus,
            }).FirstOrDefault<TravelRequest>();
            if (empdetails == null)
            {
                return NotFound();
            }
            return Ok(empdetails);

        }

        //get confirmed requests
        public IHttpActionResult GetConfirmedRequest()
        {
            var result = db.ConfirmedTicket().ToList();
            if (result == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("Travel requests not found ")),
                    ReasonPhrase = "Travel requests not found"
                };

                throw new HttpResponseException(response);
            }
            return Ok(result);
        }

        //update status of employee requests
        public IHttpActionResult Put(TravelRequest ec, string LoginId)
        {

            var update = db.ChangeTravelStatus1(ec.RequestId, ec.CurrentStatus, LoginId);
            if (update == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("Travel requests not found ")),
                    ReasonPhrase = "Travel requests not found"
                };

                throw new HttpResponseException(response);
            }
            return Ok(update);
        }

        //get user details
        public IHttpActionResult getTicketCount(string LoginId)
        {
            var result = db.getCount(LoginId).ToList();
            if (result == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("Travel requests not found ")),
                    ReasonPhrase = "Travel requests not found"
                };

                throw new HttpResponseException(response);
            }
            return Ok(result);
        }

        //redure count
        //public IHttpActionResult changeTicketCount(string LoginId)
        //{
        //    var result = db.(LoginId);
        //    if (result == null)
        //    {
        //        var response = new HttpResponseMessage(HttpStatusCode.NotFound)
        //        {
        //            Content = new StringContent(string.Format("Travel requests not found ")),
        //            ReasonPhrase = "Travel requests not found"
        //        };

        //        throw new HttpResponseException(response);
        //    }
        //    return Ok(result);
        //}
    }
}

