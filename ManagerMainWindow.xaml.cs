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

namespace EmployeeTravelBookingWPF
{
    /// <summary>
    /// Interaction logic for ManagerMainWindow.xaml
    /// </summary>
    public partial class ManagerMainWindow : Window
    { 
    SprintdbEntities sprintdbEntities = new SprintdbEntities();
    public static DataGrid dataGrid, dataGrid1, dataGrid2, dataGrid3;

        public ManagerMainWindow()
        {
            InitializeComponent();
            Load();
        }

        public void Load()
        {
            grdHistory.ItemsSource = sprintdbEntities.TravelRequests.ToList();
            dataGrid3 = grdHistory;
            var loadRequest = from requst in sprintdbEntities.TravelRequests
                              where requst.CurrentStatus == "Pending" && requst.ManagerStatus == "-"
                              select requst;
            grdNewRequest.ItemsSource = loadRequest.ToList();
            dataGrid = grdNewRequest;
            var approveReq = from requst in sprintdbEntities.TravelRequests
                             where requst.ManagerStatus == "Approved"
                             select requst;
            grdApprovedRequest.ItemsSource = approveReq.ToList();
            dataGrid1 = grdApprovedRequest;
            var rejectedReq = from requst in sprintdbEntities.TravelRequests
                              where requst.ManagerStatus == "Rejected"
                              select requst;
            grdRejectedRequest.ItemsSource = rejectedReq.ToList();
            dataGrid2 = grdRejectedRequest;
        }

        public void ApproveRequest()
        {
            try
            {
                int id = (dataGrid.SelectedItem as TravelRequest).RequestId;

                var update = sprintdbEntities.TravelRequests.Where(x => x.RequestId == id).FirstOrDefault();
                if (update != null)
                {
                    update.ManagerStatus = "Approved";
                    sprintdbEntities.SaveChanges();
                    MessageBox.Show("You have been successfully approved request");
                    Load();
                }
                else
                {
                    MessageBox.Show($"{id} does not exist");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void RejectRequest()
        {
            try
            {
                int id = (dataGrid.SelectedItem as TravelRequest).RequestId;

                var update = sprintdbEntities.TravelRequests.Where(x => x.RequestId == id).FirstOrDefault();
                if (update != null)
                {
                    update.ManagerStatus = "Rejected";
                    sprintdbEntities.SaveChanges();
                    MessageBox.Show("You have been successfully reject the request");
                    Load();
                }
                else
                {
                    MessageBox.Show($"{id} does not exist");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnload_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }


        private void btnApprove_Click(object sender, RoutedEventArgs e)
        {
            ApproveRequest();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void btnReject_Click(object sender, RoutedEventArgs e)
        {
            RejectRequest();
        }

        private void btnApprove1_Click(object sender, RoutedEventArgs e)
        {
            ApproveRequest();
        }

        private void btnReject1_Click(object sender, RoutedEventArgs e)
        {
            RejectRequest();
        }
    }
}
