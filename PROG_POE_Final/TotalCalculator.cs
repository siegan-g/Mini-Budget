using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace PROG_POE_Final
{
    //A very slap-dash class I put together to calculate the total>>>running out of time, must be optimised in the future.

    class TotalCalculator
    {
         FileIO io = new FileIO();
        string currency = CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;
        string total = "";
        double totalValue = 0;

        public void SetTotal()
        {
            List<double> expenseList = new List<double>();

            try
            {

                string[] tax = io.FileRead(Directory.Expenses, "tax").Split(currency);
                expenseList.Add(Convert.ToDouble(tax[1]));

                string[] generalExp = io.FileRead(Directory.Expenses, "general_expenses").Split(currency);
                expenseList.Add(Convert.ToDouble(generalExp[1]));

                string[] vehicle = io.FileRead(Directory.Expenses, "vehicle").Split(currency);
                expenseList.Add(Convert.ToDouble(vehicle[1]));

                string[] savings = io.FileRead(Directory.Expenses, "savings").Split(currency);
                expenseList.Add(Convert.ToDouble(savings[1]));


                string rent_ = io.FileRead(Directory.Expenses, "rent");
                string hl_ = io.FileRead(Directory.Expenses, "home_loan");
                if (rent_.Length >= 1)
                {
                    string[] rent = rent_.Split(currency);
                    expenseList.Add(Convert.ToDouble(rent[1]));
                }
                else if (hl_.Length >= 1)
                {
                    string[] hl = hl_.Split(currency);
                    expenseList.Add(Convert.ToDouble(hl[1]));
                }
            }
            catch(IndexOutOfRangeException)
            { }
            string total = expenseList.Sum().ToString("C", CultureInfo.CurrentCulture);
            double totalValue= expenseList.Sum();
            this.total = total;
            this.totalValue = totalValue;

        }

        public string GetTotal()
        {
            return total;
        }

        public double GetTotalValue()
        {
            return totalValue;
        }

        public string TotalWarning()
        {
            string[] income = io.FileRead(Directory.Income, "income").Split(currency);
            string warning="";
            try
            {
                if (GetTotalValue()>(0.75*Convert.ToDouble(income[1])))
                {
                    warning = "⚠ Your Income is much less than your\n total expenses, consider altering some values";
                }
            }
            catch(IndexOutOfRangeException)
            { }
            return warning;
        }


    }
}
