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
    /// Interaction logic for SavingsPage.xaml
    /// </summary>
    public partial class SavingsPage : Page
    {
        public SavingsPage()
        {
            InitializeComponent();
        }

        int period = 0;
        FileIO io = new FileIO();

        public int GetPeriod()
        {
            return period;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            currentSavingsTxtb.Text = io.FileRead(Directory.Expenses, "savings");
        }

        private void calendarBtn_Click(object sender, RoutedEventArgs e)
        {
            calendar.Visibility = Visibility.Visible;

        }

        private void savingsBtnClick_Click(object sender, RoutedEventArgs e)
        {
            
            Savings savings = new Savings();
            string savingsDetails = "";
            try
            {
                double principalAmnt = Convert.ToDouble(principalTxtb.Text);
                double deposit = Convert.ToDouble(depositTxtb.Text);
                double interest = Convert.ToDouble(interestTxtb.Text);
                string details = detailsTxtb.Text;

                savings.CalcSavings(principalAmnt, deposit, interest, GetPeriod());

                 savingsDetails = details + ", " + savings.ToString();
                warningTxtb.Visibility = Visibility.Hidden;

            }

            catch (Exception)
            {
                warningTxtb.Visibility = Visibility.Visible;
            }

            io.FileWrite(Directory.Expenses, "savings", savingsDetails);
            currentSavingsTxtb.Text = savingsDetails;
        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {

            calendar.Visibility = Visibility.Hidden;
            DateTime selectedDate = Convert.ToDateTime(calendar.SelectedDate);
            TimeSpan differenceDate = selectedDate.Subtract(DateTime.Now);
            int period = Convert.ToInt32(Math.Round(Convert.ToDouble(differenceDate.Days) / 30.4167));
            this.period = period;
        }
    }
}
