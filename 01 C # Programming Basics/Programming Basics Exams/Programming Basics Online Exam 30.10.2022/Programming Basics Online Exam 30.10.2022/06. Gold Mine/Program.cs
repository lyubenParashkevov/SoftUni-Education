using System;

namespace _06._Gold_Mine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int locations = int.Parse(Console.ReadLine());
            double goldSum = 0;
            double fullGoldSum = 0;
            double realAverageProduction = 0;
            double averageProduction = 0;
            for (int i = 0; i < locations; i++)
            {
                 averageProduction = double.Parse(Console.ReadLine());
                int dayNum = int.Parse(Console.ReadLine());
                for (int j = 0; j < dayNum; j++)
                {
                    double goldDigged = double.Parse(Console.ReadLine());
                    goldSum += goldDigged;

                }
                fullGoldSum += goldSum;
                goldSum = 0;

                 realAverageProduction = fullGoldSum / dayNum;
                if (realAverageProduction >= averageProduction)
                {
                    Console.WriteLine($"Good job! Average gold per day: {realAverageProduction:f2}.");
                }
                else
                {
                    Console.WriteLine($"You need {averageProduction - realAverageProduction:f2} gold.");
                }
                realAverageProduction = 0;
                fullGoldSum = 0;
            }
        }
    }
}
