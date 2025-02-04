using System;

namespace _05._Godzilla_vs._Kong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int extra = int.Parse(Console.ReadLine());
            double clothesPrice = double.Parse(Console.ReadLine());
            double decor = budget * 0.10;
            double allClothesPrice =extra * clothesPrice;

            if (extra < 150)
            {
                allClothesPrice = allClothesPrice;
            }
            else if (extra >= 150)
            {
                allClothesPrice -= allClothesPrice * 0.10;
            }

            double fullBudget =  decor + allClothesPrice;

            if (fullBudget > budget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {fullBudget - budget:f2} leva more.");
            }
            else if (fullBudget <= budget)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget - fullBudget:f2} leva left.");
            }





        }
    }
}
