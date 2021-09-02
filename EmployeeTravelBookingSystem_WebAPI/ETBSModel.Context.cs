﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeTravelBookingSystem_WebApi
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class EmpTravelBookingSystemEntities : DbContext
    {
        public EmpTravelBookingSystemEntities()
            : base("name=EmpTravelBookingSystemEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TravelRequest> TravelRequests { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }
    
        public virtual int AddTravelRequest(Nullable<System.DateTime> requestedate, string fromlocation, string tolocation, Nullable<System.DateTime> fromdate, Nullable<System.DateTime> todate, string medium, Nullable<int> userid, string currentstatus, string managerstatus)
        {
            var requestedateParameter = requestedate.HasValue ?
                new ObjectParameter("requestedate", requestedate) :
                new ObjectParameter("requestedate", typeof(System.DateTime));
    
            var fromlocationParameter = fromlocation != null ?
                new ObjectParameter("fromlocation", fromlocation) :
                new ObjectParameter("fromlocation", typeof(string));
    
            var tolocationParameter = tolocation != null ?
                new ObjectParameter("tolocation", tolocation) :
                new ObjectParameter("tolocation", typeof(string));
    
            var fromdateParameter = fromdate.HasValue ?
                new ObjectParameter("fromdate", fromdate) :
                new ObjectParameter("fromdate", typeof(System.DateTime));
    
            var todateParameter = todate.HasValue ?
                new ObjectParameter("todate", todate) :
                new ObjectParameter("todate", typeof(System.DateTime));
    
            var mediumParameter = medium != null ?
                new ObjectParameter("medium", medium) :
                new ObjectParameter("medium", typeof(string));
    
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            var currentstatusParameter = currentstatus != null ?
                new ObjectParameter("currentstatus", currentstatus) :
                new ObjectParameter("currentstatus", typeof(string));
    
            var managerstatusParameter = managerstatus != null ?
                new ObjectParameter("managerstatus", managerstatus) :
                new ObjectParameter("managerstatus", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddTravelRequest", requestedateParameter, fromlocationParameter, tolocationParameter, fromdateParameter, todateParameter, mediumParameter, useridParameter, currentstatusParameter, managerstatusParameter);
        }
    
        public virtual int spCancelTicket(Nullable<int> requestid)
        {
            var requestidParameter = requestid.HasValue ?
                new ObjectParameter("requestid", requestid) :
                new ObjectParameter("requestid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spCancelTicket", requestidParameter);
        }
    
        public virtual ObjectResult<spGetTravelRequestDetails_Result> spGetTravelRequestDetails(string loginid)
        {
            var loginidParameter = loginid != null ?
                new ObjectParameter("loginid", loginid) :
                new ObjectParameter("loginid", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetTravelRequestDetails_Result>("spGetTravelRequestDetails", loginidParameter);
        }
    
        public virtual int AddTravelRequest1(Nullable<System.DateTime> requestedate, string fromlocation, string tolocation, Nullable<System.DateTime> fromdate, Nullable<System.DateTime> todate, string medium, Nullable<int> userid)
        {
            var requestedateParameter = requestedate.HasValue ?
                new ObjectParameter("requestedate", requestedate) :
                new ObjectParameter("requestedate", typeof(System.DateTime));
    
            var fromlocationParameter = fromlocation != null ?
                new ObjectParameter("fromlocation", fromlocation) :
                new ObjectParameter("fromlocation", typeof(string));
    
            var tolocationParameter = tolocation != null ?
                new ObjectParameter("tolocation", tolocation) :
                new ObjectParameter("tolocation", typeof(string));
    
            var fromdateParameter = fromdate.HasValue ?
                new ObjectParameter("fromdate", fromdate) :
                new ObjectParameter("fromdate", typeof(System.DateTime));
    
            var todateParameter = todate.HasValue ?
                new ObjectParameter("todate", todate) :
                new ObjectParameter("todate", typeof(System.DateTime));
    
            var mediumParameter = medium != null ?
                new ObjectParameter("medium", medium) :
                new ObjectParameter("medium", typeof(string));
    
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddTravelRequest1", requestedateParameter, fromlocationParameter, tolocationParameter, fromdateParameter, todateParameter, mediumParameter, useridParameter);
        }
    
        public virtual int AddTravelRequest2(string fromlocation, string tolocation, Nullable<System.DateTime> fromdate, Nullable<System.DateTime> todate, string medium, Nullable<int> userid)
        {
            var fromlocationParameter = fromlocation != null ?
                new ObjectParameter("fromlocation", fromlocation) :
                new ObjectParameter("fromlocation", typeof(string));
    
            var tolocationParameter = tolocation != null ?
                new ObjectParameter("tolocation", tolocation) :
                new ObjectParameter("tolocation", typeof(string));
    
            var fromdateParameter = fromdate.HasValue ?
                new ObjectParameter("fromdate", fromdate) :
                new ObjectParameter("fromdate", typeof(System.DateTime));
    
            var todateParameter = todate.HasValue ?
                new ObjectParameter("todate", todate) :
                new ObjectParameter("todate", typeof(System.DateTime));
    
            var mediumParameter = medium != null ?
                new ObjectParameter("medium", medium) :
                new ObjectParameter("medium", typeof(string));
    
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddTravelRequest2", fromlocationParameter, tolocationParameter, fromdateParameter, todateParameter, mediumParameter, useridParameter);
        }
    
        public virtual int AddTravelRequest3(string fromlocation, string tolocation, Nullable<System.DateTime> fromdate, Nullable<System.DateTime> todate, string medium, Nullable<int> userid)
        {
            var fromlocationParameter = fromlocation != null ?
                new ObjectParameter("fromlocation", fromlocation) :
                new ObjectParameter("fromlocation", typeof(string));
    
            var tolocationParameter = tolocation != null ?
                new ObjectParameter("tolocation", tolocation) :
                new ObjectParameter("tolocation", typeof(string));
    
            var fromdateParameter = fromdate.HasValue ?
                new ObjectParameter("fromdate", fromdate) :
                new ObjectParameter("fromdate", typeof(System.DateTime));
    
            var todateParameter = todate.HasValue ?
                new ObjectParameter("todate", todate) :
                new ObjectParameter("todate", typeof(System.DateTime));
    
            var mediumParameter = medium != null ?
                new ObjectParameter("medium", medium) :
                new ObjectParameter("medium", typeof(string));
    
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddTravelRequest3", fromlocationParameter, tolocationParameter, fromdateParameter, todateParameter, mediumParameter, useridParameter);
        }
    
        public virtual ObjectResult<spGetTravelRequestDetails1_Result> spGetTravelRequestDetails1(string loginid)
        {
            var loginidParameter = loginid != null ?
                new ObjectParameter("loginid", loginid) :
                new ObjectParameter("loginid", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetTravelRequestDetails1_Result>("spGetTravelRequestDetails1", loginidParameter);
        }
    
        public virtual ObjectResult<spApprovedRequest_Result> spApprovedRequest()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spApprovedRequest_Result>("spApprovedRequest");
        }
    
        public virtual ObjectResult<spGetNewRequest_Result> spGetNewRequest(string managerid)
        {
            var manageridParameter = managerid != null ?
                new ObjectParameter("managerid", managerid) :
                new ObjectParameter("managerid", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetNewRequest_Result>("spGetNewRequest", manageridParameter);
        }
    
        public virtual ObjectResult<spGetRecordsById_Result> spGetRecordsById(Nullable<int> requestId)
        {
            var requestIdParameter = requestId.HasValue ?
                new ObjectParameter("RequestId", requestId) :
                new ObjectParameter("RequestId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetRecordsById_Result>("spGetRecordsById", requestIdParameter);
        }
    
        public virtual ObjectResult<spHistoryRecords_Result> spHistoryRecords()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spHistoryRecords_Result>("spHistoryRecords");
        }
    
        public virtual ObjectResult<spRejectedRequest_Result> spRejectedRequest()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spRejectedRequest_Result>("spRejectedRequest");
        }
    
        public virtual ObjectResult<spGetNewRequests_Result> spGetNewRequests(string managerid)
        {
            var manageridParameter = managerid != null ?
                new ObjectParameter("managerid", managerid) :
                new ObjectParameter("managerid", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetNewRequests_Result>("spGetNewRequests", manageridParameter);
        }
    
        public virtual ObjectResult<viewCancel_Result> viewCancel(string loginid)
        {
            var loginidParameter = loginid != null ?
                new ObjectParameter("loginid", loginid) :
                new ObjectParameter("loginid", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<viewCancel_Result>("viewCancel", loginidParameter);
        }
    
        public virtual int AddEmployee(string loginid, string password, string name)
        {
            var loginidParameter = loginid != null ?
                new ObjectParameter("loginid", loginid) :
                new ObjectParameter("loginid", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddEmployee", loginidParameter, passwordParameter, nameParameter);
        }
    
        public virtual int AddEmployee1(string loginid, string password, Nullable<int> usertype, string name, Nullable<int> manageruserid)
        {
            var loginidParameter = loginid != null ?
                new ObjectParameter("loginid", loginid) :
                new ObjectParameter("loginid", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var usertypeParameter = usertype.HasValue ?
                new ObjectParameter("usertype", usertype) :
                new ObjectParameter("usertype", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var manageruseridParameter = manageruserid.HasValue ?
                new ObjectParameter("manageruserid", manageruserid) :
                new ObjectParameter("manageruserid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddEmployee1", loginidParameter, passwordParameter, usertypeParameter, nameParameter, manageruseridParameter);
        }
    
        public virtual int addmanager(string loginid, string password, string name)
        {
            var loginidParameter = loginid != null ?
                new ObjectParameter("loginid", loginid) :
                new ObjectParameter("loginid", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("addmanager", loginidParameter, passwordParameter, nameParameter);
        }
    
        public virtual int addmyusers(string loginid, string password, Nullable<int> usertype, string name, Nullable<int> manageruserid)
        {
            var loginidParameter = loginid != null ?
                new ObjectParameter("loginid", loginid) :
                new ObjectParameter("loginid", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var usertypeParameter = usertype.HasValue ?
                new ObjectParameter("usertype", usertype) :
                new ObjectParameter("usertype", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var manageruseridParameter = manageruserid.HasValue ?
                new ObjectParameter("manageruserid", manageruserid) :
                new ObjectParameter("manageruserid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("addmyusers", loginidParameter, passwordParameter, usertypeParameter, nameParameter, manageruseridParameter);
        }
    
        public virtual int addtravelagent(string loginid, string password, string name)
        {
            var loginidParameter = loginid != null ?
                new ObjectParameter("loginid", loginid) :
                new ObjectParameter("loginid", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("addtravelagent", loginidParameter, passwordParameter, nameParameter);
        }
    
        public virtual int AssignManager(Nullable<int> userid, Nullable<int> manageruserid)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            var manageruseridParameter = manageruserid.HasValue ?
                new ObjectParameter("manageruserid", manageruserid) :
                new ObjectParameter("manageruserid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AssignManager", useridParameter, manageruseridParameter);
        }
    
        public virtual int ChangeManager(Nullable<int> userid, Nullable<int> manageruserid)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            var manageruseridParameter = manageruserid.HasValue ?
                new ObjectParameter("manageruserid", manageruserid) :
                new ObjectParameter("manageruserid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ChangeManager", useridParameter, manageruseridParameter);
        }
    
        public virtual int ChangeTravelStatus(Nullable<int> requestId, string currentStatus)
        {
            var requestIdParameter = requestId.HasValue ?
                new ObjectParameter("RequestId", requestId) :
                new ObjectParameter("RequestId", typeof(int));
    
            var currentStatusParameter = currentStatus != null ?
                new ObjectParameter("CurrentStatus", currentStatus) :
                new ObjectParameter("CurrentStatus", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ChangeTravelStatus", requestIdParameter, currentStatusParameter);
        }
    
        public virtual int ChangeTravelStatus1(Nullable<int> requestId, string currentStatus, string loginId)
        {
            var requestIdParameter = requestId.HasValue ?
                new ObjectParameter("RequestId", requestId) :
                new ObjectParameter("RequestId", typeof(int));
    
            var currentStatusParameter = currentStatus != null ?
                new ObjectParameter("CurrentStatus", currentStatus) :
                new ObjectParameter("CurrentStatus", typeof(string));
    
            var loginIdParameter = loginId != null ?
                new ObjectParameter("LoginId", loginId) :
                new ObjectParameter("LoginId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ChangeTravelStatus1", requestIdParameter, currentStatusParameter, loginIdParameter);
        }
    
        public virtual ObjectResult<ConfirmedTicket_Result> ConfirmedTicket()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ConfirmedTicket_Result>("ConfirmedTicket");
        }
    
        public virtual int DeleteEmp(Nullable<int> userid)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteEmp", useridParameter);
        }
    
        public virtual int DeleteManager(Nullable<int> userid)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteManager", useridParameter);
        }
    
        public virtual int DeleteTravelAgent(Nullable<int> userid)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteTravelAgent", useridParameter);
        }
    
        public virtual ObjectResult<getCount_Result> getCount(string loginId)
        {
            var loginIdParameter = loginId != null ?
                new ObjectParameter("LoginId", loginId) :
                new ObjectParameter("LoginId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getCount_Result>("getCount", loginIdParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> getCount1(string loginId)
        {
            var loginIdParameter = loginId != null ?
                new ObjectParameter("LoginId", loginId) :
                new ObjectParameter("LoginId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("getCount1", loginIdParameter);
        }
    
        public virtual ObjectResult<GetDetails_Result> GetDetails(Nullable<int> requestId)
        {
            var requestIdParameter = requestId.HasValue ?
                new ObjectParameter("RequestId", requestId) :
                new ObjectParameter("RequestId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetDetails_Result>("GetDetails", requestIdParameter);
        }
    
        public virtual ObjectResult<GetEmpDetails_Result> GetEmpDetails(Nullable<int> userid)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetEmpDetails_Result>("GetEmpDetails", useridParameter);
        }
    
        public virtual ObjectResult<GetManager_Result> GetManager(Nullable<int> userid)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetManager_Result>("GetManager", useridParameter);
        }
    
        public virtual ObjectResult<GetTravelAgent_Result> GetTravelAgent(Nullable<int> userid)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetTravelAgent_Result>("GetTravelAgent", useridParameter);
        }
    
        public virtual ObjectResult<GetUser_Result> GetUser(Nullable<int> userid)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetUser_Result>("GetUser", useridParameter);
        }
    
        public virtual ObjectResult<GetUser1_Result> GetUser1(Nullable<int> userid)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetUser1_Result>("GetUser1", useridParameter);
        }
    
        public virtual int MyUser(string loginid, string password, string usertypeid, string name)
        {
            var loginidParameter = loginid != null ?
                new ObjectParameter("loginid", loginid) :
                new ObjectParameter("loginid", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var usertypeidParameter = usertypeid != null ?
                new ObjectParameter("usertypeid", usertypeid) :
                new ObjectParameter("usertypeid", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MyUser", loginidParameter, passwordParameter, usertypeidParameter, nameParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> spEmpCheckLoginDetails(string loginid, string password)
        {
            var loginidParameter = loginid != null ?
                new ObjectParameter("loginid", loginid) :
                new ObjectParameter("loginid", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("spEmpCheckLoginDetails", loginidParameter, passwordParameter);
        }
    
        public virtual int spexample(Nullable<int> requestId, string managerStatus, string loginid)
        {
            var requestIdParameter = requestId.HasValue ?
                new ObjectParameter("RequestId", requestId) :
                new ObjectParameter("RequestId", typeof(int));
    
            var managerStatusParameter = managerStatus != null ?
                new ObjectParameter("ManagerStatus", managerStatus) :
                new ObjectParameter("ManagerStatus", typeof(string));
    
            var loginidParameter = loginid != null ?
                new ObjectParameter("loginid", loginid) :
                new ObjectParameter("loginid", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spexample", requestIdParameter, managerStatusParameter, loginidParameter);
        }
    
        public virtual int spUpdateApproveRequest(Nullable<int> requestId, string managerStatus)
        {
            var requestIdParameter = requestId.HasValue ?
                new ObjectParameter("RequestId", requestId) :
                new ObjectParameter("RequestId", typeof(int));
    
            var managerStatusParameter = managerStatus != null ?
                new ObjectParameter("ManagerStatus", managerStatus) :
                new ObjectParameter("ManagerStatus", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spUpdateApproveRequest", requestIdParameter, managerStatusParameter);
        }
    
        public virtual int UpdateEmp(Nullable<int> userid, string loginid, string password, string name)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            var loginidParameter = loginid != null ?
                new ObjectParameter("loginid", loginid) :
                new ObjectParameter("loginid", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateEmp", useridParameter, loginidParameter, passwordParameter, nameParameter);
        }
    
        public virtual int UpdateManager(Nullable<int> userid, string loginid, string password, string name)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            var loginidParameter = loginid != null ?
                new ObjectParameter("loginid", loginid) :
                new ObjectParameter("loginid", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateManager", useridParameter, loginidParameter, passwordParameter, nameParameter);
        }
    
        public virtual int UpdateTravelAgent(Nullable<int> userid, string loginid, string password, string name)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            var loginidParameter = loginid != null ?
                new ObjectParameter("loginid", loginid) :
                new ObjectParameter("loginid", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateTravelAgent", useridParameter, loginidParameter, passwordParameter, nameParameter);
        }
    
        public virtual ObjectResult<UserDetails_Result> UserDetails()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UserDetails_Result>("UserDetails");
        }
    
        public virtual ObjectResult<usp_TravelRequests_Travelagent_Result> usp_TravelRequests_Travelagent()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_TravelRequests_Travelagent_Result>("usp_TravelRequests_Travelagent");
        }
    
        public virtual ObjectResult<ViewEmpDetails_Result> ViewEmpDetails()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ViewEmpDetails_Result>("ViewEmpDetails");
        }
    
        public virtual ObjectResult<ViewManagerDetails_Result> ViewManagerDetails()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ViewManagerDetails_Result>("ViewManagerDetails");
        }
    
        public virtual ObjectResult<ViewTravelAgentDetails_Result> ViewTravelAgentDetails()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ViewTravelAgentDetails_Result>("ViewTravelAgentDetails");
        }
    }
}
