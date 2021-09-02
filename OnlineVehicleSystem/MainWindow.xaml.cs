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

namespace OnlineVehicleSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
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

        private void Btn_Login_Click(object sender, RoutedEventArgs e)
        {
           
            StringBuilder sb = new StringBuilder();
            try
            {
                if (txt_ShowroomId.Text == "")
                {
                     sb.Append(Environment.NewLine + "Username Shouldn't be blank!");
                    throw new Exec(sb.ToString());


                }
                if (pwd_field.Password == "")
                {
                    sb.Append(Environment.NewLine + "Password Shouldn't be blank!");
                    throw new Exec(sb.ToString());
                }
                if(txt_ShowroomId.Text == "admin@vehiclehub.com" && pwd_field.Password == "Showroom@123")
                {
                    AdminLoginControl adminLoginControl = new AdminLoginControl();
                    adminLoginControl.txtblock_name.Text = "Admin";
                    adminLoginControl.Show();
                    this.Close();
                }
                else
                {
                    sb.Append(Environment.NewLine + "Invalid Username and Password!");
                    throw new Exec(sb.ToString());

                }


            }
            catch(Exception Exec)
            {
                MessageBox.Show(Exec.Message);
            }
            
        }
    }
}
