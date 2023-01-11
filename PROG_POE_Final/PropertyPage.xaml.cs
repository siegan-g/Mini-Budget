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
    /// Interaction logic for PropertyPage.xaml
    /// </summary>
    public partial class PropertyPage : Page
    {
        public PropertyPage()
        {
            InitializeComponent();
        }
        FileIO io = new FileIO();
        private void rentBtn_Click(object sender, RoutedEventArgs e)
        {
            RentPage rent = new RentPage();
            this.NavigationService.Navigate(rent);
            io.DestroyFile(Directory.Expenses, "home_loan");
            
        }

        private void homeLoanBtn_Click(object sender, RoutedEventArgs e)
        {
            HomeLoanPage hl = new HomeLoanPage();
            this.NavigationService.Navigate(hl);
            io.DestroyFile(Directory.Expenses, "rent");

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string rent= io.FileRead(Directory.Expenses, "rent");
            string hl = io.FileRead(Directory.Expenses, "home_loan");
            if (rent.Length>=1)
            {
                currentPropertyTxtb.Text = rent;
            }
            else if(hl.Length>=1)
            {
                currentPropertyTxtb.Text = hl;
            }
        }
    }
}
