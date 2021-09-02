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
    /// Interaction logic for ViewSale.xaml
    /// </summary>
    public partial class ViewSale : Window
    {
        public ViewSale()
        {
            InitializeComponent();
        }

        private void DgDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnViewAll_Click(object sender, RoutedEventArgs e)
        {
            using (OVSEntities _context = new OVSEntities())
            {

               


                dgDetails.ItemsSource = _context.Sales.Include(S => S.Showroom)
                        .Include(S => S.Vehicle)
                        .Include(S => S.Customer)
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

        private void BtnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            AdminLoginControl adminLoginControl = new AdminLoginControl();
            adminLoginControl.Show();
            this.Close();
        }

        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using(OVSEntities _context=new OVSEntities())
            {
               
                cmb_showroom.ItemsSource = _context.Showrooms.ToList();
                cmb_showroom.DisplayMemberPath = "Name";
                cmb_showroom.SelectedValuePath = "ShowroomID";


                dgDetails.ItemsSource = _context.Sales.Include(S => S.Showroom)
                        .Include(S => S.Vehicle)
                        .Include(S => S.Customer)
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

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            using (OVSEntities _context = new OVSEntities())
            {

                try
                {
                    dgDetails.ItemsSource = (_context.Sales
                        .Include(S => S.Showroom)
                        .Include(S => S.Vehicle)
                        .Include(S => S.Customer)
                        .Where(S => S.ShowroomID.ToString()==(cmb_showroom.SelectedValue.ToString()))
                        .Select(S => new {
                            S.SalesID,
                            S.Vehicle.VehicleName,
                            S.Showroom.Name,
                            S.Customer.CustomerName,
                            S.Cost,
                            S.OrderDate,
                            S.DeliveryDate,
                            S.Remarks
                        })).ToList();
                }
                catch (Exception)
                {

                }




            }
        }
    }
}
