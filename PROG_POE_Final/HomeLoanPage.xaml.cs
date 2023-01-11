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
    /// Interaction logic for HomeLoanPage.xaml
    /// </summary>
    public partial class HomeLoanPage : Page
    {
        public HomeLoanPage()
        {
            InitializeComponent();
        }
        FileIO io = new FileIO();
        private void homeLoanConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            HomeLoanExpense hl = new HomeLoanExpense();
            try
            {
                hl.purchasePrice = Convert.ToDouble(principalTxtb.Text);
                hl.interestRate = Convert.ToDouble(interestTxtb.Text);
                hl.months = Convert.ToInt32(periodTxtb.Text);
                hl.deposit = Convert.ToDouble(depositTxtb.Text);
                hl.CalcExpense(0);
                warningTxtb.Visibility = Visibility.Hidden;
            }
            catch (Exception)
            {
                warningTxtb.Visibility = Visibility.Visible;
            }
            io.FileWrite(Directory.Expenses, "home_loan", hl.ToString());
            currentHomeLoanTxtb.Text = hl.ToString();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            io.FileRead(Directory.Expenses, "home_loan");
        }
    }
}
