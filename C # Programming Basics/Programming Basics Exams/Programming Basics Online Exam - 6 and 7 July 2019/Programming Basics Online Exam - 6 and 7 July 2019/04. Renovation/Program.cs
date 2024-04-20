using System;

namespace _04._Renovation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int paint = 0;
            double finalArea = 0;
            string input = "";
            int hight = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int percent = int.Parse(Console.ReadLine());
            double areaToPaint = 4 * width * hight;
            areaToPaint -= (areaToPaint * percent / 100);
            finalArea = Math.Ceiling(areaToPaint);
            while (true)
            {
                input = Console.ReadLine();
                if (input == "Tired!")
                {
                    Console.WriteLine($"{finalArea} quadratic m left.");
                    break;
                }
                paint = int.Parse(input);
                finalArea -= paint;
                if (finalArea == 0)
                {
                    Console.WriteLine("All walls are painted! Great job, Pesho!");
                    break;
                }
                else if (finalArea < 0)
                {
                    Console.WriteLine($"All walls are painted and you have {Math.Abs(finalArea)} l paint left!");
                    break;
                }
            }
        }
    }
}
