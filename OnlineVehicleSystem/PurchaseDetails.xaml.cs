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
using System.Data.Entity;

namespace OnlineVehicleSystem
{
    /// <summary>
    /// Interaction logic for PurchaseDetails.xaml
    /// </summary>
    public partial class PurchaseDetails : Window
    {
        public PurchaseDetails()
        {
            InitializeComponent();
        }

        private void DgDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            CustomerLoginControl customerLoginControl = new CustomerLoginControl();
            customerLoginControl.tbl_adminName.Text = tbl_adminName.Text;
            customerLoginControl.Show();
            this.Close();

        }

        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (OVSEntities _context = new OVSEntities())
            {




                dgDetails.ItemsSource = _context.Sales.Include(S => S.Showroom)
                        .Include(S => S.Vehicle)
                        .Include(S => S.Customer)
                        .Where(S=>S.Customer.Email.Contains(tbl_adminName.Text))
                        .Select(S => new {
                            S.SalesID,
                            S.Vehicle.VehicleName,
                            S.Showroom.Name,
                            S.Customer.CustomerName,
                            S.Cost,
                            S.OrderDate,
                            S.DeliveryDate,
                            S.Remarks
                        }).ToList();

            }

        }
    }
}
