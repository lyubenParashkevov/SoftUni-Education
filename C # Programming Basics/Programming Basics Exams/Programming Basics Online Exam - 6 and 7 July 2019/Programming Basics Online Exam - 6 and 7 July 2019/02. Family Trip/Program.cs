using System;

namespace _02._Family_Trip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());
            double oneNightPrice = double.Parse(Console.ReadLine());    
            int percent = int.Parse(Console.ReadLine());

            double realPercent = budget * percent / 100;
            if (nights > 7)
            {
                oneNightPrice -= oneNightPrice / 100 * 5; 
            }
            double fullSum = nights * oneNightPrice + realPercent;

            if (fullSum <= budget)
            {
                Console.WriteLine($"Ivanovi will be left with {budget - fullSum:f2} leva after vacation.");
            }
            else
            {
                Console.WriteLine($"{fullSum - budget:f2} leva needed.");
                
            }
        }
    }
}
