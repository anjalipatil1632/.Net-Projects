using EmployeeTravelBooking_BAL;
using EmployeeTravelBookingBAL;
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
    /// Interaction logic for ManagerMainWindow.xaml
    /// </summary>
    public partial class ManagerMainWindow : Window
    {
        EmpTravelBookingBAL balObject = new EmpTravelBookingBAL();
        DataGrid datagrid, datagrid1, datagrid2, datagrid3;
        public ManagerMainWindow()
        {
            InitializeComponent();
        }
        public void loadGrid()
        {
            grdNewRequest.ItemsSource = balObject.getNewRequest().DefaultView;
            datagrid = grdNewRequest;
            grdApprovedRequest.ItemsSource = balObject.getApproveRequest().DefaultView;
            datagrid1 = grdApprovedRequest;
            grdRejectedRequest.ItemsSource = balObject.getRejectRequest().DefaultView;
            datagrid2 = grdRejectedRequest;
            grdHistory.ItemsSource = balObject.getHistoryRequests().DefaultView;
            datagrid3 = grdHistory;

            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadGrid();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow welcomepage = new MainWindow();
            welcomepage.Show();
            this.Close();
        }

        private void btnApprove_Click(object sender, RoutedEventArgs e)
        {



        }

        private void btnApprove1_Click(object sender, RoutedEventArgs e)
        {

            DataRowView datarow = (DataRowView)datagrid.SelectedItems[0];
            int id = (int)datarow.Row["RequestId"];
            if (id != null)
            {
                balObject.approveNewRequest(id);
                MessageBox.Show("Request is approved");
                loadGrid();
            }
            else
            {
                MessageBox.Show("Request is not approved");
            }
        }

        private void btnReject1_Click(object sender, RoutedEventArgs e)
        {
            
            DataRowView datarow = (DataRowView)datagrid.SelectedItems[0];
            int id = (int)datarow.Row["RequestId"];
            if (id != null)
            {
                balObject.rejectRequest(id);              
                MessageBox.Show("Request is rejected");

                loadGrid();
            }
            else
            {
                MessageBox.Show("Request is not rejected");
            }
        }
    }
}
