using EmployeeTravelBooking_BAL;
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

namespace EmployeeTravelBookingSystemWPF
{
    /// <summary>
    /// Interaction logic for View.xaml
    /// </summary>
    public partial class View : Page
    {
        public View()
        {
            InitializeComponent();
        }
        DataGrid datagrid = new DataGrid();
        private void gridloaded(object sender, RoutedEventArgs e)
        {

            EmpTravelBookingBAL balobj = new EmpTravelBookingBAL();

            grid.ItemsSource = balobj.GetTravelData(txtuseridbox.Text).DefaultView;
            datagrid = grid;

        }
        
    }
}
