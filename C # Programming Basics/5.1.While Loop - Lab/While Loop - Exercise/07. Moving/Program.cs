using System;

namespace _07._Moving
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int volume = width * lenght * height;
            int box = 0;
             
            string input = "";
            while ((input = (Console.ReadLine())) != "Done")
            {
                box = int.Parse(input);
                volume-= box;
                if (volume <= 0)
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(volume)} Cubic meters more.");
                    return;
                }

            }
            Console.WriteLine($"{volume} Cubic meters left.");


        }
    }
}
