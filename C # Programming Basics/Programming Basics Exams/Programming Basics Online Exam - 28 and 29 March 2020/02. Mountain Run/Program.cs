using System;

namespace _02._Mountain_Run
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double secondsToBeat = double.Parse(Console.ReadLine());
            double meters = double.Parse(Console.ReadLine());
            double secondsForMeter = double.Parse(Console.ReadLine());
            double slowing = Math.Floor(meters / 50) * 30;
            double fullTime = meters * secondsForMeter + slowing;
            if (fullTime < secondsToBeat)
            {
                Console.WriteLine($"Yes! The new record is {fullTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No! He was {fullTime - secondsToBeat:f2} seconds slower.");
            }

        }
    }
}
