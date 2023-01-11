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
using System.Windows.Shapes;
namespace PROG_POE_Final
{
    /// <summary>
    /// Interaction logic for BudgetWindow.xaml
    /// </summary>
    public partial class BudgetWindow : Window
    {
        public BudgetWindow()
        {
            InitializeComponent();
        }

        //I have no idea wtf I did or how I did it, but it worked. This is the most shing ding thing I've done so far.
        //this...mess will make sure that the selected button remains a style until not selected
        //memory usage goes up by 20mb -- what a monstrosity but it works...
        // only thing that i can do to get it to work so far -- fairly self explanitory 
        public Button[] ButtonArray()
        {
            Button[] buttonArray = { incomeBtn, taxBtn, generalBtn, propertyBtn, vehicleBtn, savingsBtn, homeBtn };
            return buttonArray;
        }          
        void selectedBtn(Button button)
        {            

            Style normalBtn = FindResource("MaterialDesignFlatButton") as Style;
            Style selectedBtn = FindResource("MaterialDesignFlatAccentBgButton") as Style; 
            var unselectedButtonArrayList = ButtonArray().ToList();
            unselectedButtonArrayList.Remove(button);
            if (button.IsFocused)
            {
                button.Style = selectedBtn;
               
                foreach (Button butt in unselectedButtonArrayList)
                {
                    butt.Style = normalBtn;
                }
            }
        }
        private void incomeBtn_Click(object sender, RoutedEventArgs e)
        {
            IncomePage income = new IncomePage();
            mainFrame.Navigate(income);
            selectedBtn(incomeBtn);
        }

        private void taxBtn_Click(object sender, RoutedEventArgs e)
        {
            TaxPage tax = new TaxPage();
            mainFrame.Navigate(tax);
            selectedBtn(taxBtn);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IncomePage income = new IncomePage();
            incomeBtn.Style= FindResource("MaterialDesignFlatAccentBgButton") as Style;
            selectedBtn(incomeBtn);
            mainFrame.Navigate(income);                      
        }

        private void generalBtn_Click(object sender, RoutedEventArgs e)
        {
            GeneralExpensesPage ge = new GeneralExpensesPage();
            mainFrame.Navigate(ge);            
            selectedBtn(generalBtn);
        }

        private void propertyBtn_Click(object sender, RoutedEventArgs e)
        {
            PropertyPage prop = new PropertyPage();
            RentPage rent = new RentPage();
            HomeLoanPage hl = new HomeLoanPage();
            mainFrame.Navigate(prop);
            selectedBtn(propertyBtn);

        }

        private void homeBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();            
        }

        private void vehicleBtn_Click(object sender, RoutedEventArgs e)
        {
            VehiclePage vehicle = new VehiclePage();
            mainFrame.Navigate(vehicle);
            selectedBtn(vehicleBtn);
        }

        private void savingsBtn_Click(object sender, RoutedEventArgs e)
        {
            SavingsPage savings = new SavingsPage();
            mainFrame.Navigate(savings);
            selectedBtn(savingsBtn);
        }
    }
}
