using System;

namespace _07._Vending_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double sum = 0;
            string input = "";
            while (input != "Start")
            {
                input = Console.ReadLine();
                if (input == "Start")
                {
                    break;
                }

                double coins = double.Parse(input);
                if (coins != 0.1 && coins != 0.2 && coins != 0.5 && coins != 1.0 && coins != 2.0)
                {
                    Console.WriteLine($"Cannot accept {coins}");
                    continue;
                }
                sum += coins;
            }
            while (input != "End")
            {
                input = Console.ReadLine();
                if (input == "End")
                {
                    Console.WriteLine($"Change: {sum:f2}");
                    break;
                }
                string product = input;
                if (product == "Nuts")
                {
                    if (sum < 2.0)
                    {
                        Console.WriteLine("Sorry, not enough money");

                    }
                    else
                    {
                        Console.WriteLine($"Purchased {product.ToLower()}");
                        sum -= 2.0;
                    }
                }
                else if (product == "Water")
                {

                    if (sum < 0.7)
                    {
                        Console.WriteLine("Sorry, not enough money");

                    }
                    else
                    {
                        Console.WriteLine($"Purchased {product.ToLower()}");
                        sum -= 0.7;
                    }
                }
                else if (product == "Crisps")
                {
                    if (sum < 1.5)
                    {
                        Console.WriteLine("Sorry, not enough money");

                    }
                    else
                    {
                        Console.WriteLine($"Purchased {product.ToLower()}");
                        sum -= 1.5;
                    }
                }
                else if (product == "Soda")
                {
                    if (sum < 0.8)
                    {
                        Console.WriteLine("Sorry, not enough money");

                    }
                    else
                    {
                        Console.WriteLine($"Purchased {product.ToLower()}");
                        sum -= 0.8;
                    }
                }
                else if (product == "Coke")
                {
                    if (sum < 1.0)
                    {
                        Console.WriteLine("Sorry, not enough money");

                    }
                    else
                    {
                        Console.WriteLine($"Purchased {product.ToLower()}");
                        sum -= 1.0;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }
            }
        }
    }
}
