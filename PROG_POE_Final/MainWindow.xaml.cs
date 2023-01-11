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
//create a using statement to import poe2??
namespace PROG_POE_Final
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e) //Generates these directorys when the home screen loads does not throw exceptions if already created
        {
            System.IO.Directory.CreateDirectory("Expenses");
            System.IO.Directory.CreateDirectory("Income");
        }

        private void budgetBtn_Click(object sender, RoutedEventArgs e)
        {
            BudgetWindow budget = new BudgetWindow();
            budget.Show();
            this.Close();
        }

        private void statsBtn_Click(object sender, RoutedEventArgs e)
        {
            StatsWindow stat = new StatsWindow();
            stat.Show();
            this.Close();
        }
    }
}
