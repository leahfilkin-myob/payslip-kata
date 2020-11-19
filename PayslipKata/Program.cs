using System;

namespace PayslipKata
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the payslip generator!\n");
            
            Console.Write("Please input your name: ");
            string name = Console.ReadLine();
            Console.Write("Please input your surname: ");
            string surname = Console.ReadLine();
            uint result = 0;
            uint salary = 0;
            while (result == 0)
            {
                Console.Write("Please enter your annual salary: ");
                bool salaryCheck = UInt32.TryParse(Console.ReadLine(), out result);
                if (salaryCheck)
                {
                    salary = Convert.ToUInt32(result);
                }
                else
                {
                    Console.WriteLine("Sorry! We only accept numbers over 0 as salaries. Please try again.");
                }
            }

            int superRate = 51;
            while (superRate < 0 || superRate > 50)
            {
                Console.Write("Please enter your super rate: ");
                superRate = Convert.ToInt32(Console.ReadLine());
                if (superRate < 0 || superRate > 50)
                {
                    Console.WriteLine("Sorry! We only accept numbers between 0 and 50 inclusive as super rates. Please try again.");
                }
            }
            
            Console.Write("Please enter your payment start date: ");
            string startDate = Console.ReadLine();
            Console.Write("Please enter your payment end date: ");
            string endDate = Console.ReadLine();

            string paymentPeriod = RewritePaymentPeriod(startDate) + " - " + RewritePaymentPeriod(endDate);
            uint grossIncome = salary / 12;
            int incomeTax = Convert.ToInt32(Math.Ceiling(CalculateIncomeTax(salary)));
            int netIncome = Convert.ToInt32(grossIncome - incomeTax);
            int super = Convert.ToInt32(Math.Floor(grossIncome * (superRate * 0.01)));

            Console.WriteLine("\nYour payslip has been generated:\n");

            Console.WriteLine("Name: " + name + " " + surname);
            Console.WriteLine("Payment Period: " + paymentPeriod);
            Console.WriteLine("Gross Income: " + grossIncome);
            Console.WriteLine("Income Tax: " + incomeTax);
            Console.WriteLine("Net Income: " + netIncome);
            Console.WriteLine("Super: " + super + "\n");
            
            Console.WriteLine("Thank you for using MYOB!");
        }

        public static double CalculateIncomeTax(double salary)
        {
            double incomeTax = 0;
            
            if (salary < 18200)
            {
                incomeTax = 0;
            }
            else if (18200 < salary && salary <= 37000)
            {
                incomeTax = (salary - 18200) * 0.19 / 12;
            }
            else if (37000 < salary && salary <= 87000)
            {
                incomeTax = (3572 + (salary - 37000) * 0.325) / 12;
            }
            else if (87000 < salary && salary <= 180000)
            {
                incomeTax = (19822 + (salary - 87000) * 0.37) / 12;
            }
            else if (180000 < salary)
            {
                incomeTax = (54232 + (salary - 180000) * 0.45) / 12;
            }

            return incomeTax;


        }
        
        public static string RewritePaymentPeriod(string paymentDate)
        {
            string[] paymentDateArray = paymentDate.Split(' ');
            if (paymentDateArray[0].Length == 1)
            {
                paymentDateArray[0] = "0" + paymentDateArray[0];
            }
            /*else if (startDateArray[0].Length > 2)
            {
                
            }*/

            return paymentDateArray[0] + " " + paymentDateArray[1];

        }
        
    }
}