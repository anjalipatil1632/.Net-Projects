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
    /// Interaction logic for UpdateTravelAgent.xaml
    /// </summary>
    public partial class UpdateTravelAgent : Window
    {
        Users users_obj = new Users();
        EmpTravelBookingBAL bal_obj = new EmpTravelBookingBAL();
        public UpdateTravelAgent()
        {
            InitializeComponent();
        }
        private void btnUpdateLoginid_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int rowaffected = 0;
                users_obj.UserId = Convert.ToInt32(txtuserid1.Text);
                users_obj.LoginId = txtloginid.Text;

                rowaffected = bal_obj.updateLoginId(users_obj);
                if (rowaffected == 1)
                {
                    MessageBox.Show("LoginId updated successfully!");
                    txtuserid1.Clear();
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

        private void btnUpdatePassword_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int rowaffected = 0;
                users_obj.UserId = Convert.ToInt32(txtuserid2.Text);
                users_obj.Password = txtpassword.Text;

                rowaffected = bal_obj.updatePassword(users_obj);
                if (rowaffected == 1)
                {
                    MessageBox.Show("Password updated successfully!");
                    txtuserid2.Clear();
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

        private void btnUpdateName_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int rowaffected = 0;
                users_obj.UserId = Convert.ToInt32(txtuserid3.Text);
                users_obj.Name = txtname.Text;

                rowaffected = bal_obj.updateName(users_obj);
                if (rowaffected == 1)
                {
                    MessageBox.Show("Name updated successfully!");
                    txtuserid3.Clear();
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

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            TravelAgentMainWindow travelAgent = new TravelAgentMainWindow();
            this.Visibility = Visibility.Hidden;
            travelAgent.Show();
        }
    }
}
