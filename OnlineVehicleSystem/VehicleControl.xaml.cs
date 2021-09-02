using Microsoft.Win32;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace OnlineVehicleSystem
{
    /// <summary>
    /// Interaction logic for VehicleControl.xaml
    /// </summary>
    public partial class VehicleControl : Window
    {
        public VehicleControl()
        {
            InitializeComponent();
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
        public void Reset()
        {
            txtVehicleName.Text = "";
            cmbDealerName.Text = "";
            txtVehicleModel.Text = "";
            txtTotalStock.Text = "";
            txtRating.Text = "";
            txtImage.Text = "";
            txtDescription.Text = "";
            txtCost.Text = "";
            txtSearch.Text = "";
            
        }
        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {

            using (OVSEntities _context = new OVSEntities())
            {
                StringBuilder sb = new StringBuilder();

                try
                {

                    if (cmbDealerName.Text == "")
                    {

                        sb.Append(Environment.NewLine + "Please select dealer!");
                        throw new Exec(sb.ToString());
                    }

                    if (txtImage.Text == "")
                    {
                        sb.Append(Environment.NewLine + " Please select the Image!");
                        throw new Exec(sb.ToString());
                    }


                    if (txtVehicleName.Text == "")
                    {
                        sb.Append(Environment.NewLine + " Vehicle Name Cannot be empty!");
                        throw new Exec(sb.ToString());
                    }
                    if (txtVehicleModel.Text == "")
                    {
                        sb.Append(Environment.NewLine + " Vehicle Model Cannot be empty!");
                        throw new Exec(sb.ToString());
                    }
                    if (txtDescription.Text == "")
                    {
                        sb.Append(Environment.NewLine + " Description Cannot be empty!");
                        throw new Exec(sb.ToString());
                    }
                    if (txtCost.Text == "")
                    {
                        sb.Append(Environment.NewLine + "Cost Cannot be empty!");
                        throw new Exec(sb.ToString());
                    }
                    if (txtTotalStock.Text == "")
                    {
                        sb.Append(Environment.NewLine + "Total Stock Cannot be empty!");
                        throw new Exec(sb.ToString());
                    }
                    if (txtRating.Text == "")
                    {
                        sb.Append(Environment.NewLine + "Rating Cannot be empty!");
                        throw new Exec(sb.ToString());
                    }
                    if (!Regex.IsMatch(txtCost.Text, "^\\d+$"))
                    {
                        sb.Append(Environment.NewLine + "Invalid Input!");
                        txtCost.Text = "";
                        throw new Exec(sb.ToString());
                    }
                    if (!Regex.IsMatch(txtTotalStock.Text, "^\\d+$"))
                    {
                        sb.Append(Environment.NewLine + "Invalid Input!");
                        txtTotalStock.Text = "";
                        throw new Exec(sb.ToString());
                    }
                    if (!Regex.IsMatch(txtRating.Text, "^\\d+$"))
                    {
                        sb.Append(Environment.NewLine + "Invalid Input!");
                        txtRating.Text = "";
                        throw new Exec(sb.ToString());
                    }
                    Vehicle vehicle = new Vehicle
                    {
                        VehicleName = txtVehicleName.Text,
                        VehicleModel = txtVehicleModel.Text,
                        DealerID = Convert.ToDecimal(cmbDealerName.SelectedValue),
                        Image = File.ReadAllBytes(txtImage.Text),
                        Cost = Convert.ToDecimal(txtCost.Text),
                        TotalStock = Convert.ToDecimal(txtTotalStock.Text),
                        Description = txtDescription.Text,
                        Rating = Convert.ToDecimal(txtRating.Text)

                    };
                    _context.Vehicles.Add(vehicle);
                    _context.SaveChanges();
                    MessageBox.Show("Successfully Added!");
                    Reset();
                }
                catch (Exception Exec)
                {
                    MessageBox.Show(Exec.Message);
                }
            }
        }
        private void BtnModify_Click(object sender, RoutedEventArgs e)
        {
            using (OVSEntities _context = new OVSEntities())
            {
                StringBuilder sb = new StringBuilder();

                try
                {

                    if (cmbDealerName.Text == "")
                    {

                        sb.Append(Environment.NewLine + "Please select dealer!");
                        throw new Exec(sb.ToString());
                    }




                    if (txtVehicleName.Text == "")
                    {
                        sb.Append(Environment.NewLine + " Vehicle Name Cannot be empty!");
                        throw new Exec(sb.ToString());
                    }
                    if (txtVehicleModel.Text == "")
                    {
                        sb.Append(Environment.NewLine + " Vehicle Model Cannot be empty!");
                        throw new Exec(sb.ToString());
                    }
                    if (txtDescription.Text == "")
                    {
                        sb.Append(Environment.NewLine + " Description Cannot be empty!");
                        throw new Exec(sb.ToString());
                    }
                    if (txtCost.Text == "")
                    {
                        sb.Append(Environment.NewLine + "Cost Cannot be empty!");
                        throw new Exec(sb.ToString());
                    }
                    if (txtTotalStock.Text == "")
                    {
                        sb.Append(Environment.NewLine + "Total Stock Cannot be empty!");
                        throw new Exec(sb.ToString());
                    }
                    if (txtRating.Text == "")
                    {
                        sb.Append(Environment.NewLine + "Rating Cannot be empty!");
                        throw new Exec(sb.ToString());
                    }
                    if (!Regex.IsMatch(txtCost.Text, "^\\d+$"))
                    {
                        sb.Append(Environment.NewLine + "Invalid Input!");
                        txtCost.Text = "";
                        throw new Exec(sb.ToString());
                    }
                    if (!Regex.IsMatch(txtTotalStock.Text, "^\\d+$"))
                    {
                        sb.Append(Environment.NewLine + "Invalid Input!");
                        txtTotalStock.Text = "";
                        throw new Exec(sb.ToString());
                    }
                    if (!Regex.IsMatch(txtRating.Text, "^\\d+$"))
                    {
                        sb.Append(Environment.NewLine + "Invalid Input!");
                        txtRating.Text = "";
                        throw new Exec(sb.ToString());
                    }

                    Vehicle vehicle = _context.Vehicles.SingleOrDefault(v => v.VehicleID.ToString().Equals(txtSearch.Text));

                    vehicle.VehicleName = txtVehicleName.Text;
                    vehicle.VehicleModel = txtVehicleModel.Text;
                    vehicle.DealerID = Convert.ToDecimal(cmbDealerName.SelectedValue);
                    if(!(txtImage.Text==""))
                    vehicle.Image = File.ReadAllBytes(txtImage.Text);
                    vehicle.Cost = Convert.ToDecimal(txtCost.Text);
                    vehicle.TotalStock = Convert.ToDecimal(txtTotalStock.Text);
                    vehicle.Description = txtDescription.Text;
                    vehicle.Rating = Convert.ToDecimal(txtRating.Text);



                    _context.SaveChanges();
                    MessageBox.Show("Successfully Updated!");
                    Reset();
                }
                catch (Exception Exec)
                {
                    MessageBox.Show(Exec.Message);
                }
            }

        }
        //Main Menu
        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            AdminLoginControl adminLoginControl = new AdminLoginControl();
            adminLoginControl.Show();
            this.Close();
        }

        private void BtnViewAll_Click(object sender, RoutedEventArgs e)
        {
            using (OVSEntities _context = new OVSEntities())
            {


                dgDetails.ItemsSource = _context.Vehicles.Include(v => v.Dealer).Select(v => new
                {
                    v.VehicleID,
                    v.VehicleName,
                    v.VehicleModel,
                    v.Dealer.CompanyName,
                    v.Cost,
                    v.Description,
                    v.TotalStock,
                    v.Rating


                }).ToList();
            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            using (OVSEntities _context = new OVSEntities())
            {
                var res = _context.Vehicles.Include(v => v.Dealer).SingleOrDefault(v => v.VehicleID.ToString().Equals(txtSearch.Text));
                if (res == null)
                    MessageBox.Show("No Result Found!");
                txtVehicleName.Text = res.VehicleName;
                txtVehicleModel.Text = res.VehicleModel;
                txtTotalStock.Text = res.TotalStock.ToString();
                txtRating.Text = res.Rating.ToString();
                txtDescription.Text = res.Description.ToString();
                txtCost.Text = res.Cost.ToString();
                cmbDealerName.SelectedValue = res.DealerID.ToString();
            }
        }

        private void DgDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        //Browse
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (OVSEntities _context = new OVSEntities())
            {


                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.ShowDialog();

                openFileDialog1.Filter = "Image files(*.bmp, *.jpg) | *.bmp; *.jpg | All files(*.*) | *.* ";


                openFileDialog1.DefaultExt = ".jpeg";

                txtImage.Text = openFileDialog1.FileName;
            }




        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (OVSEntities _context = new OVSEntities())
            {

                cmbDealerName.ItemsSource = _context.Dealers.ToList();
                cmbDealerName.DisplayMemberPath = "CompanyName";
                cmbDealerName.SelectedValuePath = "DealerID";
                dgDetails.ItemsSource = _context.Vehicles.Include(v => v.Dealer).Select(v => new
                {
                    v.VehicleID,
                    v.VehicleName,
                    v.VehicleModel,
                    v.Dealer.CompanyName,
                    v.Cost,
                    v.Description,
                    v.TotalStock,
                    v.Rating


                }).ToList();
            }


        }
    }
}
