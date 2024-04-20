using System;

namespace _04._Club
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double fullSum = 0;
            double order = 0;
            double cocktailPrice = 0;
            string input = "";
            double targetProffit = double.Parse(Console.ReadLine());

            while (true)
            {
                input = Console.ReadLine();
                if (input == "Party!")
                {
                    Console.WriteLine($"We need {targetProffit - fullSum:f2} leva more.");
                    Console.WriteLine($"Club income - {fullSum:f2} leva.");
                    break;
                }
                string cocktail = input;
                int numCocktails = int.Parse(Console.ReadLine());
                cocktailPrice = cocktail.Length;
                order = numCocktails * cocktailPrice;
                if (order % 2 != 0)
                {
                    order -= order * 0.25;
                }
                fullSum += order;
                if (fullSum >= targetProffit)
                {
                    Console.WriteLine("Target acquired.");
                    Console.WriteLine($"Club income - {fullSum:f2} leva.");
                    break ;
                }
            }

        }
    }
}
