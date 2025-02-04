using System;

namespace _02._Football_Kit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double tshirtPrice = double.Parse(Console.ReadLine());
            double sumForBal = double.Parse(Console.ReadLine());
            double shortsPrice = tshirtPrice * 0.75;
            double sox = shortsPrice * 0.20;
            double shoesPrice = 2 * (tshirtPrice + shortsPrice);
            double sum = tshirtPrice + shortsPrice + sox + shoesPrice;
            double finalSum = sum - sum * 0.15;
            if (finalSum >= sumForBal)
            {
                Console.WriteLine("Yes, he will earn the world-cup replica ball!");
                Console.WriteLine($"His sum is {finalSum:f2} lv.");
            }
            else
            {
                Console.WriteLine("No, he will not earn the world-cup replica ball.");
                Console.WriteLine($"He needs {sumForBal - finalSum:f2} lv. more.");
            }
        }
    }
}
