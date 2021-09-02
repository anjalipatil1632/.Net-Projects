using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace OnlineVehicleSystem
{
    /// <summary>
    /// Interaction logic for CustomerRegistration.xaml
    /// </summary>
    public partial class CustomerRegistration : Window
    {
        public CustomerRegistration()
        {
            InitializeComponent();
        }
        string gender = "";
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


        private void Btn_Register_Click(object sender, RoutedEventArgs e)
        {
            using (OVSEntities _context = new OVSEntities())
            {

                StringBuilder sb = new StringBuilder();
                if (String.IsNullOrWhiteSpace(tbl_adminName.Text))
                {
                    try
                    {
                        if (rad_male.IsChecked == true)
                        {
                            gender = "Male";
                        }
                        if (rad_female.IsChecked == true)
                        {
                            gender = "Female";
                        }
                        if (!(Regex.IsMatch(txt_Email.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z")))
                        {
                            sb.Append(Environment.NewLine + "Email is not in a correct format");
                            txt_Email.Text = "";
                            throw new Exec(sb.ToString());
                        }
                        if (!String.IsNullOrWhiteSpace(txt_Email.Text))
                        {
                            var res = _context.Customers.SingleOrDefault(c => c.Email.ToString().Contains(txt_Email.Text));
                            if (!(res == null))
                            {
                                sb.Append(Environment.NewLine + "This Email is already registered");
                                txt_Email.Text = "";

                                throw new Exec(sb.ToString());
                            }

                        }
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
                        if (txt_address.Text == "")
                        {
                            sb.Append(Environment.NewLine + " Showroom Name Cannot be empty!");
                            throw new Exec(sb.ToString());
                        }
                        if (!Regex.IsMatch(txt_name.Text, "^[a-z A-Z]+$"))
                        {

                            sb.Append(Environment.NewLine + "Please input a valid name.");
                            txt_name.Text = "";
                            throw new Exec(sb.ToString());
                        }
                        if (txt_name.Text == "")
                        {
                            sb.Append(Environment.NewLine + "Name Cannot be empty!");
                            throw new Exec(sb.ToString());
                        }
                        if (!Regex.IsMatch(txt_contactNo.Text, "^\\d{10}$"))
                        {

                            sb.Append(Environment.NewLine + "Please input a valid contact number.");
                            txt_contactNo.Text = "";

                            throw new Exec(sb.ToString());
                        }
                        if (txt_contactNo.Text == "")
                        {
                            sb.Append(Environment.NewLine + "Contact Number Cannot be empty!");
                            throw new Exec(sb.ToString());
                        }
                        if (!String.IsNullOrWhiteSpace(txt_contactNo.Text))
                        {
                            var res = _context.Customers.SingleOrDefault(c => c.ContactNo.ToString().Contains(txt_contactNo.Text));
                            if (!(res == null))
                            {
                                sb.Append(Environment.NewLine + "This no. is already registered");
                                txt_contactNo.Text = "";

                                throw new Exec(sb.ToString());
                            }

                        }
                        if (gender == "")
                        {
                            sb.Append(Environment.NewLine + "Please check a gender");
                            throw new Exec(sb.ToString());
                        }
                        Customer customer = new Customer
                        {
                            CustomerName = txt_name.Text,
                            Gender = gender,
                            ContactNo = Convert.ToDecimal(txt_contactNo.Text),
                            Email = txt_Email.Text,
                            Address = txt_address.Text,
                            City = cmb_city.SelectedValue.ToString(),
                            State = cmb_state.SelectedValue.ToString(),
                            Pincode = Convert.ToDecimal(txt_Pincode.Text)
                        };
                        _context.Customers.Add(customer);
                        _context.SaveChanges();
                        MessageBox.Show("Your Contact no. is password");

                        CustomerLoginControl customerLoginControl = new CustomerLoginControl();
                        customerLoginControl.tbl_adminName.Text = txt_Email.Text;
                        customerLoginControl.Show();
                        this.Close();

                    }
                    catch (Exception Exec)
                    {
                        MessageBox.Show(Exec.Message);

                    }
                }
                else
                {
                    try
                    {
                        if (rad_male.IsChecked == true)
                        {
                            gender = "Male";
                        }
                        if (rad_female.IsChecked == true)
                        {
                            gender = "Female";
                        }
                        if (!(Regex.IsMatch(txt_Email.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z")))
                        {
                            sb.Append(Environment.NewLine + "Email is not in a correct format");
                            txt_Email.Text = "";
                            throw new Exec(sb.ToString());
                        }
                        if (!String.IsNullOrWhiteSpace(txt_Email.Text))
                        {
                            var res = _context.Customers.SingleOrDefault(c => c.Email.ToString().Contains(txt_Email.Text));
                            if (!(res == null))
                            {
                                if (res.Email == tbl_adminName.Text)
                                {

                                }
                                else
                                {
                                    sb.Append(Environment.NewLine + "This Email is already registered");
                                    txt_Email.Text = "";

                                    throw new Exec(sb.ToString());
                                }

                            }


                        }
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
                        if (txt_address.Text == "")
                        {
                            sb.Append(Environment.NewLine + " Showroom Name Cannot be empty!");
                            throw new Exec(sb.ToString());
                        }
                        if (!Regex.IsMatch(txt_name.Text, "^[a-z A-Z]+$"))
                        {

                            sb.Append(Environment.NewLine + "Please input a valid name.");
                            txt_name.Text = "";
                            throw new Exec(sb.ToString());
                        }
                        if (txt_name.Text == "")
                        {
                            sb.Append(Environment.NewLine + "Name Cannot be empty!");
                            throw new Exec(sb.ToString());
                        }
                        if (!Regex.IsMatch(txt_contactNo.Text, "^\\d{10}$"))
                        {

                            sb.Append(Environment.NewLine + "Please input a valid contact number.");
                            txt_contactNo.Text = "";

                            throw new Exec(sb.ToString());
                        }
                        if (txt_contactNo.Text == "")
                        {
                            sb.Append(Environment.NewLine + "Contact Number Cannot be empty!");
                            throw new Exec(sb.ToString());
                        }
                        if (!String.IsNullOrWhiteSpace(txt_contactNo.Text))
                        {
                            var res = _context.Customers.SingleOrDefault(c => c.ContactNo.ToString().Contains(txt_contactNo.Text));
                            Customer phone = _context.Customers.SingleOrDefault(c => c.Email.Contains(tbl_adminName.Text));
                            if (!(res == null))
                            {
                                if (res.ContactNo == phone.ContactNo) { }
                                else
                                {
                                    sb.Append(Environment.NewLine + "This no. is already registered");
                                    txt_contactNo.Text = "";

                                    throw new Exec(sb.ToString());
                                }
                            }

                        }
                        if (gender == "")
                        {
                            sb.Append(Environment.NewLine + "Please check a gender");
                            throw new Exec(sb.ToString());
                        }
                        Customer customer = _context.Customers.SingleOrDefault(c => c.Email.Contains(tbl_adminName.Text));


                        customer.CustomerName = txt_name.Text;
                        customer.Gender = gender;
                        customer.ContactNo = Convert.ToDecimal(txt_contactNo.Text);
                        customer.Email = txt_Email.Text;
                        customer.Address = txt_address.Text;
                        customer.City = cmb_city.SelectedValue.ToString();
                        customer.State = cmb_state.SelectedValue.ToString();
                        customer.Pincode = Convert.ToDecimal(txt_Pincode.Text);


                        _context.SaveChanges();
                        MessageBox.Show("Your Deatil is Successfully updated.");

                        CustomerLoginControl customerLoginControl = new CustomerLoginControl();
                        customerLoginControl.tbl_adminName.Text = txt_Email.Text;
                        customerLoginControl.Show();
                        this.Close();

                    }
                    catch (Exception Exec)
                    {
                        MessageBox.Show(Exec.Message);

                    }

                }
            }
        }

        private void Btn_MainMenu_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbl_adminName.Text))
            {
                CustomerLoginSignup customerLoginSignup = new CustomerLoginSignup();
                customerLoginSignup.Show();
                this.Close();
            }
            else
            {
                CustomerLoginControl customerLoginControl = new CustomerLoginControl();
                customerLoginControl.tbl_adminName.Text = tbl_adminName.Text;
                customerLoginControl.Show();
                this.Close();
            }
        }

        private void Btn_Reset_Click(object sender, RoutedEventArgs e)
        {
            rad_male.IsChecked = false;


            rad_female.IsChecked = false;

            txt_Email.Text = "";


            cmb_state.Text = "";
            cmb_city.Text = "";

            txt_address.Text = "";




            txt_name.Text = "";

            txt_name.Text = "";



            txt_contactNo.Text = "";


            txt_contactNo.Text = "";
            txt_Pincode.Text = "";


        }

        private void Cmb_city_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (OVSEntities _context = new OVSEntities())
            {
                cmb_state.ItemsSource = _context.StateMasters.Select(s => s.Name).ToList();
                if (!String.IsNullOrWhiteSpace(tbl_adminName.Text))
                {
                    Customer customer = _context.Customers.SingleOrDefault(c => c.Email.Contains(tbl_adminName.Text));
                    txt_Email.Text = customer.Email;


                    cmb_state.Text = customer.State;
                    cmb_city.Text = customer.City;

                    txt_address.Text = customer.Address;




                    txt_name.Text = customer.CustomerName;





                    txt_contactNo.Text = customer.ContactNo.ToString();



                    txt_Pincode.Text = customer.Pincode.ToString();
                    if (customer.Gender == "Male")
                    {
                        rad_male.IsChecked = true;
                    }
                    else
                    {
                        rad_female.IsChecked = true;
                    }


                }
            }

        }

        private void Rad_female_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Rad_male_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
