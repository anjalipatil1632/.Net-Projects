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
    /// Interaction logic for OnlyEmployeeDetails.xaml
    /// </summary>
    public partial class OnlyEmployeeDetails : Window
    {
        Users users_obj = new Users();
        EmpTravelBookingBAL bal_obj = new EmpTravelBookingBAL();
        public static DataGrid dataGrid;
        public OnlyEmployeeDetails()
        {
            InitializeComponent();
            loaddetails();


        }
        public void loaddetails()
        {
            dg_result.ItemsSource = bal_obj.getEmployeeDetailsOnly().DefaultView;
            dataGrid = dg_result;
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ManagerOperationWIndow employee = new ManagerOperationWIndow();
            this.Visibility = Visibility.Hidden;
            employee.Show();
        }

        
    }
}
