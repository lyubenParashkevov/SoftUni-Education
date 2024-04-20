using System;

namespace _03._Coffee_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string drink = Console.ReadLine();
            string shugar = Console.ReadLine();
            int numDrinks = int.Parse(Console.ReadLine());
            double price = 0;
            double fullSum = 0;

            if (drink == "Espresso")
            {
                if (shugar == "Without")
                {
                    price = 0.90 - (0.90 * 0.35);
                    if (numDrinks >= 5)
                    {
                        price -= price * 0.25;
                    }
                }
                else if (shugar == "Normal")
                {
                    price = 1.00;
                }
                else if (shugar == "Extra")
                {
                    price = 1.20;
                }
            }
            else if (drink == "Cappuccino")
            {
                if (shugar == "Without")
                {
                    price = 1.00;
                }
                else if (shugar == "Normal")
                {
                    price = 1.20;
                }
                else if (shugar == "Extra")
                {
                    price = 1.60;
                }
            }
            else if (drink == "Tea")
            {
                if (shugar == "Without")
                {
                    price = 0.50;
                }
                else if (shugar == "Normal")
                {
                    price = 0.60;
                }
                else if (shugar == "Extra")
                {
                    price = 0.70;
                }

            }
            fullSum = price * numDrinks;
            if (fullSum > 15.00)
            {
                fullSum -= fullSum * 0.20;
            }
            Console.WriteLine($"You bought {numDrinks} cups of {drink} for {fullSum:f2} lv.");
        }
    }
}
