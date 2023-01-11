using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG_POE_Final
{
    class ConsoleInput //A class that runs the CLI program...not needed right now but perhaps in the future this can be run through CLI prompt
    {
        Dictionary<string, double> expenseDict = new Dictionary<string, double>();

        public delegate string WarningDelegate(double valueOne, double valueTwo);
        public double income;
        public string Warning(double valueOne,double valueTwo)
        {
            string warn="";
            if(valueOne<valueTwo*0.75)
            {
                warn = "Warning 75% of your expenses is greater than your income, consider rerunning the program and altering some amounts";
            }
            return warn;
        }
        public string PromptAmount(string valueName)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            return "Enter the value for your " + valueName;
        }

        public string ReturnAmount(string valueName, string value)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            return "Your " + valueName + "is set as " + value;
        }

        public double EnterAmount(double value)
        {
            bool valid = false;
            double validValue=0;
            do
            {
                try
                {
                    validValue = value;
                    valid = true;
                }
                catch (System.FormatException e)
                {
                    ExceptionCost(e);
                }
            }
            while (valid == false);
            return validValue;
        }

        public int EnterInput(int input)
        {
            bool valid = false;
            int validInput = 0;
            do
            {
                try
                {
                    validInput = input;
                    valid = true;
                }
                catch (System.FormatException e)
                {
                    ExceptionInput(e);
                }
            }
            while (valid == false);
            return validInput;
        }
        static void ExceptionCost(System.FormatException e) //a housekeeping method used for whenever there is an Exception entering a double value
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error \n" + e);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter a valid value, it must be a number formatted as 1000, 1 000 or 1000,00");
        }
        static void ExceptionInput(System.FormatException e) //housekeeping method whenever there is an exception for an input value
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error \n" + e);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter a valid value, it must be a number stated in the instructions");
        }

        public void EnterIncome()
        {
            Console.WriteLine(PromptAmount("Income"));
            UserIncome inc = new UserIncome();
            double income = EnterAmount(Convert.ToDouble(Console.ReadLine()));
            this.income = income;
            inc.CalcIncome(income);
            Console.WriteLine(ReturnAmount("income", inc.ToString()));
        }

        public void EnterTax()
        {
            Console.WriteLine(PromptAmount("Tax"));
            Tax tax = new Tax();
            double taxAmount = EnterAmount(Convert.ToDouble(Console.ReadLine()));
            tax.CalcExpense(taxAmount);
            Console.WriteLine(ReturnAmount("tax", tax.ToString()));
            expenseDict.Add("Tax", tax.GetExpense());
        }

        public void EnterGeneralExpenses()
        {
            GeneralExpense ge = new GeneralExpense();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Now we will determine your general expenses which includes of>>>");
            Console.WriteLine("1.Groceries: {0}\n2.Water and Lights: {1}\n3.Phone Costs: {2}\n4.Travel Costs: {3}\n5.Other: {4}\n6.Continue",
                ge.groceries,ge.waterAndLights,ge.phone,ge.travel,ge.other);

            int input = EnterInput(Convert.ToInt32(Console.ReadLine()));
            while (input <= 6)
            {
             Console.WriteLine("1.Groceries: {0}\n2.Water and Lights: {1}\n3.Phone Costs: {2}\n4.Travel Costs: {3}\n5.Other: {4}\n6.Continue",
            ge.groceries, ge.waterAndLights, ge.phone, ge.travel, ge.other);
                switch (input)
                {
                    case 1:
                        Console.WriteLine(PromptAmount("Groceries")); ge.groceries = EnterAmount(Convert.ToDouble(Console.ReadLine()));
                        break;
                    case 2:
                        Console.WriteLine(PromptAmount("Water and Lights"));  ge.waterAndLights = EnterAmount(Convert.ToDouble(Console.ReadLine()));
                        break;
                    case 3:
                        Console.WriteLine(PromptAmount("Phone Costs"));  ge.phone = EnterAmount(Convert.ToDouble(Console.ReadLine()));
                        break;
                    case 4:
                        Console.WriteLine(PromptAmount("Travel"));  ge.travel = EnterAmount(Convert.ToDouble(Console.ReadLine()));
                        break;
                    case 5: 
                        Console.WriteLine(PromptAmount("Miscallenous")); ge.other= EnterAmount(Convert.ToDouble(Console.ReadLine()));
                        break;
                }
                 input = EnterInput(Convert.ToInt32(Console.ReadLine())); 
            }            
            ge.CalcExpense(0); //have to enter a value though method will add up total returned through GetExpense
            Console.WriteLine(ReturnAmount("general expenses", ge.ToString()));
            expenseDict.Add("General Expenses", ge.GetExpense());
        }

        public void EnterProperty()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Choose your type of property between:\n 1.Rent\n.Home Loan");
            int input = EnterInput(Convert.ToInt32(Console.ReadLine()));

            if(input==1)
            {
                RentExpense rent = new RentExpense();
                Console.WriteLine(PromptAmount("rent"));
                double rentAmount = EnterAmount(Convert.ToDouble(Console.ReadLine()));
                rent.CalcExpense(rentAmount);
                Console.WriteLine(ReturnAmount("rent", rent.ToString()));
                expenseDict.Add("Rent", rent.GetExpense());
            }
            else if(input==2)
            {
                HomeLoanExpense hl =new HomeLoanExpense();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Your Home Mortgage is calculated through A=P*(1+n), where P =Purchase Price - Deposit and the Monthly Payment =A/n, so we will ask you to enter in each of the following values>>");
                Console.WriteLine(PromptAmount("Purchase Price"));
                hl.purchasePrice = EnterAmount(Convert.ToDouble(Console.ReadLine()));
                Console.WriteLine(PromptAmount("Deposit"));
                hl.deposit = EnterAmount(Convert.ToDouble(Console.ReadLine()));
                Console.WriteLine(PromptAmount("interest rate"));
                hl.interestRate = EnterAmount(Convert.ToDouble(Console.ReadLine()))/100;
                Console.WriteLine(PromptAmount("period in months"));
                hl.months = Convert.ToInt32(Console.ReadLine());
                hl.CalcExpense(0);
                Console.WriteLine(ReturnAmount("monthly home loan payment", hl.ToString()));
                expenseDict.Add("Home Loan", hl.GetExpense());
            }
        }

        public void EnterCar()
        {
            Car car = new Car();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Your Car Financing is calculated through A=P*(1+n), where P =Purchase Price - Deposit and the Monthly Payment =A/n. n is set to 5. so we will ask you to enter in each of the following values>>");
            Console.WriteLine(PromptAmount("Purchase Price"));
            car.purchasePrice = EnterAmount(Convert.ToDouble(Console.ReadLine()));
            Console.WriteLine(PromptAmount("Deposit"));
            car.deposit = EnterAmount(Convert.ToDouble(Console.ReadLine()));
            Console.WriteLine(PromptAmount("interest rate"));
            car.interest = EnterAmount(Convert.ToDouble(Console.ReadLine())) / 100;            
            car.CalcExpense(0);
            Console.WriteLine(ReturnAmount("monthly home loan payment", car.ToString()));
            expenseDict.Add("Car Loan", car.GetExpense());
        }

        public void Summary()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Lets summarise your expenses: ");
            for (int i = 0; i < expenseDict.Count; i++)
            {
                Console.WriteLine(expenseDict.ElementAt(0).Key + " " + expenseDict.ElementAt(0).Value);
            }
            double total = expenseDict.Sum(x => x.Value);
            Console.WriteLine("TOTAL:" + total);
            Console.WriteLine("REMAINING INCOME: "+(income-total));
            WarningDelegate warn = Warning;
            Console.WriteLine(warn(income, total));
        }

    }
}

