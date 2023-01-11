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

namespace PROG_POE_Final
{
    /// <summary>
    /// Interaction logic for RentPage.xaml
    /// </summary>
    public partial class RentPage : Page
    {
        public RentPage()
        {
            InitializeComponent();
        }
        FileIO io = new FileIO();

        private void rentConfirmBtn_Click(object sender, RoutedEventArgs e)
        {

            RentExpense rent = new RentExpense();
            try
            {
                rent.CalcExpense(Convert.ToDouble(rentTxtb.Text));
                warningTxtb.Visibility = Visibility.Hidden;
            }
            catch (Exception)
            {
                warningTxtb.Visibility = Visibility.Visible;
            }
            io.FileWrite(Directory.Expenses, "rent", rent.ToString());
            currentRentTxtb.Text = rent.ToString();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            currentRentTxtb.Text = io.FileRead(Directory.Expenses, "rent");

        }
    }
}
