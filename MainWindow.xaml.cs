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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btnemployees_Click(object sender, RoutedEventArgs e)
        {
            EmployeeLoginForm emploginform = new EmployeeLoginForm();
            emploginform.Show();
            this.Close();
        }

        private void btnmanager_Click(object sender, RoutedEventArgs e)
        {
            ManagerLoginForm managerloginform = new ManagerLoginForm();
            managerloginform.Show();
            this.Close();
        }

        private void btntravelagent_Click(object sender, RoutedEventArgs e)
        {
            TravelLoginForm travelagentloginform = new TravelLoginForm();
            travelagentloginform.Show();
            this.Close();
        }

        private void btnadmin_Click(object sender, RoutedEventArgs e)
        {
            AdminLoginForm adminloginform = new AdminLoginForm();
            adminloginform.Show();
            this.Close();
        }
    }
}
