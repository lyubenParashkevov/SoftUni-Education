using System;

namespace _03._Time___15_Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            minutes = minutes + 15;


            if (minutes == 60)
            {
                minutes = 00;
                hour += 1;
            }
            else if (minutes > 60)
            {
                minutes = minutes - 60;
                hour += 1;
            }
            if (hour == 24)
            {
                hour = 0;
            }

            if (minutes < 10)
            {
                Console.WriteLine($"{hour}:0{minutes}");
            }
            else if (minutes >= 10)
            {
            Console.WriteLine($"{hour}:{minutes}");
            }

        }
    }
}
