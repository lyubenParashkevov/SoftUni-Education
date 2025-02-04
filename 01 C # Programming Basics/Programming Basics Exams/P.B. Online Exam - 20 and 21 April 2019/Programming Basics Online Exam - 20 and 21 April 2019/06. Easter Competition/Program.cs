using System;

namespace _06._Easter_Competition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pointSum = 0;
            string winner = "";
            int maxPoints = int.MinValue;
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "Stop")
                    {
                        Console.WriteLine($"{name} has {pointSum} points.");
                        break;
                    }
                    int point = int.Parse(input);
                    pointSum += point;
                }
                if (pointSum > maxPoints)
                {
                    maxPoints = pointSum;
                    winner = name;
                    Console.WriteLine($"{name} is the new number 1!");
                }
                pointSum = 0;
            }
            Console.WriteLine($"{winner} won competition with {maxPoints} points!");
        }
    }
}
