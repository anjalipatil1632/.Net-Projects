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

            View ob = new View();
            Main.Content = ob;
            ob.txtuseridbox.Text =txtuser.Text;

        }

        private void btnraisenewticket_Click(object sender, RoutedEventArgs e)
        {
            AddPage ob = new AddPage();
            Main.Content = ob;
            ob.txtloginid.Text = txtuser.Text;
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
    }
}
