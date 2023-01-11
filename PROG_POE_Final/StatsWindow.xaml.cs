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
    /// Interaction logic for StatsWindow.xaml
    /// </summary>
    public partial class StatsWindow : Window
    {
        public StatsWindow()
        {
            InitializeComponent();
        }
        FileIO io = new FileIO();
        TotalCalculator total = new TotalCalculator();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string income =  io.FileRead(Directory.Income, "income");
            incomeTxtb.Text = income;
            taxTxtb.Text = io.FileRead(Directory.Expenses, "tax");
            generalTxtb.Text = io.FileRead(Directory.Expenses, "general_expenses");

            string rent = io.FileRead(Directory.Expenses, "rent");
            string hl = io.FileRead(Directory.Expenses, "home_loan");
            if (rent.Length >= 1)
            {
                propertyTxtb.Text = rent;
            }
            else if (hl.Length >= 1)
            {
                propertyTxtb.Text = hl;
            }

            try
            {

                string[] vehicle = io.FileRead(Directory.Expenses, "vehicle").Split(",");
                vehicleTxtb.Text = vehicle[0] + "\n" + vehicle[1];

                string[] savings = io.FileRead(Directory.Expenses, "savings").Split(",");
                savingsTxtb.Text = savings[0] + "\n" + savings[1];
            }
            catch(IndexOutOfRangeException)
            {
                vehicleTxtb.Text = "";
                savingsTxtb.Text= "";
            }

            total.SetTotal();
            totalTxtb.Text = total.GetTotal();
            warningTxtb.Text = total.TotalWarning();           
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }
    }
}
