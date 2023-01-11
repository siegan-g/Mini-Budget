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
    /// Interaction logic for GeneralExpensesPage.xaml
    /// </summary>
    public partial class GeneralExpensesPage : Page
    {
        public GeneralExpensesPage()
        {
            InitializeComponent();
        }
        

        FileIO io = new FileIO();
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            currentGeneralTxtb.Text=io.FileRead(Directory.Expenses, "general_expenses");
        }

        private void generalExpConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            GeneralExpense ge = new GeneralExpense();

            try
            {
                ge.groceries = Convert.ToDouble(groceryTxtb.Text);
                ge.waterAndLights = Convert.ToDouble(waterAndLightsTxtb.Text);
                ge.phone = Convert.ToDouble(phoneTxtb.Text);
                ge.travel = Convert.ToDouble(travelTxtb.Text);
                ge.other = Convert.ToDouble(otherTxtb.Text);
                warningTxtb.Visibility = Visibility.Hidden;
            }
            catch (Exception)
            {
                warningTxtb.Visibility = Visibility.Visible;
            }
            ge.CalcExpense(0);
            io.FileWrite(Directory.Expenses, "general_expenses", ge.ToString());           
            currentGeneralTxtb.Text = ge.ToString();
        }
    }
}
