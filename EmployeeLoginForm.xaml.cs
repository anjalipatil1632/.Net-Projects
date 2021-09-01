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
    /// Interaction logic for EmployeeLoginForm.xaml
    /// </summary>
    public partial class EmployeeLoginForm : Window
    {
        public EmployeeLoginForm()
        {
            InitializeComponent();
        }
        SprintdbEntities entityobj = new SprintdbEntities();

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                if (txtUsername.Text == "")
                {
                    MessageBox.Show("Username//LoginID Shouldn't be blank!");
                    


                }
                if (pwdbxPassword.Password == "")
                {
                    MessageBox.Show("Password Shouldn't be blank!");
                   
                }
                string loginid = txtUsername.Text;
                string password = pwdbxPassword.Password.ToString();

                var emp = entityobj.Users.SingleOrDefault(c => c.LoginId.Contains(loginid) && c.Password.ToString().Contains(password));

                if (emp == null)
                {
                    MessageBox.Show("Invalid Username and Password!");
                    
                }
                else
                {
                    //MessageBox.Show("Welcome");
                    EmployeeMainWindow empwindow = new EmployeeMainWindow();
                    empwindow.txtuser.Text =emp.LoginId.ToString() + " ! ";
                    
                    empwindow.Show();
                    this.Close();
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
