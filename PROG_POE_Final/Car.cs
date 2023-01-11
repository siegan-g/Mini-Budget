using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace PROG_POE_Final
{
    public class Car : EveryExpense
    {
        public double insurance { get; set; }
        public string model { get; set; }
        public double deposit { get; set; }
        public double purchasePrice { get; set; }
        public double interest { get; set; }
        public double carMonthlyCost { get; set; }
       
        public override void CalcExpense(double carMonthlyCost)
        {

            int period = 5*60; //poe requests a fixed period
            carMonthlyCost=insurance+LoanCalculator(purchasePrice, deposit, interest, period);
            this.carMonthlyCost = carMonthlyCost;

        }
        public override double GetExpense()
        {
            return carMonthlyCost;
        }

        public override string ToString()
        {
            return carMonthlyCost.ToString("C", CultureInfo.CurrentCulture);
        }
    }
}