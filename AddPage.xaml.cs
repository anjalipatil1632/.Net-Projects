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

namespace EmployeeTravelBookingWPF
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
        SprintdbEntities entityobj = new SprintdbEntities();
        public void Clear()
        {
            txtfromLocation.Text = "";
            txttolocation.Text = "";
            combomedium.Text = "";
            txtuserid.Text = "";
        }

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
                else
                {
                    TravelRequest travelRequest = new TravelRequest
                    {
                        RequestDate = DateTime.Now,
                        FromLocation = txtfromLocation.Text,
                        ToLocation = txttolocation.Text,
                        Medium = combomedium.Text,
                        UserId = Convert.ToInt32(txtuserid.Text),
                        CurrentStatus = "Pending",
                        ManagerStatus = "-"

                    };
                    var check = entityobj.Users.SingleOrDefault(c => c.UserId.ToString().Contains(txtuserid.Text));
                    if (check == null)
                    {
                        MessageBox.Show("Wrong UserID \n Enter Correct UserID");
                    }
                    else
                    {
                        entityobj.TravelRequests.Add(travelRequest);
                        entityobj.SaveChanges();
                        MessageBox.Show("Travel Ticket Has Been Raised Successfully OR \nCheck Your Status in <Check Status> Option");
                        Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txttolocation_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
