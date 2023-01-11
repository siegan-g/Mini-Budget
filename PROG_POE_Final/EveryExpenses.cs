using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace PROG_POE_Final
{
    public interface ExpenseInterface
    { //an interface where all classes that implement it must have the following methods
        //creates a template for each expense
        void CalcExpense(double value);
        double GetExpense();
    }
    public abstract class EveryExpense : ExpenseInterface
    {
        //an abstract class displaying Abstraction and Polymorphrism in OOP
        public abstract void CalcExpense(double value); 
        public abstract double GetExpense();
        public abstract override string ToString();

        public double LoanCalculator(double principalAmount,double deposit, double interest,int period)
        {
             principalAmount = principalAmount - deposit;
            double accumulatedAmount = principalAmount * (1 + (interest/100) * (period / 12));
            double monthlyRepayment = accumulatedAmount / period;
            return Math.Round(monthlyRepayment, 2);
        }

    }
} 

