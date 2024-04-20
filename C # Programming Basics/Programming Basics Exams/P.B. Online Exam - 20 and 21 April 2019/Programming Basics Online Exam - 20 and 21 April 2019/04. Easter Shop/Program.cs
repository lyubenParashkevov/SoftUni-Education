using System;

namespace _04._Easter_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int eggsInStore = int.Parse(Console.ReadLine());
            
            int soldEggsCount = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Close")
                {
                    Console.WriteLine("Store is closed!");
                    Console.WriteLine($"{soldEggsCount} eggs sold.");
                    break;
                }
                int numEggs = int.Parse(Console.ReadLine());
                if (input == "Buy")
                {
                    if (numEggs > eggsInStore)
                    {
                        Console.WriteLine("Not enough eggs in store!");
                        Console.WriteLine($"You can buy only {eggsInStore}.");
                        return;
                    }
                    eggsInStore -= numEggs;
                    soldEggsCount += numEggs;
                }
                else if (input == "Fill")
                {
                    eggsInStore += numEggs;
                }
            }
        }
    }
}
