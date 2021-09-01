using EmployeeTravelBooking_BAL;
using EmployeeTravelBooking_Exceptions;
using EmployeeTravelBookingBAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace EmployeeTravelBookingSystemWPF
{
    /// <summary>
    /// Interaction logic for AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        public AddPage()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            txtfromLocation.Text = "";
            txttolocation.Text = "";
            combomedium.Text = "";          
        }
        EmpTravelBookingBAL balobj = new EmpTravelBookingBAL();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtfromLocation.Text == "")
                {
                    MessageBox.Show("From Location Shouldn't be blank!");

                }
                if (txttolocation.Text == "")
                {
                    MessageBox.Show("To Location Shouldn't be blank!");

                }
                if (combomedium.Text == "")
                {
                    MessageBox.Show("Travel Medium Shouldn't be blank!");

                }
                if (txtuserid.Text == "")
                {
                    MessageBox.Show("User ID Shouldn't be blank!");

                }
                if (txtfromdate.Text == "")
                {
                    MessageBox.Show("From Date Shouldn't be blank!");

                }
                if (txttodte.Text == "")
                {
                    MessageBox.Show("To Date Shouldn't be blank!");

                }

                else
                {
                    try
                    {
                        TravelRequests obj = new TravelRequests();
                        int rowaffected = 0;
                        obj.RequestDate = DateTime.Now;
                        obj.FromLocation =txtfromLocation.Text;
                        obj.ToLocation = txttolocation.Text;
                        obj.FromDate = Convert.ToDateTime(txtfromdate.Text);
                        obj.ToDate = Convert.ToDateTime(txttodte.Text);
                        obj.Medium = combomedium.Text;
                        obj.UserId = Convert.ToInt32(txtuserid.Text.ToString());
                        obj.CurrentStatus = "Pending";
                        obj.ManagerStatus = "-";

                        rowaffected= balobj.AddRequest(obj);
                        if (rowaffected==1)
                        {
                            MessageBox.Show("Your Travel Request has been raised Successfully");
                           
                        }
                        else
                            MessageBox.Show("Error Occured !");


                    }
                    catch (Exceptionss ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txtfromLocation.Text = "";
            txttolocation.Text = "";
            combomedium.Text = "";
        }

        private void txtfromLocation_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^a-zA-Z]").IsMatch(e.Text);
        }

        private void txttolocation_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^a-zA-Z]").IsMatch(e.Text);
        }

        private void txtuserid_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
    }
}
