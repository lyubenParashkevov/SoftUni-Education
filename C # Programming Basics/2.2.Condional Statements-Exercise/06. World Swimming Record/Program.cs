using System;

namespace _06._World_Swimming_Record
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //съпротивлението го забавя на всеки 15 м със 12.5 секунди
            // при изчисление колко пъти ще се забави от съпротивлението,резултата да се закръгли надолу до най-близкото цяло число
            // да се изчисли времето за което плува и разликата спрямо рекорда.

            double reccordSeconds = double.Parse(Console.ReadLine());
            double meters = double.Parse(Console.ReadLine());
            double secondsPerMeter = double.Parse(Console.ReadLine());
            double delay = Math.Floor(meters / 15);
            double delayInSeconds = delay * 12.5;
            double fullTime = meters * secondsPerMeter + delayInSeconds;
            
            if (fullTime < reccordSeconds)
            {
                Console.WriteLine($" Yes, he succeeded! The new world record is {fullTime:f2} seconds.");
            }
            else if (fullTime >= reccordSeconds)
            {
                Console.WriteLine($"No, he failed! He was {fullTime - reccordSeconds:f2} seconds slower.");
            }

        }
    }
}
