using EmployeeTravelBooking_BAL;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for TravelAgentMainWindow.xaml
    /// </summary>
    public partial class TravelAgentMainWindow : Window
    {
        EmpTravelBookingBAL balObject = new EmpTravelBookingBAL();
        DataGrid datagrid, datagrid1;
        int i = 10;
        public TravelAgentMainWindow()
        {
            InitializeComponent();
            Load();
            ticketCount();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load();

        }

        public void Load()
        {
            grdApprovedRequest.ItemsSource = balObject.usp_TravelRequests().DefaultView;
            datagrid = grdApprovedRequest;
            grdConfirmedRequest.ItemsSource = balObject.getConfirmedTickets().DefaultView;
            datagrid1 = grdConfirmedRequest;
        }
        private void grdApprovedRequest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnConfirmed_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView datarow = (DataRowView)datagrid.SelectedItems[0];
                int id = (int)datarow.Row["RequestId"];
                //var update= datarow.Row["RequestId"];
                if (id != null)
                {
                    balObject.confirmed(id);
                    MessageBox.Show("Booking Confirmed");
                    Load();
                    txtno.Text = ticketCount().ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select proper row ");
            }


        }

        private void btnNotAvailable_Click(object sender, RoutedEventArgs e)
        {
            DataRowView datarow = (DataRowView)datagrid.SelectedItems[0];
            int id = (int)datarow.Row["RequestId"];
            if (id != null)
            {
                balObject.notAvailable(id);
                MessageBox.Show("Ticket Not Available");
                Load();
                //txtno.Text =(ticketCount()+1).ToString();
            }
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow welcomepage = new MainWindow();
            welcomepage.Show();
            this.Close();
        }

        public int ticketCount()
        {
            int count = balObject.getTicketCounts();
            i = 10 - count;
            txtno.Text = i.ToString();
            return i;
        }
    }
}

