using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;


namespace OnlineVehicleSystem
{
    /// <summary>
    /// Interaction logic for AddDealer.xaml
    /// </summary>
    public partial class AddDealer : Window
    {
        public AddDealer()
        {
            InitializeComponent();
        }



        private void Btn_backToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            AdminLoginControl adminLoginControl = new AdminLoginControl();
            adminLoginControl.txtblock_name.Text = "Admin";
            adminLoginControl.Show();
            this.Close();
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

        private void Btn_addDealer_Click(object sender, RoutedEventArgs e)
        {
            using (OVSEntities _context = new OVSEntities())
            {
                StringBuilder sb = new StringBuilder();
                try
                {

                    if (cmb_state.Text == "")
                    {

                        sb.Append(Environment.NewLine + "Please select your state!");
                        throw new Exec(sb.ToString());
                    }
                    if (cmb_city.Text == "")
                    {
                        sb.Append(Environment.NewLine + "Please select your city!");
                        throw new Exec(sb.ToString());
                    }
                    if (!Regex.IsMatch(txt_dd_dealerName.Text, "^[a-z A-Z]+$"))
                    {

                        sb.Append(Environment.NewLine + "Please input a valid name.");
                        txt_dd_dealerName.Text = "";
                        throw new Exec(sb.ToString());
                    }
                    if (txt_dd_dealerName.Text == "")
                    {
                        sb.Append(Environment.NewLine + "Name Cannot be empty!");
                        throw new Exec(sb.ToString());
                    }
                    if (txt_dd_companyName.Text == "")
                    {
                        sb.Append(Environment.NewLine + " Company Name Cannot be empty!");
                        throw new Exec(sb.ToString());
                    }
                    if (!Regex.IsMatch(Txt_dd_contactNo.Text, "^\\d{10}$"))
                    {

                        sb.Append(Environment.NewLine + "Please input a valid contact number.");
                        Txt_dd_contactNo.Text = "";
                        throw new Exec(sb.ToString());


                    }
                    if (Txt_dd_contactNo.Text == "")
                    {
                        sb.Append(Environment.NewLine + "Contact Number Cannot be empty!");
                        throw new Exec(sb.ToString());
                    }



                    if (txt_dd_address.Text == "")
                    {
                        sb.Append(Environment.NewLine + " Address Cannot be empty!");
                        throw new Exec(sb.ToString());
                    }
                    if (!Regex.IsMatch(txt_dd_pincode.Text, "^\\d{6}$"))
                    {

                        sb.Append(Environment.NewLine + "Please input a valid zipcode!");
                        txt_dd_pincode.Text = "";
                        throw new Exec(sb.ToString());
                    }
                    if (txt_dd_pincode.Text == "")
                    {
                        sb.Append(Environment.NewLine + "Zipcode Cannot be empty!");
                        throw new Exec(sb.ToString());
                    }
                    if (!String.IsNullOrWhiteSpace(Txt_dd_contactNo.Text))
                    {
                        var res = _context.Dealers.SingleOrDefault(c => c.ContactNo.ToString().Contains(Txt_dd_contactNo.Text));
                        if (!(res == null))
                        {
                            sb.Append(Environment.NewLine + "This no. is already registered");
                            Txt_dd_contactNo.Text = "";

                            throw new Exec(sb.ToString());
                        }

                    }
                    Dealer dealer = new Dealer
                    {
                        DealerName = txt_dd_dealerName.Text,
                        CompanyName = txt_dd_companyName.Text,
                        Address = txt_dd_address.Text,
                        ContactNo = Convert.ToDecimal(Txt_dd_contactNo.Text),
                        City = cmb_city.SelectedValue.ToString(),
                        State = cmb_state.SelectedValue.ToString(),
                        Pincode = Convert.ToDecimal(txt_dd_pincode.Text)
                    };
                    _context.Dealers.Add(dealer);
                    _context.SaveChanges();
                    MessageBox.Show("Dealer Added Successfully");
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
            txt_dd_dealerName.Text = "";
            txt_dd_companyName.Text = "";
            txt_dd_address.Text = "";
            Txt_dd_contactNo.Text = "";
            cmb_city.Text = "";
            cmb_state.Text = "";
            txt_dd_pincode.Text = "";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (OVSEntities _context = new OVSEntities())
            {
                cmb_state.ItemsSource = _context.StateMasters.Select(s => s.Name).ToList();
                dgDetails.ItemsSource = _context.stpGetAllDealer();

            }

        }



        private void Cmb_state_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                using (OVSEntities _context = new OVSEntities())
                {
                    var CityList = (from s in _context.StateMasters
                                    join c in _context.CityMasters on s.ID equals c.StateID
                                    where s.Name == cmb_state.SelectedValue.ToString()
                                    select c.Name).ToList();
                    cmb_city.ItemsSource = CityList;

                }
            }
            catch (Exception)
            {

            }

        }





        private void Btn_viewall_Click(object sender, RoutedEventArgs e)
        {
            using (OVSEntities _context = new OVSEntities())
            {
                dgDetails.ItemsSource = _context.stpGetAllDealer();
            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            using (OVSEntities _context = new OVSEntities())
            {
                try
                {
                    Dealer SearchRes = _context.Dealers.SingleOrDefault(d => d.ContactNo.ToString().Contains(txtSearch.Text));
                    if (SearchRes == null)
                        MessageBox.Show("No Result Found");
                    txt_dd_dealerName.Text = SearchRes.DealerName;
                    txt_dd_companyName.Text = SearchRes.CompanyName;
                    txt_dd_address.Text = SearchRes.Address;
                    Txt_dd_contactNo.Text = SearchRes.ContactNo.ToString();
                    cmb_state.Text = SearchRes.State.ToString();
                    cmb_city.Text = SearchRes.City.ToString();

                    txt_dd_pincode.Text = SearchRes.Pincode.ToString();
                    tbl_adminName.Text = SearchRes.ContactNo.ToString();
                }
                catch (Exception)
                {
                    txtSearch.Text = "";
                }

            }
        }
        public static decimal dealerID;
        //Update Button
        private void Btn_backToMainMenu_Copy_Click(object sender, RoutedEventArgs e)
        {
            using (OVSEntities _context = new OVSEntities())
            {
                StringBuilder sb = new StringBuilder();
                try
                {
                    Dealer SearchRes = _context.Dealers.SingleOrDefault(d => d.ContactNo.ToString().Contains(txtSearch.Text));
                    dealerID = SearchRes.DealerID;
                    if (cmb_state.Text == "")
                    {

                        sb.Append(Environment.NewLine + "Please select your state!");
                        throw new Exec(sb.ToString());
                    }
                    if (cmb_city.Text == "")
                    {
                        sb.Append(Environment.NewLine + "Please select your city!");
                        throw new Exec(sb.ToString());
                    }
                    if (!Regex.IsMatch(txt_dd_dealerName.Text, "^[a-z A-Z]+$"))
                    {

                        sb.Append(Environment.NewLine + "Please input a valid name.");
                        txt_dd_dealerName.Text = "";
                        throw new Exec(sb.ToString());
                    }
                    if (txt_dd_dealerName.Text == "")
                    {
                        sb.Append(Environment.NewLine + "Name Cannot be empty!");
                        throw new Exec(sb.ToString());
                    }
                    if (txt_dd_companyName.Text == "")
                    {
                        sb.Append(Environment.NewLine + " Company Name Cannot be empty!");
                        throw new Exec(sb.ToString());
                    }
                    if (!Regex.IsMatch(Txt_dd_contactNo.Text, "^\\d{10}$"))
                    {

                        sb.Append(Environment.NewLine + "Please input a valid contact number.");
                        Txt_dd_contactNo.Text = "";
                        throw new Exec(sb.ToString());
                    }
                    if (Txt_dd_contactNo.Text == "")
                    {
                        sb.Append(Environment.NewLine + "Contact Number Cannot be empty!");
                        throw new Exec(sb.ToString());
                    }


                    if (txt_dd_address.Text == "")
                    {
                        sb.Append(Environment.NewLine + " Address Cannot be empty!");
                        throw new Exec(sb.ToString());
                    }
                    if (!Regex.IsMatch(txt_dd_pincode.Text, "^\\d{6}$"))
                    {

                        sb.Append(Environment.NewLine + "Please input a valid zipcode!");
                        txt_dd_pincode.Text = "";
                        throw new Exec(sb.ToString());
                    }
                    if (txt_dd_pincode.Text == "")
                    {
                        sb.Append(Environment.NewLine + "Zipcode Cannot be empty!");
                        throw new Exec(sb.ToString());
                    }
                    if (!String.IsNullOrWhiteSpace(Txt_dd_contactNo.Text))
                    {
                        var res = _context.Dealers.SingleOrDefault(c => c.ContactNo.ToString().Contains(Txt_dd_contactNo.Text));
                        if (!(res == null))
                        {
                            if (res.ContactNo.ToString() == tbl_adminName.Text) { }
                            else
                            {
                                sb.Append(Environment.NewLine + "This no. is already registered");
                                Txt_dd_contactNo.Text = "";

                                throw new Exec(sb.ToString());
                            }

                        }

                    }

                    SearchRes.DealerName = txt_dd_dealerName.Text;
                    SearchRes.CompanyName = txt_dd_companyName.Text;
                    SearchRes.Address = txt_dd_address.Text;
                    SearchRes.ContactNo = Convert.ToDecimal(Txt_dd_contactNo.Text);
                    SearchRes.City = cmb_city.SelectedValue.ToString();
                    SearchRes.State = cmb_state.SelectedValue.ToString();
                    SearchRes.Pincode = Convert.ToDecimal(txt_dd_pincode.Text);


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

        private void DgDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}

