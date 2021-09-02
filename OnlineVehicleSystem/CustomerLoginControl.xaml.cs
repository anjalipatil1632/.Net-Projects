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

namespace OnlineVehicleSystem
{
    /// <summary>
    /// Interaction logic for CustomerLoginControl.xaml
    /// </summary>
    public partial class CustomerLoginControl : Window
    {
        public CustomerLoginControl()
        {
            InitializeComponent();
        }

        private void Btn_BookAVehicle_Click(object sender, RoutedEventArgs e)
        {
            BookAVehicle bookAVehicle = new BookAVehicle();
            bookAVehicle.Show();
            string message = tbl_adminName.Text;
            bookAVehicle.tbl_adminName.Text = message;
            this.Close();
        }

        private void Btn_PurchaseDetails_Click(object sender, RoutedEventArgs e)
        {
            PurchaseDetails purchaseDetails = new PurchaseDetails();
            purchaseDetails.tbl_adminName.Text = tbl_adminName.Text;
            purchaseDetails.Show();
            this.Close();
        }

        private void Btn_EditVehicle_Click(object sender, RoutedEventArgs e)
        {
            CustomerRegistration customerRegistration = new CustomerRegistration();
            customerRegistration.tbl_adminName.Text = tbl_adminName.Text;
            customerRegistration.Show();
            this.Close();
        }

        private void Btn_logout_Click(object sender, RoutedEventArgs e)
        {
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Show();
            this.Close();
        }
    }
}
