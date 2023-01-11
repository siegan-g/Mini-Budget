using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace PROG_POE_Final
{
     class GeneralExpense : EveryExpense
    {
        //Changed from v2.0 >>>gets and sets over an array
        public double groceries { get; set; }
        public double waterAndLights { get; set; }
        public double phone { get; set; }
        public double travel { get; set; }
        public double other { get; set; }
       
        private double total = 0;
        //storing General Expenses in an array as requested

        public override void CalcExpense(double total)
        {
            total = groceries + waterAndLights + phone + travel + other;
            this.total = total;
        }

        public override double GetExpense()
        {       
                return total;           
        }

        public override string ToString()
        {
            return total.ToString("C", CultureInfo.CurrentCulture);
        }
    }
}
