using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeTravelBookingSystem_WebApi.Controllers
{
    public class WebApiManagerController : ApiController
    {
        EmpTravelBookingSystemEntities db = new EmpTravelBookingSystemEntities();
        //retrieve travel requests records
        [HttpGet]
        public IHttpActionResult GetNewRequest(string LoginId)
        {
            var result = db.spGetNewRequests(LoginId).ToList();
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



            //Get reord based on id
            //[HttpGet]
        public IHttpActionResult GetRecordsById(int id)
        {
            var result = db.spGetRecordsById(id).Select(x => new TravelRequest()
            {
                RequestId = x.RequestId,
                RequestDate = x.RequestDate,
                FromLocation = x.FromLocation,
                ToLocation = x.ToLocation,
                FromDate = x.FromDate,
                ToDate = x.ToDate,
                Medium = x.Medium,
                UserId = x.UserId,
                CurrentStatus = x.CurrentStatus,
                ManagerStatus = x.ManagerStatus,
                ManagerId = x.ManagerId
            }).FirstOrDefault<TravelRequest>();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        // PUT api/<controller>/5
        [HttpPut]
        public IHttpActionResult UpdateToApprove(TravelRequest travel)
        {
            var update = db.TravelRequests.Where(x => x.RequestId == travel.RequestId).FirstOrDefault<TravelRequest>();
            if (update != null)
            {
                update.ManagerStatus = travel.ManagerStatus;

                db.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok(travel);
        }


        //get approved requests
        [HttpGet]
        public IHttpActionResult GetApprovedRequest()
        {
            var result = db.spApprovedRequest().ToList();
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

        // get rejected requests
        [HttpGet]
        public IHttpActionResult GetRejectedRequest()
        {
            var result = db.spRejectedRequest().ToList();
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


        // get all records history
        [HttpGet]
        public IHttpActionResult GetHistoryRecords()
        {
            var result = db.spHistoryRecords().ToList();
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

    }
}


