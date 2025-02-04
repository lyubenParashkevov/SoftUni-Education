using System;

namespace _05._Easter_Bake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bakesNum = int.Parse(Console.ReadLine());
            double flourPack = 750;
            double sugarPack = 950;
            int flourSum = 0;
            int sugarSum = 0;
            int maxFlour = int.MinValue;
            int maxSugar = int.MinValue;
            for (int i = 0; i < bakesNum; i++)
            {
                int sugar = int.Parse(Console.ReadLine());
                int flour = int.Parse(Console.ReadLine());
                sugarSum += sugar;
                if (sugar > maxSugar)
                {
                    maxSugar = sugar;
                }
                flourSum += flour;
                if (flour > maxFlour)
                {
                    maxFlour = flour;
                }
                  
            }
            Console.WriteLine($"Sugar: {Math.Ceiling(sugarSum / sugarPack)}");
            Console.WriteLine($"Flour: {Math.Ceiling(flourSum / flourPack)}");
            Console.WriteLine($"Max used flour is {maxFlour} grams, max used sugar is {maxSugar} grams.");
        }
    }
}
