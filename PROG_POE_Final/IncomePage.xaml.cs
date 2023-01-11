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
    /// Interaction logic for IncomePage.xaml
    /// </summary>
    public partial class IncomePage : Page
    {
        public IncomePage()
        {
            InitializeComponent();
        }
        FileIO io = new FileIO();

        private void incomeConfirmBtn_Click(object sender, RoutedEventArgs e)
        {

            UserIncome income = new UserIncome();
            try
            {
                income.CalcIncome(Convert.ToDouble(incomeTxtb.Text));
                warningTxtb.Visibility = Visibility.Hidden;
            }
            catch (Exception)
            {
                warningTxtb.Visibility = Visibility.Visible;
            }
            io.FileWrite(Directory.Income, "income", income.ToString());
            currentIncomeTextB.Text = income.ToString();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            currentIncomeTextB.Text = io.FileRead(Directory.Income, "income");

        }
    }
}
