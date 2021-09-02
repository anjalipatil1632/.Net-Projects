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

namespace OnlineVehicleSystem
{
    /// <summary>
    /// Interaction logic for CustomerLoginSignup.xaml
    /// </summary>
    public partial class CustomerLoginSignup : Window
    {
        public CustomerLoginSignup()
        {
            InitializeComponent();
        }
        public class Exec : ApplicationException

        {
            public Exec()
            {
            }

            public Exec(string message) : base(message)
            {
            }

            public Exec(string message, Exception innerException) : base(message, innerException)
            {
            }
        }

        private void Btn_loginButton_Click(object sender, RoutedEventArgs e)
        {
            using (OVSEntities _context = new OVSEntities())
            {


                StringBuilder sb = new StringBuilder();
                try
                {
                    if (txt_loginCustId.Text == "")
                    {
                        sb.Append(Environment.NewLine + "Email Shouldn't be blank!");
                        throw new Exec(sb.ToString());


                    }
                    if (pwd_password.Password == "")
                    {
                        sb.Append(Environment.NewLine + "Password Shouldn't be blank!");
                        throw new Exec(sb.ToString());
                    }
                    string email = txt_loginCustId.Text;
                    string password = pwd_password.Password.ToString();
           
                var customer = _context.Customers.SingleOrDefault(c => c.Email.Contains(email) && c.ContactNo.ToString().Contains(password));

                if (customer == null)
                {
                    sb.Append(Environment.NewLine + "Invalid Username and Password!");
                    throw new Exec(sb.ToString());
                }
                else
                {
                        CustomerLoginControl customerLoginControl = new CustomerLoginControl();
                        customerLoginControl.tbl_adminName.Text = customer.Email;
                        customerLoginControl.Show();
                        this.Close();
                }

                


            }
                catch (Exception Exec)
            {
                MessageBox.Show(Exec.Message);
            }
        }

        }

        

        private void Btn_linkToRegister1_Click_1(object sender, RoutedEventArgs e)
        {
            CustomerRegistration customerRegistration = new CustomerRegistration();
            customerRegistration.Show();
            this.Close();
        }
    }
}
