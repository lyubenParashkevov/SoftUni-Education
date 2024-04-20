using System;

namespace _02._Cat_Walking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minutesWalkForDay = int.Parse(Console.ReadLine());
            int numWalks = int.Parse(Console.ReadLine());
            int caloriesForDay = int.Parse(Console.ReadLine());
            double caloriesBurned = minutesWalkForDay * 5 * numWalks;
            
            if (caloriesBurned >= caloriesForDay / 2.0)
            {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {caloriesBurned}.");
            }
            else
            {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {caloriesBurned}.");
            }
        }
    }
}
