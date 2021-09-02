using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeTravelBookingSystem_WebApi.Controllers
{
    public class WebApiController : ApiController
    {
        EmpTravelBookingSystemEntities empentity = new EmpTravelBookingSystemEntities();
        
        public IHttpActionResult gettravelrequest(string LoginID)
        {
            var results = empentity.spGetTravelRequestDetails1(LoginID).ToList();
            if (results == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("Travel requests not found ")),
                    ReasonPhrase = "Travel request not found"
                };

                throw new HttpResponseException(response);
            }
            return Ok(results);
        }
       

        public IHttpActionResult raiseticket(TravelRequest travelRequest)
        {
            var result = empentity.AddTravelRequest3(travelRequest.FromLocation, travelRequest.ToLocation, travelRequest.FromDate, travelRequest.ToDate, travelRequest.Medium, travelRequest.UserId);
            if (result == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("Travel requests not found ")),
                    ReasonPhrase = "Travel request not found"
                };

                throw new HttpResponseException(response);
            }
            return Ok(result);
            //return Ok();
        }

        [HttpDelete]
        public IHttpActionResult cancelticket(int id)
        {
            TravelRequest travelRequest = empentity.TravelRequests.Find(id);
            if(travelRequest==null)
            {
                return NotFound();
            }
            var result = empentity.spCancelTicket(id);
            return Ok(travelRequest);
        }
        [HttpGet]
        public IHttpActionResult viewCancel(string LoginID)
        {
            var results = empentity.viewCancel(LoginID).ToList();
            if (results == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("Travel requests not found ")),
                    ReasonPhrase = "Travel request not found"
                };

                throw new HttpResponseException(response);
            }
            return Ok(results);
        }
    }
}
