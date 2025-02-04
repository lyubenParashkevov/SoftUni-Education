using System;

namespace _03._Energy_Booster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string pack = Console.ReadLine();
            int numPacks = int.Parse(Console.ReadLine());
            double price = 0;
            if (pack == "small")
            {
                if (fruit == "Watermelon")
                {
                    price = 56.00 * 2;
                }
                else if (fruit == "Mango")
                {
                    price = 36.66 * 2;
                }
                else if (fruit == "Pineapple")
                {
                    price = 42.10 * 2;
                }
                else if (fruit == "Raspberry")
                {
                    price = 20.00 * 2;
                }
            }
            else if (pack == "big")
            {
                if (fruit == "Watermelon")
                {
                    price = 28.70 * 5;
                }
                else if (fruit == "Mango")
                {
                    price = 19.60 * 5;
                }
                else if (fruit == "Pineapple")
                {
                    price = 24.80 * 5;
                }
                else if (fruit == "Raspberry")
                {
                    price = 15.20 * 5;
                }
            }
            double fullSum = numPacks * price;
            if (fullSum >= 400 && fullSum <= 1000)
            {
                fullSum -= fullSum * 0.15;
            }
            else if (fullSum > 1000)
            {
                fullSum -= fullSum * 0.5;
            }
            Console.WriteLine($"{fullSum:f2} lv.");
        }
    }
}
