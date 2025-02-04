using System;

namespace _04._Tourist_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
           double budget = double.Parse(Console.ReadLine());
            int productCount = 0;
            double sum = 0;
            int allProductCount = 0;
            while (true)
            {
                string productName = Console.ReadLine();
                productCount++;
                
                if (productName == "Stop")
                {
                    Console.WriteLine($"You bought {allProductCount} products for {sum:f2} leva.");
                    break;
                }
                allProductCount++;
                double productPrice = double.Parse(Console.ReadLine());
                if (productCount == 3)
                {
                    productPrice = productPrice / 2;
                    productCount = 0;
                }
                if (productPrice > budget)
                {
                    Console.WriteLine("You don't have enough money!");
                    Console.WriteLine($"You need {productPrice - budget:f2} leva!");
                    break ;
                }
                
                sum += productPrice;
                budget -= productPrice;
            }
        }
    }
}
