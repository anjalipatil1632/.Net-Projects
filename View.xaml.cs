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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace EmployeeTravelBookingWPF
{
    /// <summary>
    /// Interaction logic for View.xaml
    /// </summary>
    public partial class View : Page
    {
        public View()
        {
            InitializeComponent();
        }
        SprintdbEntities entityobj = new SprintdbEntities();
        
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                
                if (txtuseridbox.Text == "")
                {
                    MessageBox.Show("UserID Shouldn't be blank!");

                }
                              
                else
                {
                    
                    int id = Convert.ToInt32(txtuseridbox.Text);
                    //var newid=from d in entityobj.Users where d.UserId == id select d.LoginId;                   
                    var data = from d in entityobj.TravelRequests where d.UserId ==id select d;
                    if (data == null)
                    {
                        MessageBox.Show("You have not Raised any ticket or\n UserID is incorrect");
                    }
                    else
                    {
                        grid.ItemsSource = data.ToList();
                        
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtuseridbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
