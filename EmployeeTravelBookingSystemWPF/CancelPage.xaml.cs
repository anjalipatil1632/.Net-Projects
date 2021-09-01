using EmployeeTravelBooking_BAL;
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
    /// Interaction logic for CancelPage.xaml
    /// </summary>
    public partial class CancelPage : Page
    {
        public CancelPage()
        {
            InitializeComponent();
        }

        private void btncancel_Click(object sender, RoutedEventArgs e)
        {
            EmpTravelBookingBAL obj = new EmpTravelBookingBAL();
            int requestid = Convert.ToInt32(txtrequestbox.Text);
            int rowaffected = obj.CancelBookingRequest(requestid);
            if(rowaffected==1)
            {
                MessageBox.Show("Ticket has been canceled Successfully");
            }
            else
            {
                MessageBox.Show("Cancelation of tickect failed! ");
            }
            txtrequestbox.Clear();

        }

        private void txtrequestbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
    }
}
