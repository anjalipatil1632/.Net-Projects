using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace OnlineVehicleSystem
{
    /// <summary>
    /// Interaction logic for DealerGrid.xaml
    /// </summary>
    public partial class DealerGrid : Window
    {
        public DealerGrid()
        {
            InitializeComponent();
        }



        private void BtnViewAll_Click(object sender, RoutedEventArgs e)
        {
            using (OVSEntities _context = new OVSEntities())
            {
                dgDetails.ItemsSource = _context.stpGetAllCustomer();
            }
        }

        //private void BtnSearch_Click(object sender, RoutedEventArgs e)
        //{
        //    using (OVSEntities _context = new OVSEntities())
        //    {
        //        string search = txtSearch.Text;
        //        List<Customer> SearchRes = _context.Customers .Where(d=>
        //                          d.CustomerName.ToUpper().Contains(search.ToUpper()) ||
        //                         d.ContactNo.ToString().Contains(search) ||
        //                         d.Email.ToString().ToUpper().Contains(search.ToUpper()) ||
        //                         d.Gender.ToUpper().Contains(search.ToUpper()) ||
        //                         d.City.ToUpper().Contains(search.ToUpper()) ||
        //                         d.State.ToUpper().Contains(search.ToUpper()) ||
        //                         d.Pincode.ToString().Contains(search)
        //                         ).ToList();
        //        dgDetails.ItemsSource = SearchRes;
        //    }
        //}

        private void BtnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            AdminLoginControl adminLoginControl = new AdminLoginControl();
            adminLoginControl.Show();
            this.Close();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            AdminLoginControl adminLoginControl = new AdminLoginControl();

            adminLoginControl.Show();
            this.Close();
        }

        private void DgDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (OVSEntities _context = new OVSEntities())
            {
                dgDetails.ItemsSource = _context.stpGetAllCustomer();
            }
        }
    }
}
