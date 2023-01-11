using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace PROG_POE_Final
{
     class RentExpense : EveryExpense 
    {
       private double rent;

        public override void CalcExpense(double rent)
        {
            this.rent = rent;
        }

        public override double GetExpense()
        {
            return rent;
        }

        public override string ToString()
        {
            return rent.ToString("C", CultureInfo.CurrentCulture);
        }
    }
}
