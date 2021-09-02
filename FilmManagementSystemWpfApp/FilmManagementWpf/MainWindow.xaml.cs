using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FilmManagemenBAL;
using FilmManagementDAL;
using FilmManagementBEL;
using System.Data;
using System.Data.SqlClient;

namespace FilmManagementWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BusinessAccessLayer bal_obj = new BusinessAccessLayer();

        BusinessEntityLayerFilm film_obj = new BusinessEntityLayerFilm();

        Decimal ReplacementCost;

        int FilmID;

        SqlConnection connection = new SqlConnection("Server=DESKTOP-60VOIAI; Database=master; Integrated Security=true;");





        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //populating the Release Year Combobox
            SqlDataAdapter da_ReleaseYear = new SqlDataAdapter("SELECT * FROM tbl_ReleaseYear", connection);
            DataSet ds_ReleaseYear = new DataSet();
            da_ReleaseYear.Fill(ds_ReleaseYear, "tbl_ReleaseYear");
            cmb_ReleaseYear.ItemsSource = ds_ReleaseYear.Tables[0].DefaultView;
            cmb_ReleaseYear.DisplayMemberPath = ds_ReleaseYear.Tables[0].Columns["Year"].ToString();
            cmb_ReleaseYear.SelectedValuePath = ds_ReleaseYear.Tables[0].Columns["SLNum"].ToString();

            //populating the Rantal Rate Combobox
            SqlDataAdapter da_RentalRate = new SqlDataAdapter("SELECT * FROM tbl_RentalRate", connection);
            DataSet ds_RentalRate = new DataSet();
            da_RentalRate.Fill(ds_RentalRate, "tbl_RentalRate");
            cmb_RentalRate.ItemsSource = ds_RentalRate.Tables[0].DefaultView;
            cmb_RentalRate.DisplayMemberPath = ds_RentalRate.Tables[0].Columns["Rates"].ToString();
            cmb_RentalRate.SelectedValuePath = ds_RentalRate.Tables[0].Columns["SlNum"].ToString();

            //populating the Length Combobox
            SqlDataAdapter da_Length = new SqlDataAdapter("SELECT * FROM tbl_Length", connection);
            DataSet ds_Length = new DataSet();
            da_Length.Fill(ds_Length, "tbl_Length");
            cmb_Length.ItemsSource = ds_Length.Tables[0].DefaultView;
            cmb_Length.DisplayMemberPath = ds_Length.Tables[0].Columns["Length"].ToString();
            cmb_Length.SelectedValuePath = ds_Length.Tables[0].Columns["SlNum"].ToString();

            //populating the Category Combobox
            SqlDataAdapter da_Category = new SqlDataAdapter("SELECT * FROM tbl_category", connection);
            DataSet ds_Category = new DataSet();
            da_Category.Fill(ds_Category, "tbl_category");
            cmb_Category.ItemsSource = ds_Category.Tables[0].DefaultView;
            cmb_Category.DisplayMemberPath = ds_Category.Tables[0].Columns["Category"].ToString();
            cmb_Category.SelectedValuePath = ds_Category.Tables[0].Columns["CategoryID"].ToString();

            //populating the Language Combobox
            SqlDataAdapter da_Language = new SqlDataAdapter("SELECT * FROM tbl_language", connection);
            DataSet ds_Language = new DataSet();
            da_Language.Fill(ds_Language, "tbl_language");
            cmb_Language.ItemsSource = ds_Language.Tables[0].DefaultView;
            cmb_Language.DisplayMemberPath = ds_Language.Tables[0].Columns["Language"].ToString();
            cmb_Language.SelectedValuePath = ds_Language.Tables[0].Columns["LanguageID"].ToString();

            //populating the Actor Combobox
            SqlDataAdapter da_Actor = new SqlDataAdapter("SELECT * FROM tbl_actor", connection);
            DataSet ds_Actor = new DataSet();
            da_Actor.Fill(ds_Actor, "tbl_actor");
            cmb_Actor.ItemsSource = ds_Actor.Tables[0].DefaultView;
            cmb_Actor.DisplayMemberPath = ds_Actor.Tables[0].Columns["ActorName"].ToString();
            cmb_Actor.SelectedValuePath = ds_Actor.Tables[0].Columns["ActorID"].ToString();

            dgrd_Results.ItemsSource = bal_obj.getFilms().DefaultView;



             

        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            int TotalMonth;
            try
            {
                //Retriving and Calculating the Value of TotalMonth
                DateTime StartDate = Convert.ToDateTime(dp_RentStartDate.SelectedDate.Value);
                DateTime EndDate = Convert.ToDateTime(dp_RentEndDate.SelectedDate.Value);
                int Year = EndDate.Year - StartDate.Year;
                int Month = EndDate.Month - StartDate.Month;
                 TotalMonth = (Year * 12) + Month;
            }
            catch (Exception)
            {
                MessageBox.Show("Provide Start Date / End Date ");
                return;
            }

                 

            SqlCommand check_Film_Name = new SqlCommand("SELECT COUNT(*) FROM tbl_Film WHERE (title = @FilmTitle)", connection);
            check_Film_Name.Parameters.AddWithValue("@FilmTitle", txt_FilmTitle.Text);
            connection.Open();
            int UserExist = (int)check_Film_Name.ExecuteScalar();
            connection.Close();

            if ((HasSpecialChar(txt_FilmTitle.Text)) == true)
            {
                MessageBox.Show("Film Title cannot be Symbols");
                return;
            }
            //Input Check for Title
            if (int.TryParse(txt_FilmTitle.Text, out int result))
            {
                MessageBox.Show("Film Title Cannot Not be Number");
                return;
            }
            else if (txt_FilmTitle.Text == "")
            {
                MessageBox.Show("Enter Film Title");
            }
            //Input Check for UserExist
            else if (UserExist > 0)
            {
                MessageBox.Show(txt_FilmTitle.Text + " is already Present in our Database");
            }
            //Input Check for ReleaseYear
            else if (cmb_ReleaseYear.Text == "")
            {
                MessageBox.Show("Choose a Relese Year");
            }
            //Input Check for TotalMonth
            else if (TotalMonth == 0)
            {
                MessageBox.Show("Minimum Rental Duration must be 1 Month");
                dp_RentEndDate.Text = null;
                dp_RentStartDate.Text = null;

            }
            //Input Check for Replacement Cost
            else if (ReplacementCost == 0)
            {
                MessageBox.Show("Please Calculate the Replacement Cost ! ! !");
            }
            //Input Check for Rating
            else if ((Convert.ToInt32(lbl_RatingInput.Content)) == 0)
            {
                MessageBox.Show("Please Provide Rating");
            }
            //Input Check for Description
            else if (txt_FilmDescription.Text == "")
            {
                MessageBox.Show("Enter Film Description");
            }
            //Input Check for Category
            else if (cmb_Category.Text == "")
            {
                MessageBox.Show("Enter Category");
            }
            //Input Check for Language
            else if (cmb_Language.Text == "")
            {
                MessageBox.Show("Enter Language");
            }
            //Input Check for Actor Name
            else if (cmb_Actor.Text == "")
            {
                MessageBox.Show("Enter Actor Name");
            }
            //Input Check for Description as a Number
            else if (int.TryParse(txt_FilmDescription.Text, out int result1))
            {
                MessageBox.Show("Description Cannot be a Number");
                return;
            }
            else if ((HasSpecialChar(txt_FilmDescription.Text)) == true)
            {
                MessageBox.Show("Film Description Cannot be Symbols");
                return;
            }

            try
            {


                film_obj.Title = txt_FilmTitle.Text;

                film_obj.ReleaseYear = Convert.ToInt32(cmb_ReleaseYear.Text);

                film_obj.RentalDuration = TotalMonth;

                film_obj.RentalRate = Convert.ToInt32( cmb_RentalRate.Text);

                film_obj.Length = Convert.ToDouble(cmb_Length.Text);

                film_obj.ReplacementCost = Convert.ToDouble(ReplacementCost);

                film_obj.Rating = Convert.ToInt32(lbl_RatingInput.Content);

                film_obj.Description = txt_FilmDescription.Text;

                film_obj.CategoryID = Convert.ToInt32(cmb_Category.SelectedValue);

                film_obj.ActorID = Convert.ToInt32(cmb_Actor.SelectedValue);

                film_obj.LanguageID = Convert.ToInt32(cmb_Language.SelectedValue);



                int returnValue = bal_obj.insertFilms(film_obj);

                if (returnValue == 1)
                {
                    MessageBox.Show("Records Inserted");
                }

                else
                {
                    MessageBox.Show("Records Not Inserted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                
                clear();
                txt_FilmTitle.Focus();
            }

            dgrd_Results.ItemsSource = bal_obj.getFilms().DefaultView;



        }

        public static bool HasSpecialChar(string input)
        {
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            if (txt_Search.Text == "")
            {
                //MessageBox.Show("Look for ID by clicking 'VIEW ID' button ! !");
                MessageBox.Show("Enter Value to Search");
            }
            else if(rb_SearchByName.IsChecked==true)
            {
                try
                {
                    string FilmTitle = txt_Search.Text;

                    // DataTable dt = ;

                    dgrd_Results.ItemsSource = bal_obj.SearchTitle(FilmTitle).DefaultView;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            else if (rb_SearchByRating.IsChecked == true)
            {
                try
                {
                    int Rating = Convert.ToInt32(txt_Search.Text);

                    

                    dgrd_Results.ItemsSource = bal_obj.SearchRating(Rating).DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            else if (rb_SearchByLanguage.IsChecked == true)
            {
                try
                {
                    string Language=txt_Search.Text;

                    // DataTable dt = ;

                    dgrd_Results.ItemsSource = bal_obj.SearchLanguage(Language).DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            else if (rb_SearchByCategory.IsChecked == true)
            {
                try
                {
                    string CategoryId = txt_Search.Text;

                   

                    dgrd_Results.ItemsSource = bal_obj.SearchCategory(CategoryId).DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            else if (rb_SearchByActor.IsChecked == true)
            {
                try
                {
                    string ActorId = txt_Search.Text;

                    

                    dgrd_Results.ItemsSource = bal_obj.SearchActor(ActorId).DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                

            }

        }

        private void Btn_ViewID_Click(object sender, RoutedEventArgs e)
        {
            if (rb_SearchByName.IsChecked == true)
            {
                MessageBox.Show("Enter the Name of a Film");
            }
            else if (rb_SearchByActor.IsChecked == true)
            {
                MessageBox.Show("Enter the Actor Name from the List Below :- " + "\n" + "");
            }
            else if (rb_SearchByRating.IsChecked == true)
            {
                MessageBox.Show("Enter the Rating from 1 to 5 ");
            }
            else if (rb_SearchByCategory.IsChecked == true)
            {
                MessageBox.Show("Enter the Category Name from the List Below :-" + "\n" + "1. Horror " + "\n" + "2. Comedy" + "\n" + "3. Thriller" + "\n" + "4. Romance" + "\n" + "5. Action" + "\n" + "6. Drama" + "\n" + "7. Sports");
            }
            else if (rb_SearchByLanguage.IsChecked == true)
            {
                MessageBox.Show("Enter the Language ID from the List Below :- " + "\n" + "1. English " + "\n" + "2. Hindi" + "\n" + "3. Urdu" + "\n" + "4. Bengali" + "\n" + "5. Punjabi" + "\n" + "6. Tamil");
            }
            else
            {
                MessageBox.Show("Please Select a Search Category from Search option ! !");
            }
        }

        private void Btn_DeleteRecord_Click(object sender, RoutedEventArgs e)
        {
            int returnValue = 0;
            try
            {
                string FilmTitle = txt_FilmTitle.Text;

                returnValue = bal_obj.deleteFilm(FilmTitle);

                if(returnValue==1)
                {
                    MessageBox.Show("Record Deleted SuccessFull");
                }
                else
                {
                    MessageBox.Show("Record Not Deleted");
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
                txt_FilmTitle.Text = "";
                txt_FilmTitle.Focus();
                clear();
            }
            dgrd_Results.ItemsSource = bal_obj.getFilms().DefaultView;
            
        }

        public void clear()
        {
            txt_FilmTitle.Text = null;
            cmb_ReleaseYear.Text = null;
            dp_RentEndDate.Text = null;
            dp_RentStartDate.Text = null;
            cmb_RentalRate.Text = null;
            cmb_Length.Text = null;
            txt_ReplacementCost.Text = null;
            txt_FilmDescription.Text = null;
            cmb_Actor.Text = null;
            cmb_Category.Text = null;
            cmb_Language.Text = null;
        }

        private void Btn_ClearAll_Click(object sender, RoutedEventArgs e)
        {
            txt_FilmTitle.Text = null;
            cmb_ReleaseYear.Text = null;
            dp_RentEndDate.Text = null;
            dp_RentStartDate.Text = null;
            cmb_RentalRate.Text = null;
            cmb_Length.Text = null;
            txt_ReplacementCost.Text = null;
            txt_FilmDescription.Text = null;
            cmb_Actor.Text = null;
            cmb_Category.Text = null;
            cmb_Language.Text = null;
        }

        private void Btn_ShowAll_Click(object sender, RoutedEventArgs e)
        {
            dgrd_Results.ItemsSource = bal_obj.getFilms().DefaultView;
        }

        private void Btn_Modify_Click(object sender, RoutedEventArgs e)
        {
            if (txt_FilmTitle.Text == "")
            {
                MessageBox.Show("Enter Film Title to Modify Film Details");
                return;
            }


            else
            {
                SqlConnection connection = new SqlConnection("Server=DESKTOP-60VOIAI; Database=master; Integrated Security=true;");
                SqlCommand cmd = new SqlCommand("select * from tbl_Film where title = @title", connection);
                cmd.Parameters.AddWithValue("@Title", txt_FilmTitle.Text);


                connection.Open();
                SqlDataReader rdr;
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (rdr.Read())
                {
                    FilmID = Convert.ToInt32(rdr["FilmID"]);
                    txt_FilmTitle.Text = rdr["Title"].ToString();
                    cmb_ReleaseYear.Text = rdr["ReleaseYear"].ToString();
                    cmb_RentalRate.Text = rdr["RentalRate"].ToString();
                    cmb_Length.Text = rdr["Length"].ToString();
                    txt_ReplacementCost.Text = rdr["ReplacementCost"].ToString();
                    lbl_RatingInput.Content = rdr["Rating"].ToString();
                    txt_FilmDescription.Text = rdr["Description"].ToString();

                    ReplacementCost = Convert.ToDecimal(rdr["ReplacementCost"]);
                    //dp_RentStartDate.Text = rdr["RentStartDate"].ToString();
                    //dp_RentEndDate.Text = rdr["RentEndDate"].ToString();

                    cmb_Actor.SelectedValue = Convert.ToInt32(rdr["ActorID"]);
                    cmb_Category.SelectedValue = Convert.ToInt32(rdr["CategoryID"]);
                    cmb_Language.SelectedValue = Convert.ToInt32(rdr["LanguageID"]);



                }


            }
        }
                

        private void Btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            int TotalMonth;
            try
            {
                DateTime StartDate = Convert.ToDateTime(dp_RentStartDate.SelectedDate.Value);
                DateTime EndDate = Convert.ToDateTime(dp_RentEndDate.SelectedDate.Value);
                int Year = EndDate.Year - StartDate.Year;
                int Month = EndDate.Month - StartDate.Month;
                TotalMonth = (Year * 12) + Month;
            }
            catch (Exception)
            {
                MessageBox.Show("Provide Start Date / End Date ");
                return;
            }


   
            

            if (FilmID == 0)
            {
                MessageBox.Show("Please Search Values First using Modify Button then click Submit Button");
            }
           


            else if (cmb_ReleaseYear.Text == "")
            {
                MessageBox.Show("Choose a Relese Year");
            }
            //Input Check for TotalMonth
            else if (TotalMonth == 0)
            {
                MessageBox.Show("Minimum Rental Duration must be 1 Month");
                dp_RentEndDate.Text = null;
                dp_RentStartDate.Text = null;

            }
            //Input Check for Replacement Cost
            else if (ReplacementCost == 0)
            {
                MessageBox.Show("Please Calculate the Replacement Cost ! ! !");
            }
            //Input Check for Rating
            else if ((Convert.ToInt32(lbl_RatingInput.Content)) == 0)
            {
                MessageBox.Show("Please Provide Rating");
            }
            //Input Check for Description
            else if (txt_FilmDescription.Text == "")
            {
                MessageBox.Show("Enter Film Description");
            }
           
            //Input Check for Category
            else if (cmb_Category.Text == "")
            {
                MessageBox.Show("Enter Category");
            }
            //Input Check for Language
            else if (cmb_Language.Text == "")
            {
                MessageBox.Show("Enter Language");
            }
            //Input Check for Actor
            else if (cmb_Actor.Text == "")
            {
                MessageBox.Show("Enter Actor Name");
            }
            //Check for totl Month
            else if (TotalMonth == 0)
            {
                MessageBox.Show("Minimum Rental Duration must be 1 Month");
                dp_RentEndDate.Text = null;
                dp_RentStartDate.Text = null;

            }
    
          
            else
            {
                string Filmtitle = txt_FilmTitle.Text;

                film_obj.Title = txt_FilmTitle.Text;

                film_obj.ReleaseYear = Convert.ToInt32(cmb_ReleaseYear.Text);

                film_obj.RentalDuration = TotalMonth;

                film_obj.RentalRate = Convert.ToDouble(cmb_RentalRate.Text);

                film_obj.Length = Convert.ToDouble(cmb_Length.Text);

                film_obj.ReplacementCost = Convert.ToDouble(ReplacementCost);

                film_obj.Rating = Convert.ToInt32(lbl_RatingInput.Content);

                film_obj.Description = txt_FilmDescription.Text;

                film_obj.CategoryID = Convert.ToInt32(cmb_Category.SelectedValue);

                film_obj.ActorID = Convert.ToInt32(cmb_Actor.SelectedValue);

                film_obj.LanguageID = Convert.ToInt32(cmb_Language.SelectedValue);

                int returnValue = bal_obj.UpdateFilms(Filmtitle, film_obj);

                if(returnValue==1)
                {
                    MessageBox.Show("Records Updated");
                }
                else
                {
                    MessageBox.Show("Failed To Update Record");
                }

                dgrd_Results.ItemsSource = bal_obj.getFilms().DefaultView;
            }

        }

        private void Btn_CalculateCost_Click(object sender, RoutedEventArgs e)
        {
            int RentalRate = Convert.ToInt16(cmb_RentalRate.Text);
            Decimal Length = Convert.ToDecimal(cmb_Length.Text);
            ReplacementCost = RentalRate * Length;

            txt_ReplacementCost.Text = ReplacementCost.ToString();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            lbl_RatingInput.Content = slider_rating.Value.ToString();
        }

       
    }
}
