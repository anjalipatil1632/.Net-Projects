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
    /// Interaction logic for AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        public AdminMainWindow()
        {
            InitializeComponent();
        }

        private void EmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeOperationWindow employee = new EmployeeOperationWindow();          
            employee.Show();
            this.Close();
        }

        private void ManagerButton_Click(object sender, RoutedEventArgs e)
        {
            ManagerOperationWIndow manager = new ManagerOperationWIndow();          
            manager.Show();
            this.Close();
        }

        private void TravelAgentButton_Click(object sender, RoutedEventArgs e)
        {
            TravelAgentOperationWindow travelAgent = new TravelAgentOperationWindow();           
            travelAgent.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ob = new MainWindow();
            ob.Show();
            this.Close();
        }
    }
}
