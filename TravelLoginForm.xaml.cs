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
using System.Windows.Shapes;

namespace EmployeeTravelBookingWPF
{
    /// <summary>
    /// Interaction logic for TravelLoginForm.xaml
    /// </summary>
    public partial class TravelLoginForm : Window
    {
        public TravelLoginForm()
        {
            InitializeComponent();
        }

        public class Exp : ApplicationException

        {
            public Exp()
            {
            }

            public Exp(string message) : base(message)
            {
            }

            //public Exec(string message, Exception innerException) : base(message, innerException)
            //{
            //}
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            using (SprintdbEntities dbobj = new SprintdbEntities())
            {


                StringBuilder sb = new StringBuilder();
                try
                {
                    if (txtUsername.Text == "")
                    {
                        sb.Append(Environment.NewLine + "Username Shouldn't be blank!");
                        throw new Exp(sb.ToString());
                    }
                    if (pwdbxPassword.Password == "")
                    {
                        sb.Append(Environment.NewLine + "Password Shouldn't be blank!");
                        throw new Exp(sb.ToString());
                    }
                    string username = txtUsername.Text;
                    string password = pwdbxPassword.Password.ToString();

                    var admin = dbobj.Users.SingleOrDefault(ad => ad.LoginId.Contains(username) && ad.Password.ToString().Contains(password));

                    if (admin == null)
                    {
                        sb.Append(Environment.NewLine + "Invalid Username and Password!");
                        throw new Exp(sb.ToString());
                    }
                    else
                    {

                        TravelAgentMainPage travelagentWindow = new TravelAgentMainPage();
                        //adminWindow.tbl_adminName.Text = " Hello " + admin.LoginId.ToString() + " ! ! ! ";
                        travelagentWindow.Show();
                        this.Close();
                    }
                }
                catch (Exception Exp)
                {
                    MessageBox.Show(Exp.Message);
                }
            }

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtUsername.Text = "";
            pwdbxPassword.Clear();
            txtUsername.Focus();
        }
    }
}

