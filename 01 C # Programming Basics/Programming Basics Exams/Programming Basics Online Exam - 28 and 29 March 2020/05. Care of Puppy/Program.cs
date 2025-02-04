using System;

namespace _05._Care_of_Puppy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine()) * 1000;
            string input = "";
            int foodSum = 0;
            while (true)
            {
                input = Console.ReadLine();
                if (input == "Adopted")
                {
                    if (foodSum <= foodQuantity)
                    {
                        Console.WriteLine($"Food is enough! Leftovers: {foodQuantity - foodSum} grams.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"Food is not enough. You need {foodSum - foodQuantity} grams more.");
                        return;
                    }
                }
                int foodGrams = int.Parse(input);
                foodSum += foodGrams;
            }
            
        }
    }
}
