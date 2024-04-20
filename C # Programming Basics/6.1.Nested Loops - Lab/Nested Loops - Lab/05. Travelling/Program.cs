using System;

namespace _05._Travelling
{
    internal class Program
    {
        static void Main(string[] args)
        { 
                        
            while (true)
            {
                string destination = Console.ReadLine();
                if (destination == "End")
                {
                    break;
                }
                double budget = double.Parse(Console.ReadLine());
                double savings = 0;
                while (true)
                {
                   double currMoney = double.Parse(Console.ReadLine());
                    savings += currMoney;
                    if (savings >= budget)
                    {
                        Console.WriteLine($"Going to {destination}!");
                        savings = 0;
                        break;
                    }
                }
            }
        }
    }
}



            


