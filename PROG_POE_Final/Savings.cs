using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace PROG_POE_Final
{
    class Savings
    {
        //not particularly sure what the question asked. I'm going to assume a savings account using simple interest if the 
        //user has to put in an amount every month
        
        double investMonthly = 0;
        public void CalcSavings(double principalAmount, double deposit, double interest, int period)
        {
            principalAmount = principalAmount - deposit;
            double accumulatedAmount = principalAmount * (1 + (interest / 100) * (period / 12));
            double monthlyRepayment = accumulatedAmount / period;
            double investMonthly= Math.Round(monthlyRepayment, 2);
            this.investMonthly = investMonthly;
        }
        public double GetSavings()
        {
            return investMonthly;
        }

        public override string ToString()
        {
            return investMonthly.ToString("C", CultureInfo.CurrentCulture);
        }

    }
}
