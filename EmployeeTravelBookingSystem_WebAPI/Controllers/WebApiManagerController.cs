using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeTravelBookingSystem_WebApi.Models;

namespace EmployeeTravelBookingSystem_WebApi.Controllers
{
    public class WebApiManagerController : ApiController
    {
        EmployeeTravelBookingSystemEntities db = new EmployeeTravelBookingSystemEntities();
        // GET api/<controller>
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
            //var updateRequest = db.spUpdateApproveRequest(travel.RequestId,travel.ManagerStatus);
            //return Ok(updateRequest);

            var update = db.TravelRequests.Where(x => x.RequestId == travel.RequestId).FirstOrDefault<TravelRequest>();
            if (update != null)
            {
                //update.RequestId = travel.RequestId;
                //update.RequestDate = travel.RequestDate;
                //update.FromLocation = travel.FromLocation;
                //update.ToLocation = travel.ToLocation;
                //update.FromDate = travel.FromDate;
                //update.ToDate = travel.ToDate;
                //update.UserId = travel.UserId;
                //update.CurrentStatus = travel.CurrentStatus;
                update.ManagerStatus = travel.ManagerStatus;
                //update.ManagerId = travel.ManagerId;
                db.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok(travel);
        }

        // PUT api/<controller>/5
        //[HttpPut]
        //public IHttpActionResult UpdateToReject(int requestId)
        //{
        //    var result=db.spUpdateRejectRequest(requestId);
        //    db.SaveChanges();
        //    return Ok(result);
        //}


        //// GET api/<controller>/5
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

        // GET api/<controller>/5
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


        // GET api/<controller>/5
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


        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}

