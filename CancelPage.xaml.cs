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
    /// Interaction logic for CancelPage.xaml
    /// </summary>
    public partial class CancelPage : Page
    {
        public CancelPage()
        {
            InitializeComponent();
        }
        SprintdbEntities entityobj = new SprintdbEntities();
        public void Clear()
        {
            txtrequestbox.Text = "";
           
        }
        private void btncancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtrequestbox.Text == "")
                {
                    MessageBox.Show("RequestID Shouldn't be blank!");

                }

                else
                {
                    int id = Convert.ToInt32(txtrequestbox.Text);
                    TravelRequest travelRequest = entityobj.TravelRequests.First(i => i.RequestId == id);
                    if (travelRequest == null)
                    {
                        MessageBox.Show("Request ID is wrong OR\nYou have not raised any travel ticket");

                    }
                    else
                    {
                        entityobj.TravelRequests.Remove(travelRequest);
                        entityobj.SaveChanges();
                        MessageBox.Show("Travel Ticket Has Been Canceled Successfully");
                        Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
