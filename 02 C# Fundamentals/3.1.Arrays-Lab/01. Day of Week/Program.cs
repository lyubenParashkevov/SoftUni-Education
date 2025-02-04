using System;

namespace _01._Day_of_Week
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] weekdays = new string[7]
            {
                "Monday",
                "Tuesday",
                "WednesDay",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };
            int dayOfWeek = int.Parse(Console.ReadLine());

            if (dayOfWeek >= 1 && dayOfWeek <= 7)
            {
                Console.WriteLine(weekdays[dayOfWeek - 1]);
            }
            else
            {
                Console.WriteLine("Invalid Day!");
            }

        }
    }
}
