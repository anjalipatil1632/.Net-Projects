using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using System.IO;

namespace MvcApplication1.Controllers
{
    public class MainController : Controller
    {
        //
        // GET: /Main/

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        OleDbConnection Econ;

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {

            string filename = Guid.NewGuid() + Path.GetExtension(file.FileName);

            string filepath = "/excelfolder/" + filename;

            file.SaveAs(Path.Combine(Server.MapPath("/excelfolder"), filename));

            InsertExceldata(filepath, filename);

            ViewBag.Message ="File Imported Successfully !";

            return View();
        }
        
        private void InsertExceldata(string fileepath, string filename)
        {

            string fullpath = Server.MapPath("/excelfolder/") + filename;

            ExcelConn(fullpath);

            string query = string.Format("Select * from [{0}]", "Sheet1$");

            OleDbCommand Ecom = new OleDbCommand(query, Econ);

            Econ.Open();



            DataSet ds = new DataSet();

            OleDbDataAdapter oda = new OleDbDataAdapter(query, Econ);

            Econ.Close();

            oda.Fill(ds);



            DataTable dt = ds.Tables[0];



            SqlBulkCopy objbulk = new SqlBulkCopy(con);

            objbulk.DestinationTableName = "tbl_exceldata";

            objbulk.ColumnMappings.Add("SLA", "SLA");

            objbulk.ColumnMappings.Add("Incident_Number", "Incident_Number");

            objbulk.ColumnMappings.Add("Priority", "Priority");

            objbulk.ColumnMappings.Add("Assignment_Group", "Assignment_Group");

            objbulk.ColumnMappings.Add("State", "State");

            objbulk.ColumnMappings.Add("Start_Time", "Start_Time");

            objbulk.ColumnMappings.Add("Actual_Time_Left", "Actual_Time_Left");

            objbulk.ColumnMappings.Add("Actual_Elapsed_Percentage", "Actual_Elapsed_Percentage");

            con.Open();

            objbulk.WriteToServer(dt);

            con.Close();

        }

        private void ExcelConn(string filepath)
        {

            string constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", filepath);

            Econ = new OleDbConnection(constr);
        }


    }
}
