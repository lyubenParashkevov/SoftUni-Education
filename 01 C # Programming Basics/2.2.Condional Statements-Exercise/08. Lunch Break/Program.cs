using System;

namespace _08._Lunch_Break
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // Времето за обяд ще бъде 1 / 8 от времето за почивка, а времето за отдих ще бъде 1 / 4 от времето за почивка. 

            string movie = Console.ReadLine();
            int movieDuration = int .Parse(Console.ReadLine());
            int lunchBreak = int .Parse(Console.ReadLine());
            double lunchTime = lunchBreak / 8.0;
            double restDuration = lunchBreak / 4.0;
             double fullTime = movieDuration + lunchTime + restDuration;

            double differenceNot = fullTime - lunchBreak;
            differenceNot = Math.Ceiling(differenceNot);
            double differenceYes =lunchBreak - fullTime;
            differenceYes = Math.Ceiling(differenceYes);
            if (fullTime > lunchBreak)
            {
                Console.WriteLine($"You don't have enough time to watch {movie}, you need {differenceNot} more minutes.");
            }
            else if (fullTime <= lunchBreak)
            {
                Console.WriteLine($"You have enough time to watch {movie} and left with {differenceYes} minutes free time.");
            }



        }
    }
}
