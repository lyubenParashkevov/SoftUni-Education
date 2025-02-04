using System;

namespace _03._Gaming_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double totalSpent = 0;
            string input = "";
            double price = 0;
            while(input != "Game Time")
            {
                input = Console.ReadLine();

                if (budget == 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }
                if (input == "Game Time")
                {
                    Console.WriteLine($"Total spent: ${totalSpent}. Remaining: ${budget:f2}");
                    break;
                }
                
                if (input == "OutFall 4")
                {
                    price = 39.99;
                    if (price > budget)
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                    budget -= price;
                    totalSpent += price;
                    Console.WriteLine($"Bought {input}");
                }
                else if (input == "CS: OG")
                {
                    price = 15.99;
                    if (price > budget)
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                    budget -= price;
                    totalSpent += price;
                    Console.WriteLine($"Bought {input}");
                }
                else if (input == "Zplinter Zell")
                {
                    price = 19.99;
                    if (price > budget)
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                    budget -= price;
                    totalSpent += price;
                    Console.WriteLine($"Bought {input}");
                }
                else if (input == "Honored 2")
                {
                    price = 59.99;
                    if (price > budget)
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                    budget -= price;
                    totalSpent += price;
                    Console.WriteLine($"Bought {input}");
                }
                else if (input == "RoverWatch")
                {
                    price = 29.99;
                    if (price > budget)
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                    budget -= price;
                    totalSpent += price;
                    Console.WriteLine($"Bought {input}");
                }
                else if (input == "RoverWatch Origins Edition")
                {
                    price = 39.99;
                    if (price > budget)
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                    budget -= price;
                    totalSpent += price;
                    Console.WriteLine($"Bought {input}");
                }
                else
                {
                    Console.WriteLine("Not Found");
                }
            }
        }
    }
}
