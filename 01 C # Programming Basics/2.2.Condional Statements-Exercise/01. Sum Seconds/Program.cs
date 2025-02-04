using System;

namespace _01._Sum_Seconds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstTime = int.Parse(Console.ReadLine());
            int secondTime = int.Parse(Console.ReadLine());
            int thirthTime = int.Parse(Console.ReadLine());

            int tottalTime = firstTime + secondTime + thirthTime;

            int minutes = tottalTime / 60;
            int seconds = tottalTime % 60;

            
            if (seconds < 10)
            {
            Console.WriteLine($"{minutes}:0{seconds}");
            }
            else
            {
                Console.WriteLine($"{minutes}:{seconds}");
            }
        }
    }
}
