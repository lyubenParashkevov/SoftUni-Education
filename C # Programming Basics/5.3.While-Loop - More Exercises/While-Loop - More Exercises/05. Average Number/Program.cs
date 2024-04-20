using System;

namespace _05._Average_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            double sum = 0;
            int num = 0;
            int numCount = 0;
            while (numCount < n)
            {
                num = int.Parse(Console.ReadLine());
                sum += num;
                numCount++;
            }
            Console.WriteLine($"{sum / n:f2}");
        }
    }
}
