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
    /// Interaction logic for ManagerDetails.xaml
    /// </summary>
    public partial class ManagerDetails : Window
    {
        Users users_obj = new Users();
        EmpTravelBookingBAL bal_obj = new EmpTravelBookingBAL();
        public static DataGrid dataGrid;

        public ManagerDetails()
        {
            InitializeComponent();
            loaddetails();
        }
        public void loaddetails()
        {
            dg_result.ItemsSource = bal_obj.getManager().DefaultView;
            dataGrid = dg_result;
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ManagerOperationWIndow manager = new ManagerOperationWIndow();
            this.Visibility = Visibility.Hidden;
            manager.Show();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)dataGrid.SelectedItems[0];
            int id = (int)dataRow.Row["UserId"];
            if (id != null)
            {
                bal_obj.deleteTravelAgent(id);
                MessageBox.Show("Values deleted successfully");
                loaddetails();
            }
            else
            {
                MessageBox.Show("Error Occured");
            }
        }
    }
}
