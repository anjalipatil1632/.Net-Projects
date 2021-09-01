using EmployeeTravelBooking_BAL;
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

namespace EmployeeTravelBookingSystemWPF
{
    /// <summary>
    /// Interaction logic for AdminLoginForm.xaml
    /// </summary>
    public partial class AdminLoginForm : Window
    {
        public AdminLoginForm()
        {
            InitializeComponent();
        }
        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (txtUsername.Text == "")
                {
                    MessageBox.Show("Username//LoginID Shouldn't be blank!");



                }
                else if (pwdbxPassword.Password == "")
                {
                    MessageBox.Show("Password Shouldn't be blank!");

                }
                else if (pwdbxPassword.Password.Length < 8)
                {
                    MessageBox.Show("Invalid Password !");

                }
                else
                {
                    string loginid = txtUsername.Text;
                    string password = pwdbxPassword.Password.ToString();

                    EmpTravelBookingBAL obj = new EmpTravelBookingBAL();
                    int emp = obj.Adminloginformcheck(loginid, password);

                    if (emp == 1)
                    {

                        AdminMainWindow empwindow = new AdminMainWindow();
                        //empwindow.txtuser.Text = loginid;

                        empwindow.Show();
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Invalid Username and Password!");
                    }
                }
                


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnreset_Click(object sender, RoutedEventArgs e)
        {
            txtUsername.Clear();
            pwdbxPassword.Clear();
            txtUsername.Focus();
        }

        private void btnexit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow welcomepage = new MainWindow();
            welcomepage.Show();
            this.Close();
        }
    }
}
