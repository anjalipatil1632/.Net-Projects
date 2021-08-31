using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeTravelBooking_DAL;
using EmployeeTravelBookingBAL;
using EmployeeTravelBooking_Exceptions;

namespace EmployeeTravelBooking_BAL
{
    public class EmpTravelBookingBAL
    {
        EmpTravelBookingOerations dalobj = new EmpTravelBookingOerations();
        //EmployeesBAL
        public int loginformcheck(string val1,string val2)
        {
            return dalobj.LoginPageCheck(val1, val2);
        }
        public int Managerloginformcheck(string val1, string val2)
        {
            return dalobj.ManagerLoginPageCheck(val1, val2);
        }
        public int Travelagentloginformcheck(string val1, string val2)
        {
            return dalobj.TravelAgentLoginPageCheck(val1, val2);
        }
        public int Adminloginformcheck(string val1, string val2)
        {
            return dalobj.AdminLoginPageCheck(val1, val2);
        }
        public DataTable GetTravelData(string val)
        {
            return dalobj.gettravelrequestdetails(val);
        }
        public int AddRequest(TravelRequests objtravelrequest)
        {
              
                return dalobj.AddTravelRequest(objtravelrequest);
                    
        }
        public int CancelBookingRequest(int val)
        {

            return dalobj.CancelTicket(val);

        }
        //managerBAL
        public DataTable getNewRequest()
        {
            return dalobj.getNewRequest();
        }

        public int approveNewRequest(int id)
        {
            return dalobj.approvedRequest(id);
        }

        public int rejectRequest(int id)
        {
            return dalobj.rejectNewRequest(id);
        }

        public DataTable getApproveRequest()
        {
            return dalobj.getApprovedRequest();
        }

        public DataTable getRejectRequest()
        {
            return dalobj.getRejectedRequest();
        }

        public DataTable getHistoryRequests()
        {
            return dalobj.getRequestHistory();
        }

        //travel agent
        public DataTable usp_TravelRequests()
        {
            return dalobj.usp_TravelRequests();
        }
        public int confirmed(int id)
        {
            return dalobj.confirmedRequest(id);
        }

        public int notAvailable(int id)
        {
            return dalobj.notAvailableRequest(id);
        }

        public DataTable getConfirmedTickets()
        {
            return dalobj.getConfirmedTicket();
        }

        public int getTicketCounts()
        {
            return dalobj.getTicketCount();
        }

        //admin bal
        public DataTable getUsers()
        {
            return dalobj.getUsers();
        }
        public DataTable getManager()
        {
            return dalobj.getManager();
        }
        public DataTable getEmployeeDetailsOnly()
        {
            return dalobj.getEmployeeDetailsOnly();
        }
        public DataTable getTravelAgent()
        {
            return dalobj.getTravelAgent();
        }
        public int insertUsers(Users obj)
        {
            return dalobj.insertUsers(obj);
        }
        public int assignManager(Users obj)
        {
            return dalobj.assignManager(obj);
        }
        public int changeManager(Users obj)
        {
            return dalobj.changeManager(obj);
        }
        public int addTravelAgent(Users obj)
        {
            return dalobj.addTravelAgent(obj);
        }
        public int deleteTravelAgent(int id)
        {
            return dalobj.deleteTravelAgent(id);
        }
        public int deleteEmployee(int id)
        {
            return dalobj.deleteEmployee(id);
        }
        public int deleteManager(int id)
        {
            return dalobj.deleteManager(id);
        }
        public int updateLoginId(Users obj)
        {
            return dalobj.updateLoginId(obj);
        }
        public int updatePassword(Users obj)
        {
            return dalobj.updatePassword(obj);
        }
        public int updateUserType(Users obj)
        {
            return dalobj.updateUserType(obj);
        }
        public int updateName(Users obj)
        {
            return dalobj.updateName(obj);
        }
       

    }
}
