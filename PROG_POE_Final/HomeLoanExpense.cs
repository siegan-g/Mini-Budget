using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace PROG_POE_Final
{
    class HomeLoanExpense : EveryExpense
    {
        public double purchasePrice { get; set; }
        public double interestRate { get; set; }
        public double deposit { get; set; }
        public int months { get; set; }
        public double homeLoanPay { get; set; }

       public override void CalcExpense(double homeLoanPay)
        {
            //formula for home loan
            //Formula has been changed to simple interest as of 2.0 
            //A = P(1+i*n) where A is the AccumulatedValue  of the home and P is the Principal amount
            //principle amount = purchase price - deposit

            // user must enter purchase price, interest rate, deposit, months to repay 
            //interest rate must be entered as a percentage
            homeLoanPay=LoanCalculator(purchasePrice, deposit, interestRate, months);            
            this.homeLoanPay = homeLoanPay;
        }        
        public override double GetExpense()
        {
            return homeLoanPay;
        }
        public override string ToString()
        {
            return homeLoanPay.ToString("C", CultureInfo.CurrentCulture);
        }
    }
}
