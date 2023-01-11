using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace PROG_POE_Final
{
    public delegate void expenseCost();

    class Tax : EveryExpense
    {
        double tax;
        public override void CalcExpense(double tax)
        {
            this.tax = tax;
        }


        public override double GetExpense()
        {
            return tax;
        }


        public override string ToString()
        {
            return tax.ToString("C", CultureInfo.CurrentCulture);
        }
    }
}
