using System;

namespace _05._Easter_Eggs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxEggs = int.MinValue;
            int redCount = 0;
            int greenCount = 0;
            int blueCount = 0;
            int orangeCount = 0;
            string maxEggsColour = "";
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string colour = Console.ReadLine();
                if (colour == "red")
                {
                    redCount++;
                    if (redCount > maxEggs)
                    {
                        maxEggs = redCount;
                        maxEggsColour = "red";
                    }
                }
                else if (colour == "orange")
                {
                    orangeCount++;
                    if (orangeCount > maxEggs)
                    {
                        maxEggs = orangeCount;
                        maxEggsColour = "orange";
                    }
                }
                else if (colour == "blue")
                {
                    blueCount++;
                    if (blueCount > maxEggs)
                    {
                        maxEggs = blueCount;
                        maxEggsColour = "blue";
                    }
                }
                else if (colour == "green")
                {
                    greenCount++;
                    if (greenCount > maxEggs)
                    {
                        maxEggs= greenCount;
                        maxEggsColour = "green";
                    }
                }
            }
            Console.WriteLine($"Red eggs: {redCount}");
            Console.WriteLine($"Orange eggs: {orangeCount}");
            Console.WriteLine($"Blue eggs: {blueCount}");
            Console.WriteLine($"Green eggs: {greenCount}");
            Console.WriteLine($"Max eggs: {maxEggs} -> {maxEggsColour}");
        }
    }
}
