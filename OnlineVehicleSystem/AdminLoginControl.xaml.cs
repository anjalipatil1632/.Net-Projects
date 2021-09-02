using System.Windows;

namespace OnlineVehicleSystem
{
    /// <summary>
    /// Interaction logic for AdminLoginControl.xaml
    /// </summary>
    public partial class AdminLoginControl : Window
    {
        public AdminLoginControl()
        {
            InitializeComponent();
        }

        private void Btn_AddDealer_Click(object sender, RoutedEventArgs e)
        {
            AddDealer addDealer = new AddDealer();
            addDealer.Show();
            this.Close();

        }

        private void Btn_EditShowroom_Click(object sender, RoutedEventArgs e)
        {
            ShowroomControl showroomWindow = new ShowroomControl();
            showroomWindow.Show();
            this.Close();

        }

        private void Btn_viewSales_Click(object sender, RoutedEventArgs e)
        {
            ViewSale viewSale = new ViewSale();
            viewSale.Show();
            this.Close();

        }

        private void Btn_ViewCustomerDetails_Click(object sender, RoutedEventArgs e)
        {
            DealerGrid dealerGrid = new DealerGrid();
            dealerGrid.Show();
            this.Close();
        }

        private void Btn_EditVehicle_Click(object sender, RoutedEventArgs e)
        {
            VehicleControl vehicleControl = new VehicleControl();
            vehicleControl.Show();
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
