using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace OnlineVehicleSystem
{
    /// <summary>
    /// Interaction logic for BookAVehicle.xaml
    /// </summary>
    public partial class BookAVehicle : Window
    {
        public int count;
        List<Vehicle> res = new List<Vehicle>();
        OVSEntities _context = new OVSEntities();

        public BookAVehicle()
        {
            InitializeComponent();

            res = _context.Vehicles.Include(v => v.Dealer)
                        .Where(v => v.TotalStock > 0).ToList();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {

            var search = txtSearch.Text;
            res = res
                .Where(r =>
                        r.VehicleName.ToUpper().Contains(search.ToUpper()) ||
                        r.VehicleModel.ToUpper().Contains(search.ToUpper()) ||
                        r.Dealer.CompanyName.ToUpper().Contains(search.ToUpper()) ||
                        r.Cost.ToString().Contains(search) ||
                        r.Rating.ToString().Contains(search))
                        .ToList();
            if (res.Count == 0)
                MessageBox.Show("No Result Found!");

            tb_noofresult.Text = res.Count.ToString() + " Results Found!";
            
        }


        public class Exec : ApplicationException

        {
            public Exec()
            {
            }

            public Exec(string message) : base(message)
            {
            }

            public Exec(string message, Exception innerException) : base(message, innerException)
            {
            }
        }


        private void Book_Click(object sender, RoutedEventArgs e)
        {
            using (OVSEntities _context = new OVSEntities())
            {
                StringBuilder sb = new StringBuilder();
                try
                {


                    if (cmbshowroom.Text == "")
                    {
                        sb.Append(Environment.NewLine + "Please select seller!");
                        throw new Exec(sb.ToString());
                    }

                    var customer = _context.Customers.SingleOrDefault(c => c.Email.ToString().Contains(tbl_adminName.Text));
                    var vehicle = _context.Vehicles.SingleOrDefault(v => v.VehicleID.ToString().Contains(tb_vehicleid.Text));
                    vehicle.TotalStock--;
                    Sale sale = new Sale
                    {
                        VehicleID = Convert.ToDecimal(tb_vehicleid.Text),
                        CustomerID = Convert.ToDecimal(customer.CustomerID),
                        ShowroomID = Convert.ToDecimal(cmbshowroom.SelectedValue),
                        Cost = vehicle.Cost,
                        OrderDate = DateTime.Now,
                        DeliveryDate = DateTime.Now.AddDays(7),
                        Remarks = "Sale Successfull"
                    };
                    _context.Sales.Add(sale);
                    _context.SaveChanges();
                    decimal Salesid = (from record in _context.Sales orderby record.SalesID descending select record.SalesID).First();
                    decimal showroomId = Convert.ToDecimal(cmbshowroom.SelectedValue);
                    Showroom showroom = _context.Showrooms.SingleOrDefault(s => s.ShowroomID == showroomId);

                    Bill bill = new Bill();
                    bill.YourName.Text = customer.CustomerName;
                    bill.Cost.Text = vehicle.Cost.ToString();
                    bill.YourAdress.Text = customer.Address;
                    bill.VehicleName.Text = vehicle.VehicleName;
                    bill.Postcode.Text = customer.Pincode.ToString();
                    bill.InvoiceNo.Text = Salesid.ToString();
                    bill.City.Text = customer.City;
                    bill.finalcost.Text = vehicle.Cost.ToString();
                    bill.Invoice.Text = showroom.Name;
                    bill.Show();


                }
                catch (Exception Exec)
                {
                    MessageBox.Show(Exec.Message);
                }
            }
        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            CustomerLoginControl customerLoginControl = new CustomerLoginControl();
            string message = tbl_adminName.Text.ToString();
            customerLoginControl.tbl_adminName.Text = message;
            customerLoginControl.Show();
            this.Close();


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Context Class name

            var result = (from t in res

                          select new { t.Image, t.VehicleName, t.VehicleModel, t.Cost, t.Description, t.Rating, t.VehicleID }).FirstOrDefault();

            Stream StreamObj = new MemoryStream(result.Image); //converting bytes to stream

            BitmapImage BitObj = new BitmapImage();

            BitObj.BeginInit();

            BitObj.StreamSource = StreamObj;

            BitObj.EndInit();

            this.Image.Source = BitObj;
            tb_cost.Text = "Rs." + result.Cost.ToString();
            tb_Description.Text = result.Description;
            tb_VehicleName.Text = result.VehicleName;
            tb_VehicleModel.Text = result.VehicleModel;
            tb_rating.Text = result.Rating.ToString();
            tb_vehicleid.Text = result.VehicleID.ToString();
            var vehicle = _context.Vehicles.FirstOrDefault(v => v.VehicleID.ToString().Contains(result.VehicleID.ToString()));
            cmbshowroom.ItemsSource = _context.Showrooms.Where(s => s.DealerID == vehicle.DealerID).ToList();
            cmbshowroom.DisplayMemberPath = "Name";
            cmbshowroom.SelectedValuePath = "ShowroomID";
        
        }

        private void DgDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CmbVehicle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (OVSEntities _context = new OVSEntities())
            {
                var vehicle = _context.Vehicles.SingleOrDefault(v => v.VehicleID.ToString().Contains(tb_vehicleid.Text));
                cmbshowroom.ItemsSource = _context.Showrooms.Where(s => s.DealerID == vehicle.DealerID).ToList();
                cmbshowroom.DisplayMemberPath = "Name";
                cmbshowroom.SelectedValuePath = "ShowroomID";
            }
        }
        //First
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Context Class name

            var result = (from t in res

                          select new { t.Image, t.VehicleName, t.VehicleModel, t.Cost, t.Description, t.Rating, t.VehicleID }).FirstOrDefault();

            Stream StreamObj = new MemoryStream(result.Image); //converting bytes to stream

            BitmapImage BitObj = new BitmapImage();

            BitObj.BeginInit();

            BitObj.StreamSource = StreamObj;

            BitObj.EndInit();

            this.Image.Source = BitObj;
            tb_cost.Text = "Rs." + result.Cost.ToString();
            tb_Description.Text = result.Description;
            tb_VehicleName.Text = result.VehicleName;
            tb_VehicleModel.Text = result.VehicleModel;
            tb_rating.Text = result.Rating.ToString();
            tb_vehicleid.Text = result.VehicleID.ToString();
            var vehicle = _context.Vehicles.SingleOrDefault(v => v.VehicleID.ToString().Equals(result.VehicleID.ToString()));
            cmbshowroom.ItemsSource = _context.Showrooms.Where(s => s.DealerID == vehicle.DealerID).ToList();
            cmbshowroom.DisplayMemberPath = "Name";
            cmbshowroom.SelectedValuePath = "ShowroomID";
        }

        private void Btn_next_Click(object sender, RoutedEventArgs e)
        {


            if (count < (res.Count() - 1))

            {

                count++;

                var result = res.OrderBy(t => t.VehicleID).Skip(count).FirstOrDefault();

                Stream StreamObj = new MemoryStream(result.Image);

                BitmapImage BitObj = new BitmapImage();

                BitObj.BeginInit();

                BitObj.StreamSource = StreamObj;

                BitObj.EndInit();

                this.Image.Source = BitObj;
                tb_cost.Text = "Rs." + result.Cost.ToString();
                tb_Description.Text = result.Description;
                tb_VehicleName.Text = result.VehicleName;
                tb_VehicleModel.Text = result.VehicleModel;
                tb_rating.Text = result.Rating.ToString();
                tb_vehicleid.Text = result.VehicleID.ToString();
                var vehicle = _context.Vehicles.SingleOrDefault(v => v.VehicleID.ToString().Contains(result.VehicleID.ToString()));
                cmbshowroom.ItemsSource = _context.Showrooms.Where(s => s.DealerID == vehicle.DealerID).ToList();
                cmbshowroom.DisplayMemberPath = "Name";
                cmbshowroom.SelectedValuePath = "ShowroomID";

            }

            else

            {

                var result = res.Select(c => c).FirstOrDefault();

                Stream StreamObj = new MemoryStream(result.Image);

                BitmapImage BitObj = new BitmapImage();

                BitObj.BeginInit();

                BitObj.StreamSource = StreamObj;

                BitObj.EndInit();

                this.Image.Source = BitObj;
                tb_cost.Text = "Rs." + result.Cost.ToString();
                tb_Description.Text = result.Description;
                tb_VehicleName.Text = result.VehicleName;
                tb_VehicleModel.Text = result.VehicleModel;
                tb_rating.Text = result.Rating.ToString();
                tb_vehicleid.Text = result.VehicleID.ToString();
                var vehicle = _context.Vehicles.FirstOrDefault(v => v.VehicleID.ToString().Contains(result.VehicleID.ToString()));
                cmbshowroom.ItemsSource = _context.Showrooms.Where(s => s.DealerID == vehicle.DealerID).ToList();
                cmbshowroom.DisplayMemberPath = "Name";
                cmbshowroom.SelectedValuePath = "ShowroomID";

                count = 0;

            }
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {


            count--;

            if (count < 0)

            {

                count = res.Count();

            }

            var result = res.OrderBy(t => t.VehicleID).Skip(count).Take(1);

            foreach (var s1 in result)

            {

                Stream StreamObj = new MemoryStream(s1.Image);

                BitmapImage BitObj = new BitmapImage();

                BitObj.BeginInit();

                BitObj.StreamSource = StreamObj;

                BitObj.EndInit();

                this.Image.Source = BitObj;
                tb_cost.Text = "Rs." + s1.Cost.ToString();
                tb_Description.Text = s1.Description;
                tb_VehicleName.Text = s1.VehicleName;
                tb_VehicleModel.Text = s1.VehicleModel;
                tb_rating.Text = s1.Rating.ToString();
                tb_vehicleid.Text = s1.VehicleID.ToString();
                var vehicle = _context.Vehicles.SingleOrDefault(v => v.VehicleID.ToString().Contains(s1.VehicleID.ToString()));
                cmbshowroom.ItemsSource = _context.Showrooms.Where(s => s.DealerID == vehicle.DealerID).ToList();
                cmbshowroom.DisplayMemberPath = "Name";
                cmbshowroom.SelectedValuePath = "ShowroomID";

            }

        }


        private void Last_Click(object sender, RoutedEventArgs e)
        {


            count = -1;

            var result = res.OrderByDescending(c => c.VehicleID).FirstOrDefault();



            Stream StreamObj = new MemoryStream(result.Image);

            BitmapImage BitObj = new BitmapImage();

            BitObj.BeginInit();

            BitObj.StreamSource = StreamObj;

            BitObj.EndInit();

            this.Image.Source = BitObj;
            tb_cost.Text = "Rs." + result.Cost.ToString();
            tb_Description.Text = result.Description;
            tb_VehicleName.Text = result.VehicleName;
            tb_VehicleModel.Text = result.VehicleModel;
            tb_rating.Text = result.Rating.ToString();
            tb_vehicleid.Text = result.VehicleID.ToString();
            var vehicle = _context.Vehicles.SingleOrDefault(v => v.VehicleID.ToString().Contains(result.VehicleID.ToString()));
            cmbshowroom.ItemsSource = _context.Showrooms.Where(s => s.DealerID == vehicle.DealerID).ToList();
            cmbshowroom.DisplayMemberPath = "Name";
            cmbshowroom.SelectedValuePath = "ShowroomID";
        }
        //reset
        private void BtnViewAll_Click(object sender, RoutedEventArgs e)
        {
            res = _context.Vehicles.Include(v => v.Dealer)
                        .Where(v => v.TotalStock > 0).ToList();
            tb_noofresult.Text = res.Count.ToString() + " Results Found!";
            txtSearch.Text = "";
            Stream StreamObj = new MemoryStream(res[0].Image); //converting bytes to stream

            BitmapImage BitObj = new BitmapImage();

            BitObj.BeginInit();

            BitObj.StreamSource = StreamObj;

            BitObj.EndInit();

            this.Image.Source = BitObj;
            tb_cost.Text = "Rs." + res[0].Cost.ToString();
            tb_Description.Text = res[0].Description;
            tb_VehicleName.Text = res[0].VehicleName;
            tb_VehicleModel.Text = res[0].VehicleModel;
            tb_rating.Text = res[0].Rating.ToString();
            tb_vehicleid.Text = res[0].VehicleID.ToString();
            var vehicle = _context.Vehicles.FirstOrDefault(v => v.VehicleID.ToString().Contains(tb_vehicleid.Text));
            cmbshowroom.ItemsSource = _context.Showrooms.Where(s => s.DealerID == vehicle.DealerID).ToList();
            cmbshowroom.DisplayMemberPath = "Name";
            cmbshowroom.SelectedValuePath = "ShowroomID";

        }
    }
}
