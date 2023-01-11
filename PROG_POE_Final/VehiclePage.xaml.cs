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
    /// Interaction logic for VehiclePage.xaml
    /// </summary>
    public partial class VehiclePage : Page
    {
        public VehiclePage()
        {
            InitializeComponent();
        }
        FileIO io = new FileIO();
        private void vehicleConfirmBtn_Click(object sender, RoutedEventArgs e)
        { 

            Car car = new Car();
            try
            {
                car.purchasePrice = Convert.ToDouble(principalTxtb.Text);
                car.insurance = Convert.ToDouble(insuranceTxtB.Text);
                car.deposit = Convert.ToDouble(depositTxtB.Text);
                car.interest = Convert.ToDouble(interestTxtb.Text);
                car.model = modelTxtB.Text;
                warningTxtb.Visibility = Visibility.Hidden;
            }
            catch (Exception)
            {
                warningTxtb.Visibility = Visibility.Visible;
            }

            car.CalcExpense(0);
            string carMonthlyPayment = car.model+", "+car.ToString();

            io.FileWrite(Directory.Expenses, "vehicle", carMonthlyPayment);
            currentVehicleTxtb.Text = carMonthlyPayment;

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            currentVehicleTxtb.Text = io.FileRead(Directory.Expenses, "vehicle");

        }
    }
}
