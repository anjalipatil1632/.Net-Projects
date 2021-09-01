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
    /// Interaction logic for ManagerOperationWIndow.xaml
    /// </summary>
    public partial class ManagerOperationWIndow : Window
    {
        Users users_obj = new Users();
        EmpTravelBookingBAL bal_obj = new EmpTravelBookingBAL();
        public ManagerOperationWIndow()
        {
            InitializeComponent();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            AdminMainWindow admin = new AdminMainWindow();
            this.Visibility = Visibility.Hidden;
            admin.Show();
        }

        private void AssignButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int rowaffected = 0;
                users_obj.UserId = Convert.ToInt32(txtuserid.Text);
                users_obj.ManagerUserId = Convert.ToInt32(txtmanagerid.Text);

                rowaffected = bal_obj.assignManager(users_obj);
                if (rowaffected == 1)
                {
                    MessageBox.Show("Manager Assigned successfully!");
                    txtuserid.Clear();
                    txtuserid.Clear();
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

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int rowaffected = 0;
                users_obj.UserId = Convert.ToInt32(txtuserid.Text);
                users_obj.ManagerUserId = Convert.ToInt32(txtmanagerid.Text);

                rowaffected = bal_obj.changeManager(users_obj);
                if (rowaffected == 1)
                {
                    MessageBox.Show("Manager changed successfully!");
                    txtuserid.Clear();
                    txtuserid.Clear();
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
            ManagerDetails managerDetails = new ManagerDetails();
            this.Visibility = Visibility.Hidden;
            managerDetails.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnlyEmployeeDetails EmpDetails = new OnlyEmployeeDetails();
            this.Visibility = Visibility.Hidden;
            EmpDetails.Show();
        }
    }
}
