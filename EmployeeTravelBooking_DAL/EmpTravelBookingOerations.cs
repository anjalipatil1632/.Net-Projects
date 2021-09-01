using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using EmployeeTravelBookingBAL; //BEL
using EmployeeTravelBooking_Exceptions;

namespace EmployeeTravelBooking_DAL
{
    public class EmpTravelBookingOerations
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        string getConnection()
        {
            string connectionString = "data source=localhost\\sqlexpress; database=Sprintdb; integrated security=true";
            return connectionString;
        }
        //EmployeeDAL//
        public int LoginPageCheck(string val, string val2)
        {
            int usercount;
            //DataSet ds;

            using (sqlConnection = new SqlConnection(getConnection()))
            {
                sqlConnection.Open();
                using (sqlCommand = new SqlCommand("spEmpCheckLoginDetails", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@loginid", val);
                    sqlCommand.Parameters.AddWithValue("@password", val2);
                    usercount = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    sqlConnection.Close();
                }
            }
            return usercount;

        }
        public int ManagerLoginPageCheck(string val, string val2)
        {
            int usercount;
            //DataSet ds;

            using (sqlConnection = new SqlConnection(getConnection()))
            {
                sqlConnection.Open();
                using (sqlCommand = new SqlCommand("spManagerCheckLoginDetails", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@loginid", val);
                    sqlCommand.Parameters.AddWithValue("@password", val2);
                    usercount = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    sqlConnection.Close();
                }
            }
            return usercount;

        }
        public int TravelAgentLoginPageCheck(string val, string val2)
        {
            int usercount;
            //DataSet ds;

            using (sqlConnection = new SqlConnection(getConnection()))
            {
                sqlConnection.Open();
                using (sqlCommand = new SqlCommand("spTravelAgentCheckLoginDetails", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@loginid", val);
                    sqlCommand.Parameters.AddWithValue("@password", val2);
                    usercount = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    sqlConnection.Close();
                }
            }
            return usercount;

        }
        public int AdminLoginPageCheck(string val, string val2)
        {
            int usercount;
            //DataSet ds;

            using (sqlConnection = new SqlConnection(getConnection()))
            {
                sqlConnection.Open();
                using (sqlCommand = new SqlCommand("spAdminCheckLoginDetails", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@loginid", val);
                    sqlCommand.Parameters.AddWithValue("@password", val2);
                    usercount = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    sqlConnection.Close();
                }
            }
            return usercount;

        }
        public DataTable gettravelrequestdetails(string val)
        {
                DataSet ds;
                using (sqlConnection = new SqlConnection(getConnection()))
                {
                    using (sqlCommand = new SqlCommand("spGetTravelRequestDetails", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@loginid", val);
                        SqlDataAdapter ada = new SqlDataAdapter();
                        ada.SelectCommand = sqlCommand;
                        ds = new DataSet();
                        ada.Fill(ds, "TravelRequests");

                    }
                }
                return ds.Tables["TravelRequests"];
        }
        public int AddTravelRequest(TravelRequests objtravelrequest)
        {
            int RowsAffected = 0;


            using (sqlConnection = new SqlConnection(getConnection()))
            {


                using (sqlCommand = new SqlCommand("AddTravelRequest", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@requestedate", objtravelrequest.RequestDate);
                    sqlCommand.Parameters.AddWithValue("@fromlocation", objtravelrequest.FromLocation);
                    sqlCommand.Parameters.AddWithValue("@tolocation", objtravelrequest.ToLocation);
                    sqlCommand.Parameters.AddWithValue("@fromdate", objtravelrequest.FromDate);
                    sqlCommand.Parameters.AddWithValue("@todate", objtravelrequest.ToDate);
                    sqlCommand.Parameters.AddWithValue("@medium", objtravelrequest.Medium);
                    sqlCommand.Parameters.AddWithValue("@userid", objtravelrequest.UserId);
                    sqlCommand.Parameters.AddWithValue("@currentstatus", objtravelrequest.CurrentStatus);
                    sqlCommand.Parameters.AddWithValue("@managerstatus", objtravelrequest.ManagerStatus);


                    sqlConnection.Open();
                    RowsAffected = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            return RowsAffected;

        }
        public int CancelTicket(int requestid)
        {
            int RowsAffected = 0;


            using (sqlConnection = new SqlConnection(getConnection()))
            {


                using (sqlCommand = new SqlCommand("spCancelTicket", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@requestid", requestid);
                    sqlConnection.Open();
                    RowsAffected = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();

                }
            }
            return RowsAffected;
        }
        //ManagerDAL//
        public DataTable getNewRequest()
        {
            DataSet dataSet;
            using (sqlConnection = new SqlConnection(getConnection()))
            {
                using (sqlCommand = new SqlCommand("getNewRequest", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = sqlCommand;
                    dataSet = new DataSet();
                    dataAdapter.Fill(dataSet, "TravelRequests");
                }
            }
            return dataSet.Tables["TravelRequests"];
        }


        //update manager status
        public int approvedRequest(int id)
        {
            int returnvalue = 0;
            using (sqlConnection = new SqlConnection(getConnection()))
            {
                using (sqlCommand = new SqlCommand("update TravelRequests set ManagerStatus='Approved' where RequestId=@id", sqlConnection))
                {
                    //command.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    try
                    {
                        sqlConnection.Open();
                        returnvalue = sqlCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
            }
            return returnvalue;
        }

        public int rejectNewRequest(int id)
        {
            int returnvalue = 0;
            using (sqlConnection = new SqlConnection(getConnection()))
            {
                using (sqlCommand = new SqlCommand("update TravelRequests set ManagerStatus='Rejected',CurrentStatus='Request Rejected' where RequestId=@id", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    try
                    {
                        sqlConnection.Open();
                        returnvalue = sqlCommand.ExecuteNonQuery();
                        if (returnvalue > 0)
                            Console.WriteLine("Update successfully");
                        else
                            Console.WriteLine("Not updated");
                    }
                    catch (SqlException ex) { Console.WriteLine(ex.Message); }
                    finally
                    {
                        sqlConnection.Close();
                    }

                }
            }
            return returnvalue;
        }

        public DataTable getApprovedRequest()
        {
            DataSet dataSet;
            using (sqlConnection = new SqlConnection(getConnection()))
            {
                using (sqlCommand = new SqlCommand("getApprovedRequest", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = sqlCommand;
                    dataSet = new DataSet();
                    dataAdapter.Fill(dataSet, "TravelRequests");
                }
            }
            return dataSet.Tables["TravelRequests"];
        }

        public DataTable getRejectedRequest()
        {
            DataSet dataSet;
            using (sqlConnection = new SqlConnection(getConnection()))
            {
                using (sqlCommand = new SqlCommand("getRejectedRequest", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = sqlCommand;
                    dataSet = new DataSet();
                    dataAdapter.Fill(dataSet, "TravelRequests");
                }
            }
            return dataSet.Tables["TravelRequests"];
        }

        public DataTable getRequestHistory()
        {
            DataSet dataSet;
            using (sqlConnection = new SqlConnection(getConnection()))
            {
                using (sqlCommand = new SqlCommand("getHistoryRequest", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = sqlCommand;
                    dataSet = new DataSet();
                    dataAdapter.Fill(dataSet, "TravelRequests");
                }
            }
            return dataSet.Tables["TravelRequests"];
        }

        //Travel agent DAL
        public DataTable usp_TravelRequests()
        {
            DataSet ds;
            using (sqlConnection = new SqlConnection(getConnection()))
            {
                using (sqlCommand = new SqlCommand("usp_TravelRequests_Travelagent", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter ada = new SqlDataAdapter();
                    ada.SelectCommand = sqlCommand;
                    ds = new DataSet();
                    ada.Fill(ds, "TravelRequests");

                }
            }
            return ds.Tables["TravelRequests"];
        }
        public int confirmedRequest(int id)
        {
            int returnvalue = 0;
            using (sqlConnection = new SqlConnection(getConnection()))
            {
                using (sqlCommand = new SqlCommand("update TravelRequests set CurrentStatus='Ticket Confirmed' where RequestId=@id", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    try
                    {
                        sqlConnection.Open();
                        returnvalue = sqlCommand.ExecuteNonQuery();
                        if (returnvalue > 0)
                            Console.WriteLine("Booking Confirmed");
                        else
                            Console.WriteLine("Not Confirmed");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
            }
            return returnvalue;

        }


        public int notAvailableRequest(int id)
        {
            int returnvalue = 0;
            using (sqlConnection = new SqlConnection(getConnection()))
            {
                using (sqlCommand = new SqlCommand("update TravelRequests set CurrentStatus='Ticket Not Available' where RequestId=@id", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    try
                    {
                        sqlConnection.Open();
                        returnvalue = sqlCommand.ExecuteNonQuery();
                        if (returnvalue > 0)
                            Console.WriteLine("Ticket Not Available");

                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
            }
            return returnvalue;

        }

        public DataTable getConfirmedTicket()
        {
            DataSet ds;
            using (sqlConnection = new SqlConnection(getConnection()))
            {
                using (sqlCommand = new SqlCommand("ConfirmedTicket", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter ada = new SqlDataAdapter();
                    ada.SelectCommand = sqlCommand;
                    ds = new DataSet();
                    ada.Fill(ds, "TravelRequests");

                }
            }
            return ds.Tables["TravelRequests"];
        }

        public int getTicketCount()
        {
            int count = 0;
            using (sqlConnection = new SqlConnection(getConnection()))
            {
                using (sqlCommand = new SqlCommand("countTicket", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    count = (int)sqlCommand.ExecuteScalar();
                    sqlConnection.Close();
                }
            }
            return count;
        }

        //Admin DAL
        public DataTable getUsers()
        {
            DataSet ds_getUsers = new DataSet();
            using (sqlConnection = new SqlConnection(getConnection()))
            {
                using (sqlCommand = new SqlCommand("ViewEmpDetails", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da_getUsers = new SqlDataAdapter();

                    da_getUsers.SelectCommand = sqlCommand;

                    da_getUsers.Fill(ds_getUsers, "Users");
                }
            }
            return ds_getUsers.Tables["Users"];

        }

        public DataTable getManager()
        {
            DataSet ds_getManager = new DataSet();
            using (sqlConnection = new SqlConnection(getConnection()))
            {
                using (sqlCommand = new SqlCommand("ViewManagerDetails", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da_getManager = new SqlDataAdapter();

                    da_getManager.SelectCommand = sqlCommand;

                    da_getManager.Fill(ds_getManager, "Users");
                }
            }
            return ds_getManager.Tables["Users"];

        }

        public DataTable getTravelAgent()
        {
            DataSet ds_getTravelAgent = new DataSet();
            using (sqlConnection = new SqlConnection(getConnection()))
            {
                using (sqlCommand = new SqlCommand("ViewTravelAgentDetails", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da_getTravelAgent = new SqlDataAdapter();

                    da_getTravelAgent.SelectCommand = sqlCommand;

                    da_getTravelAgent.Fill(ds_getTravelAgent, "Users");
                }
            }
            return ds_getTravelAgent.Tables["Users"];

        }
        public int insertUsers(Users obj)
        {
            int returnValue = 0;
            using (sqlConnection = new SqlConnection(getConnection()))
            {
                using (sqlCommand = new SqlCommand("AddEmployee", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@loginid", obj.LoginId);
                    sqlCommand.Parameters.AddWithValue("@password", obj.Password);
                    sqlCommand.Parameters.AddWithValue("@usertype", obj.UserTypeId);
                    sqlCommand.Parameters.AddWithValue("@name", obj.Name);
                    sqlCommand.Parameters.AddWithValue("@manageruserid", obj.ManagerUserId);

                    sqlConnection.Open();
                    returnValue = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            return returnValue;
        }

        public int assignManager(Users obj)
        {
            int returnValue = 0;
            using (sqlConnection = new SqlConnection(getConnection()))
            {
                using (sqlCommand = new SqlCommand("AssignManager", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@userid", obj.UserId);
                    sqlCommand.Parameters.AddWithValue("@manageruserid", obj.ManagerUserId);

                    sqlConnection.Open();
                    returnValue = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }

            }
            return returnValue;
        }

        public int changeManager(Users obj)
        {
            int returnValue = 0;
            using (sqlConnection = new SqlConnection(getConnection()))
            {
                using (sqlCommand = new SqlCommand("AssignManager", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@userid", obj.UserId);
                    sqlCommand.Parameters.AddWithValue("@manageruserid", obj.ManagerUserId);

                    sqlConnection.Open();
                    returnValue = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }

            }
            return returnValue;
        }

        public int addTravelAgent(Users obj)
        {
            int returnValue = 0;
            using (sqlConnection = new SqlConnection(getConnection()))
            {
                using (sqlCommand = new SqlCommand("addTravelAgent", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@loginid", obj.LoginId);
                    sqlCommand.Parameters.AddWithValue("@password", obj.Password);
                    sqlCommand.Parameters.AddWithValue("@usertype", obj.UserTypeId);
                    sqlCommand.Parameters.AddWithValue("@name", obj.Name);
                    sqlCommand.Parameters.AddWithValue("@manageruserid", obj.ManagerUserId);

                    sqlConnection.Open();
                    returnValue = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            return returnValue;
        }

        public int deleteTravelAgent(int id)
        {
            int returnValue = 0;
            using (sqlConnection = new SqlConnection(getConnection()))
            {
                using (sqlCommand = new SqlCommand("DELETE FROM users WHERE UserId=@UserId", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@UserId", id);
                    try
                    {
                        sqlConnection.Open();
                        returnValue = sqlCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }

                }

            }
            return returnValue;
        }

        public int deleteEmployee(int id)
        {
            int returnValue = 0;
            using (sqlConnection = new SqlConnection(getConnection()))
            {
                using (sqlCommand = new SqlCommand("DELETE FROM users WHERE UserId=@UserId", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@UserId", id);
                    try
                    {
                        sqlConnection.Open();
                        returnValue = sqlCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }

                }

            }
            return returnValue;
        }

        public int deleteManager(int id)
        {
            int returnValue = 0;
            using (sqlConnection = new SqlConnection(getConnection()))
            {
                using (sqlCommand = new SqlCommand("delete from Users where UserId=@UserId", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@UserId", id);
                    try
                    {
                        sqlConnection.Open();
                        returnValue = sqlCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }

                }

            }
            return returnValue;
        }

        public int updateLoginId(Users obj)
        {
            int returnValue = 0;
            using (sqlConnection = new SqlConnection(getConnection()))
            {
                using (sqlCommand = new SqlCommand("update Users set LoginId=@loginid where UserId=@userid", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@userid", obj.UserId);
                    sqlCommand.Parameters.AddWithValue("@loginid", obj.LoginId);
                    try
                    {
                        sqlConnection.Open();
                        returnValue = sqlCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }

                }

            }
            return returnValue;
        }

        public int updatePassword(Users obj)
        {
            int returnValue = 0;
            using (sqlConnection = new SqlConnection(getConnection()))
            {
                using (sqlCommand = new SqlCommand("update Users set Password=@password where UserId=@userid", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@userid", obj.UserId);
                    sqlCommand.Parameters.AddWithValue("@password", obj.Password);
                    try
                    {
                        sqlConnection.Open();
                        returnValue = sqlCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }

                }

            }
            return returnValue;
        }

        public int updateUserType(Users obj)
        {
            int returnValue = 0;
            using (sqlConnection = new SqlConnection(getConnection()))
            {
                using (sqlCommand = new SqlCommand("update Users set UserTypeId=@usertype where UserId=@userid", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@userid", obj.UserId);
                    sqlCommand.Parameters.AddWithValue("@usertype", obj.UserTypeId);
                    try
                    {
                        sqlConnection.Open();
                        returnValue = sqlCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }

                }

            }
            return returnValue;
        }

        public int updateName(Users obj)
        {
            int returnValue = 0;
            using (sqlConnection = new SqlConnection(getConnection()))
            {
                using (sqlCommand = new SqlCommand("update Users set Name=@name where UserId=@userid", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@userid", obj.UserId);
                    sqlCommand.Parameters.AddWithValue("@name", obj.Name);
                    try
                    {
                        sqlConnection.Open();
                        returnValue = sqlCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }

                }

            }
            return returnValue;
        }
        public DataTable getEmployeeDetailsOnly()
        {
            DataSet ds_getTravelAgent = new DataSet();
            using (sqlConnection = new SqlConnection(getConnection()))
            {
                using (sqlCommand = new SqlCommand("getEmployeeDetailsOnly", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da_getTravelAgent = new SqlDataAdapter();

                    da_getTravelAgent.SelectCommand = sqlCommand;

                    da_getTravelAgent.Fill(ds_getTravelAgent, "Users");
                }
            }
            return ds_getTravelAgent.Tables["Users"];
        }
    }



}
    

