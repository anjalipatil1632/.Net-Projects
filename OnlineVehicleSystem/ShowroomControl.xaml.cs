using System;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace OnlineVehicleSystem
{
    /// <summary>
    /// Interaction logic for ShowroomControl.xaml
    /// </summary>
    public partial class ShowroomControl : Window
    {
        public ShowroomControl()
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


        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            using (OVSEntities _context = new OVSEntities())
            {
                try
                {

                    if (cmb_State.Text == "")
                    {

                        sb.Append(Environment.NewLine + "Please select your state!");
                        throw new Exec(sb.ToString());
                    }
                    if (cmb_city.Text == "")
                    {
                        sb.Append(Environment.NewLine + "Please select your city!");
                        throw new Exec(sb.ToString());
                    }
                    if (txtAddress.Text == "")
                    {
                        sb.Append(Environment.NewLine + " Showroom Name Cannot be empty!");
                        throw new Exec(sb.ToString());
                    }
                    if (!Regex.IsMatch(txtOwnerName.Text, "^[a-z A-Z]+$"))
                    {

                        sb.Append(Environment.NewLine + "Please input a valid name.");
                        txtOwnerName.Text = "";
                        throw new Exec(sb.ToString());
                    }
                    if (txtOwnerName.Text == "")
                    {
                        sb.Append(Environment.NewLine + "Name Cannot be empty!");
                        throw new Exec(sb.ToString());
                    }
                    if (!Regex.IsMatch(txtContact.Text, "^\\d{10}$"))
                    {

                        sb.Append(Environment.NewLine + "Please input a valid contact number.");
                        txtContact.Text = "";

                        throw new Exec(sb.ToString());
                    }
                    if (txtContact.Text == "")
                    {
                        sb.Append(Environment.NewLine + "Contact Number Cannot be empty!");
                        throw new Exec(sb.ToString());
                    }
                    if (!String.IsNullOrWhiteSpace(txtContact.Text))
                    {
                        var res = _context.Showrooms.SingleOrDefault(c => c.ContactNo.ToString().Contains(txtContact.Text));
                        if (!(res == null))
                        {
                            sb.Append(Environment.NewLine + "This no. is already registered");
                            txtContact.Text = "";

                            throw new Exec(sb.ToString());
                        }

                    }


                    Showroom showroom = new Showroom
                    {
                        Name = txtShowroomName.Text,
                        DealerID = Convert.ToDecimal(cmbDealerName.SelectedValue),
                        OwnerName = txtOwnerName.Text,
                        ContactNo = Convert.ToDecimal(txtContact.Text),
                        Address = txtAddress.Text,
                        City = cmb_city.SelectedValue.ToString(),
                        State = cmb_State.SelectedValue.ToString(),
                        Pincode = Convert.ToDecimal(txtPincode.Text)
                    };
                    _context.Showrooms.Add(showroom);
                    _context.SaveChanges();
                    MessageBox.Show("Record Added Successfully!");
                    Reset();
                }
                catch (Exception Exec)
                {
                    MessageBox.Show(Exec.Message);
                }
            }
        }
        public void Reset()
        {
            txtShowroomName.Text = "";
            cmbDealerName.Text = "";
            txtOwnerName.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
            cmb_city.Text = "";
            cmb_State.Text = "";
            txtPincode.Text = "";
            txtSearch.Text = "";
            tbl_adminName.Text = "";
        }
        public static decimal ShowroomId;
        private void BtnModify_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            using (OVSEntities _context = new OVSEntities())
            {
                try
                {
                    if (cmb_State.Text == "")
                    {

                        sb.Append(Environment.NewLine + "Please select your state!");
                        throw new Exec(sb.ToString());
                    }
                    if (cmb_city.Text == "")
                    {
                        sb.Append(Environment.NewLine + "Please select your city!");
                        throw new Exec(sb.ToString());
                    }
                    if (txtAddress.Text == "")
                    {
                        sb.Append(Environment.NewLine + " Showroom Name Cannot be empty!");
                        throw new Exec(sb.ToString());
                    }
                    if (!Regex.IsMatch(txtOwnerName.Text, "^[a-z A-Z]+$"))
                    {

                        sb.Append(Environment.NewLine + "Please input a valid name.");
                        txtOwnerName.Text = "";
                        throw new Exec(sb.ToString());
                    }
                    if (txtOwnerName.Text == "")
                    {
                        sb.Append(Environment.NewLine + "Name Cannot be empty!");
                        throw new Exec(sb.ToString());
                    }
                    if (!Regex.IsMatch(txtContact.Text, "^\\d{10}$"))
                    {

                        sb.Append(Environment.NewLine + "Please input a valid contact number.");
                        txtContact.Text = "";

                        throw new Exec(sb.ToString());
                    }
                    if (txtContact.Text == "")
                    {
                        sb.Append(Environment.NewLine + "Contact Number Cannot be empty!");
                        throw new Exec(sb.ToString());
                    }
                    if (!String.IsNullOrWhiteSpace(txtContact.Text))
                    {
                        var res = _context.Showrooms.SingleOrDefault(c => c.ContactNo.ToString().Contains(txtContact.Text));
                        if (!(res == null))
                        {
                            if (res.ContactNo.ToString() == tbl_adminName.Text) { }
                            else
                            {
                                sb.Append(Environment.NewLine + "This no. is already registered");
                                txtContact.Text = "";

                                throw new Exec(sb.ToString());
                            }

                        }

                    }

                    Showroom SearchRes = _context.Showrooms.SingleOrDefault(d => d.ContactNo.ToString().Contains(txtSearch.Text));


                    SearchRes.Name = txtShowroomName.Text;
                    SearchRes.DealerID = Convert.ToDecimal(cmbDealerName.SelectedValue);
                    SearchRes.OwnerName = txtOwnerName.Text;
                    SearchRes.ContactNo = Convert.ToDecimal(txtContact.Text);
                    SearchRes.Address = txtAddress.Text;
                    SearchRes.City = cmb_city.SelectedValue.ToString();
                    SearchRes.State = cmb_State.SelectedValue.ToString();
                    SearchRes.Pincode = Convert.ToDecimal(txtPincode.Text);
                    ShowroomId = SearchRes.ShowroomID;

                    _context.SaveChanges();
                    MessageBox.Show("Update Successful!");
                    Reset();
                }
                catch (Exception Exec)
                {
                    MessageBox.Show(Exec.Message);
                }


            }
        }

        private void BtnViewAll_Click(object sender, RoutedEventArgs e)
        {
            using (OVSEntities _context = new OVSEntities())
            {
                dgDetails.ItemsSource = _context.Showrooms.Include(d => d.Dealer).Select(d => new
                {
                    d.Name,
                    d.OwnerName,
                    d.Dealer.CompanyName,
                    d.ContactNo,
                    d.Address,
                    d.City,
                    d.State,
                    d.Pincode

                }).ToList();
            }
        }

        private void DgDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Cmb_State_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                using (OVSEntities _context = new OVSEntities())
                {
                    var CityList = (from s in _context.StateMasters
                                    join c in _context.CityMasters on s.ID equals c.StateID
                                    where s.Name == cmb_State.SelectedValue.ToString()
                                    select c.Name).ToList();
                    cmb_city.ItemsSource = CityList;

                }
            }
            catch (Exception)
            {

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (OVSEntities _context = new OVSEntities())
            {
                cmb_State.ItemsSource = _context.StateMasters.Select(s => s.Name).ToList();
                cmbDealerName.ItemsSource = _context.Dealers.ToList();
                cmbDealerName.DisplayMemberPath = "CompanyName";
                cmbDealerName.SelectedValuePath = "DealerID";


                dgDetails.ItemsSource = _context.Showrooms.Include(d => d.Dealer).Select(d => new
                {
                    d.Name,
                    d.OwnerName,
                    d.Dealer.CompanyName,
                    d.ContactNo,
                    d.Address,
                    d.City,
                    d.State,
                    d.Pincode

                }).ToList();


            }
        }
        //Go To Main Menu
        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            AdminLoginControl adminLoginControl = new AdminLoginControl();
            adminLoginControl.Show();
            this.Close();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            using (OVSEntities _context = new OVSEntities())
            {
                Showroom SearchRes = _context.Showrooms.Include(d => d.Dealer).SingleOrDefault(d => d.ContactNo.ToString().Contains(txtSearch.Text));
                if (SearchRes == null)
                    MessageBox.Show("No Result Found");
                txtShowroomName.Text = SearchRes.Name;
                cmbDealerName.SelectedValue = SearchRes.DealerID;
                txtOwnerName.Text = SearchRes.OwnerName;
                txtContact.Text = SearchRes.ContactNo.ToString();
                txtAddress.Text = SearchRes.Address;
                cmb_State.Text = SearchRes.State;
                cmb_city.Text = SearchRes.City;

                txtPincode.Text = SearchRes.Pincode.ToString();
                tbl_adminName.Text = SearchRes.ContactNo.ToString();


            }

        }






    }
}
