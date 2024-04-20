using System;

namespace _04._Food_for_Pets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double foodQuantity = double.Parse(Console.ReadLine());
            double dogEatenFood = 0;
            double catEatenFood = 0;
            double dogFoodSum = 0;
            double catFoodSum = 0;
            int dayCount = 0;
            double bisquitsCount = 0;
            double bisquitsSum = 0;
            double foodEatenTogether = 0;
            for (int i = 0; i < days; i++)
            {
                dogEatenFood = int.Parse(Console.ReadLine());
                dogFoodSum += dogEatenFood;
                catEatenFood = int.Parse(Console.ReadLine());
                catFoodSum += catEatenFood;
                dayCount++;
                foodEatenTogether += dogEatenFood + catEatenFood;
                if (dayCount == 3)
                {
                    bisquitsCount = (dogEatenFood + catEatenFood) * 0.10;
                    bisquitsSum += bisquitsCount;
                    dayCount = 0;
                }

            }
            Console.WriteLine($"Total eaten biscuits: {Math.Round(bisquitsSum)}gr.");
            Console.WriteLine($"{foodEatenTogether / foodQuantity * 100:f2}% of the food has been eaten.");
            Console.WriteLine($"{dogFoodSum / foodEatenTogether * 100:f2}% eaten from the dog.");
            Console.WriteLine($"{catFoodSum / foodEatenTogether * 100:f2}% eaten from the cat.");
        }
    }
}
