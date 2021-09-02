using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using FilmManagementBEL;

namespace FilmManagementDAL
{
    public class DataAccessLayer
    {
        SqlConnection con;
        SqlCommand cmd;


        string getConnection()
        {
            string connectionString = "data source=.;initial catalog=master;integrated security=true";

            return connectionString;
        }

        public DataTable getFilms()
        {
            DataSet ds_getFilms = new DataSet();

            using (con = new SqlConnection(getConnection()))
            {
                using (cmd = new SqlCommand("getFilm", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da_getFilms = new SqlDataAdapter();

                    da_getFilms.SelectCommand = cmd;

                    da_getFilms.Fill(ds_getFilms, "tbl_Film");
                }
            }
            return ds_getFilms.Tables["tbl_Film"];
        }

        public int InsertFilm(BusinessEntityLayerFilm obj)
        {
            int returnValue = 0;
            using (con = new SqlConnection(getConnection()))
            {
                using (cmd = new SqlCommand("InsertFilm", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Title", obj.Title);
                    cmd.Parameters.AddWithValue("@ReleaseYear", obj.ReleaseYear);
                    cmd.Parameters.AddWithValue("@RentalDuration", obj.RentalDuration);
                    cmd.Parameters.AddWithValue("@RentalRate", obj.RentalRate);
                    cmd.Parameters.AddWithValue("@Length", obj.Length);
                    cmd.Parameters.AddWithValue("@ReplacementCost", obj.ReplacementCost);
                    cmd.Parameters.AddWithValue("@Rating", obj.Rating);
                    cmd.Parameters.AddWithValue("@Description", obj.Description);
                    cmd.Parameters.AddWithValue("@CategoryID", obj.CategoryID);
                    cmd.Parameters.AddWithValue("@LanguageID", obj.LanguageID);
                    cmd.Parameters.AddWithValue("@ActorID", obj.ActorID);

                    con.Open();
                    returnValue = cmd.ExecuteNonQuery();
                    con.Close();


                }


            }


            return returnValue;
        }

        public int UpdateFilm(string FilmTitle, BusinessEntityLayerFilm obj)
        {
            int returnValue = 0;

            using (con = new SqlConnection(getConnection()))
            {
                using (cmd = new SqlCommand("UpdateFilm", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FilmTitle", FilmTitle);

                    cmd.Parameters.AddWithValue("@ReleaseYear", obj.ReleaseYear);

                    cmd.Parameters.AddWithValue("@RentalDuration", obj.RentalDuration);

                    cmd.Parameters.AddWithValue("@RentalRate", obj.RentalRate);

                    cmd.Parameters.AddWithValue("@Length", obj.Length);

                    cmd.Parameters.AddWithValue("@ReplacementCost", obj.ReplacementCost);

                    cmd.Parameters.AddWithValue("@Rating", obj.Rating);

                    cmd.Parameters.AddWithValue("@Description", obj.Description);

                    cmd.Parameters.AddWithValue("@CategoryID", obj.CategoryID);

                    cmd.Parameters.AddWithValue("@LanguageID", obj.LanguageID);

                    cmd.Parameters.AddWithValue("@ActorID", obj.ActorID);


                    con.Open();

                    returnValue = cmd.ExecuteNonQuery();

                    con.Close();

                }
            }
            return returnValue;

        }

        public DataTable SearchTitle(string FilmTitle)
        {
            DataSet ds = new DataSet();

            using (con = new SqlConnection(getConnection()))
            {
                using (cmd = new SqlCommand("SearchTitle", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Title", FilmTitle);

                    SqlDataAdapter da = new SqlDataAdapter();

                    da.SelectCommand = cmd;


                    da.Fill(ds);



                }
            }
            return ds.Tables[0];
        }

        public DataTable SearchRating(int Rating)
        {
            DataSet ds = new DataSet();

            using (con = new SqlConnection(getConnection()))
            {
                using (cmd = new SqlCommand("SearchRating", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Rating", Rating);

                    SqlDataAdapter da = new SqlDataAdapter();

                    da.SelectCommand = cmd;


                    da.Fill(ds);



                }
            }
            return ds.Tables[0];
        }

        public DataTable SearchLanguage(string LanguageId)
        {
            DataSet ds = new DataSet();

            int Language;
            using (con = new SqlConnection(getConnection()))
            {
                SqlCommand cmd2 = new SqlCommand("Select LanguageID from tbl_Language where Language=@Language", con);
                cmd2.Parameters.AddWithValue("@Language", LanguageId);
                con.Open();
                Language = Convert.ToInt32(cmd2.ExecuteScalar());
                con.Close();
            }

            //passing the LanguageID to retrive the columns
            using (con = new SqlConnection(getConnection()))
            {
                SqlCommand cmd = new SqlCommand("select Title,ReleaseYear,Rating,Description from tbl_Film where LanguageID=@LanguageID", con);
                cmd.Parameters.AddWithValue("@LanguageID", Language);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
            }
            return ds.Tables[0];

        }

        public DataTable SearchCategory(string CategoryId)
        {
            DataSet ds = new DataSet();
            int CategoryID;
            using (con = new SqlConnection(getConnection()))
            {
                SqlCommand cmd1 = new SqlCommand("Select CategoryID from tbl_Category where Category=@Category", con);
                cmd1.Parameters.AddWithValue("@Category", CategoryId);
                con.Open();
                CategoryID = Convert.ToInt32(cmd1.ExecuteScalar());
                con.Close();
            }

            using (con = new SqlConnection(getConnection()))
            {
                //passing the CategoryID to display the Columns
                SqlCommand cmd = new SqlCommand("select Title,ReleaseYear,Rating,Description from tbl_Film where CategoryID=@CategoryID", con);
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
            }
            return ds.Tables[0];
        }

        public DataTable SearchActor(string ActorId)
        {
            DataSet ds = new DataSet();
            int ActorID;
            using (con = new SqlConnection(getConnection()))
            {
                SqlCommand cmd3 = new SqlCommand("Select ActorID from tbl_actor where ActorName=@ActorName", con);
                cmd3.Parameters.AddWithValue("@ActorName", ActorId);
                con.Open();
                ActorID = Convert.ToInt32(cmd3.ExecuteScalar());
                con.Close();
            }

            //passing the CategoryID to view the columns
            using (con = new SqlConnection(getConnection()))
            {
                SqlCommand cmd = new SqlCommand("select Title,ReleaseYear,Rating,Description from tbl_Film where ActorID=@ActorID", con);
                cmd.Parameters.AddWithValue("@ActorID", ActorID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
            }

            return ds.Tables[0];



        }

        public int deleteFilm(string FilmTitle)
        {
            int returnValue = 0;

            using (con = new SqlConnection(getConnection()))
            {
                using (cmd = new SqlCommand("DeleteFilms", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FilmTitle", FilmTitle);

                    con.Open();

                    returnValue = cmd.ExecuteNonQuery();
                }

            }
            return returnValue;


        }
    }
}
