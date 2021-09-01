using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeTravelBookingSystem_WebApi.Models;

namespace EmployeeTravelBookingSystem_WebApi.Controllers
{
    public class TravelController : ApiController
    {
        EmployeeTravelBookingSystemEntities dbEntities = new EmployeeTravelBookingSystemEntities();
        [HttpGet]
        public IHttpActionResult getemp()
        {
            var results = dbEntities.ViewEmpDetails().ToList();
            return Ok(results);
        }

        public IHttpActionResult addemp(User user)
        {
            var insertresults = dbEntities.AddEmployee1(user.LoginId, user.Password, user.Name);
            return Ok(insertresults);
        }



        public IHttpActionResult getempid(int id)
        {
            var empdetails = dbEntities.GetEmpDetails(id).Select(x => new User()
            {
                UserId = x.UserId,
                LoginId = x.LoginId,
                Password = x.Password,
                Name = x.Name

            }).FirstOrDefault<User>();

            return Ok(empdetails);
        }

        //[HttpPut]
        public IHttpActionResult Put(User tc)
        {
            var updateemp = dbEntities.UpdateEmp(tc.UserId, tc.LoginId, tc.Password, tc.Name);
            return Ok(updateemp);
        }
        //[HttpDelete]
        public IHttpActionResult delete(int id)
        {
            var deleteemp = dbEntities.DeleteEmp(id);
            return Ok(deleteemp);
        }

        //Manager
        [HttpGet]
        public IHttpActionResult viewmanager()
        {
            var results = dbEntities.ViewManagerDetails().ToList();
            return Ok(results);
        }

        public IHttpActionResult getmanager(int id)
        {
            var empdetails = dbEntities.GetManager(id).Select(x => new User()
            {
                UserId = x.UserId,
                LoginId = x.LoginId,
                Password = x.Password,
                Name = x.Name
            }).FirstOrDefault<User>();
            return Ok(empdetails);
        }

        public IHttpActionResult addmanager(User user)
        {
            var insertresults = dbEntities.addmanager(user.LoginId, user.Password, user.Name);
            return Ok(insertresults);
        }

        public IHttpActionResult Put1(User tc)
        {
            var updateemp = dbEntities.UpdateManager(tc.UserId, tc.LoginId, tc.Password, tc.Name);
            return Ok(updateemp);
        }

        public IHttpActionResult deletemanager(int id)
        {
            var deletemng = dbEntities.DeleteManager(id);
            return Ok(deletemng);
        }

        public IHttpActionResult getusers()
        {
            var results = dbEntities.ViewEmpDetails().ToList();
            return Ok(results);
        }

        public IHttpActionResult getuser(int id)
        {
            var getuser = dbEntities.GetUser(id).Select(x => new User()
            {
                UserId = x.UserId,
                ManagerUserId = Convert.ToInt32(x.ManagerUserId)
            }).FirstOrDefault<User>();
            return Ok(getuser);
        }

        //public IHttpActionResult getuser1(int id)
        //{
        //    var getuser = dbEntities.GetUser1(id).Select(x => new User()
        //    {
        //        UserId = x.UserId,
        //        LoginId=x.LoginId,
        //        Password=x.Password,
        //        UserTypeId=Convert.ToInt32(x.UserTypeId),
        //        Name=x.Name,
        //        ManagerUserId = Convert.ToInt32(x.ManagerUserId)
        //    }).FirstOrDefault<User>();
        //    return Ok(getuser);
        //}

        public IHttpActionResult Put2(User user)
        {
            var assignmng = dbEntities.AssignManager(user.UserId, user.ManagerUserId);
            return Ok(assignmng);
        }

        public IHttpActionResult Put3(User user)
        {
            var changemng = dbEntities.ChangeManager(user.UserId, user.ManagerUserId);
            return Ok(changemng);
        }

        //TravelAgent
        [HttpGet]
        public IHttpActionResult viewtravelagentdetails()
        {
            var results = dbEntities.ViewTravelAgentDetails().ToList();
            return Ok(results);
        }

        public IHttpActionResult addtravelagent(User user)
        {
            var insertresults = dbEntities.addtravelagent(user.LoginId, user.Password, user.Name);
            return Ok(insertresults);
        }

        public IHttpActionResult gettravelagent(int id)
        {
            var travelagentdetails = dbEntities.GetTravelAgent(id).Select(x => new User()
            {
                UserId = x.UserId,
                LoginId = x.LoginId,
                Password = x.Password,
                Name = x.Name
            }).FirstOrDefault<User>();
            return Ok(travelagentdetails);
        }

        public IHttpActionResult Put4(User tc)
        {
            var updatetravelagent = dbEntities.UpdateTravelAgent(tc.UserId, tc.LoginId, tc.Password, tc.Name);
            return Ok(updatetravelagent);
        }

        public IHttpActionResult deletetravelagent(int id)
        {
            var deletetravelagent = dbEntities.DeleteTravelAgent(id);
            return Ok(deletetravelagent);
        }

    }
}