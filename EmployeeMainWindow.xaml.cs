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
    /// Interaction logic for EmployeeMainWindow.xaml
    /// </summary>
    public partial class EmployeeMainWindow : Window
    {
        public EmployeeMainWindow()
        {
            InitializeComponent();
        }

        private void btncheckstatus_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new View();

        }

        private void btnraisenewticket_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new AddPage();
        }

        private void btncancelticket_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new CancelPage();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow welcomepage = new MainWindow();
            welcomepage.Show();
            this.Close();
        }

        private void txtuser_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        //private void Main_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        //{
        //    (e.Content as View).Tag = this;
        //}
        //public string getdata()
        //{
        //    string loginid = txtuser.Text;
        //    return loginid;
         
        //}
    }
}
