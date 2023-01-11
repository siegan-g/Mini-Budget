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
    /// Interaction logic for TaxPage.xaml
    /// </summary>
    public partial class TaxPage : Page
    {
        public TaxPage()
        {
            InitializeComponent();
        }
        FileIO io = new FileIO();
        private void taxConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            Tax tax = new Tax();
            try
            {
                tax.CalcExpense(Convert.ToDouble(taxTxtb.Text));
                warningTxtb.Visibility = Visibility.Hidden;
            }
            catch (Exception)
            {
                warningTxtb.Visibility = Visibility.Visible;
            }
            io.FileWrite(Directory.Expenses, "tax", tax.ToString());
            currentTaxTxtb.Text = tax.ToString();
            
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            currentTaxTxtb.Text = io.FileRead(Directory.Expenses, "tax");
        }
    }
}
