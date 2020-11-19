using System;

namespace PayslipKata
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Please input your name:");
            string name = Console.ReadLine();
            Console.Write("Please input your surname:");
            string surname = Console.ReadLine();
            Console.Write("Please enter your annual salary:");
            int  salary = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter your super rate:");
            int super = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter your payment start date:");
            string startDate = Console.ReadLine();
            Console.Write("Please enter your payment end date:");
            string endDate = Console.ReadLine();


            Console.WriteLine("Your payslip has been generated:");

            Console.WriteLine("Name: " + name + " " + surname);
            /* 
            
            string[] teammates = new[] {"Leah", "Iris", "Samaa"};
            foreach (var person in teammates)
            {
                Console.WriteLine(person);

            }
            */
        }
    }
}