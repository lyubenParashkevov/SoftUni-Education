using System;

namespace _06._Easter_Decoration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int clientsNum = int.Parse(Console.ReadLine());
            int productsCount = 0;
            double sum = 0;
            double price = 0;
            double fullSum = 0;
            for (int i = 0; i < clientsNum; i++)
            {
                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "Finish")
                    {
                        if (productsCount % 2 == 0)
                        {
                            sum -= sum * 0.20;
                        }
                        Console.WriteLine($"You purchased {productsCount} items for {sum:f2} leva.");
                        break;
                    }
                    if (input == "basket")
                    {
                        price = 1.50;
                        productsCount++;
                        sum += price;
                    }
                    else if (input == "wreath")
                    {
                        price = 3.80;
                        productsCount++;
                        sum += price;
                    }
                    else if (input == "chocolate bunny")
                    {
                        price = 7.00;
                        productsCount++;
                        sum += price;
                    }
                }             
                fullSum += sum;
                sum = 0;
                productsCount = 0;
            }
            Console.WriteLine($"Average bill per client is: {fullSum / clientsNum:f2} leva.");
        }
    }
}
