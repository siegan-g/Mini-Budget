using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace PROG_POE_Final
{
    class UserIncome
    {  
        private double monthlyIncome;


        public void CalcIncome(double income)
        {
            this.monthlyIncome = income;
        }
        public double GetIncome() 
        {
            return monthlyIncome;
        }

        public override string ToString()
        {
            return monthlyIncome.ToString("C", CultureInfo.CurrentCulture);
        }
        


    }
}
