using System;

namespace _04._Movie_Stars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double salary = 0;
            while (true)
            {
                string acterName = Console.ReadLine();

                if (acterName == "ACTION")
                {
                    Console.WriteLine($"We are left with {budget:f2} leva.");
                    break;
                }
                if (acterName.Length > 15)
                {
                    salary = budget * 0.20;
                    budget -= salary;
                    continue;
                }
                salary = double.Parse(Console.ReadLine());
                if (budget < salary)
                {
                    Console.WriteLine($"We need {salary - budget:f2} leva for our actors.");
                    break;
                }
                budget -= salary;
            }
        }
    }
}
