using System;

namespace _04._Back_In_30_Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int newMinutes = minutes + 30;

            if(newMinutes >= 60)
            {
                minutes = newMinutes - 60;
                hours += 1;
                if (hours == 24)
                {
                    hours = 0;
                }
            }
           else
            {
                minutes = newMinutes;
            }
            Console.WriteLine($"{hours}:{minutes:D2}");
        }
    }
}
