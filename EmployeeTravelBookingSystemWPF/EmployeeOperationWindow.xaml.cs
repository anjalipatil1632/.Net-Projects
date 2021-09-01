using EmployeeTravelBooking_BAL;
using EmployeeTravelBookingBAL;
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
    /// Interaction logic for EmployeeOperationWindow.xaml
    /// </summary>
    public partial class EmployeeOperationWindow : Window
    {
        Users users_obj = new Users();
        EmpTravelBookingBAL bal_obj = new EmpTravelBookingBAL();
        public EmployeeOperationWindow()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            AdminMainWindow admin = new AdminMainWindow();
            this.Visibility = Visibility.Hidden;
            admin.Show();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int rowaffected = 0;
                users_obj.LoginId = txtlogin.Text;
                users_obj.Password = txtpassword.Password;
                users_obj.UserTypeId = Convert.ToInt32(comboemptype.Text);
                users_obj.Name = txtname.Text;
                users_obj.ManagerUserId = 0;

                rowaffected = bal_obj.insertUsers(users_obj);
                if (rowaffected == 1)
                {
                    MessageBox.Show("Values inserted successfully!");
                    txtlogin.Clear();
                    txtname.Clear();
                    txtpassword.Clear();

                }
                else
                {
                    MessageBox.Show("Error occured!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDetails employeeDetails = new EmployeeDetails();
            this.Visibility = Visibility.Hidden;
            employeeDetails.Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
