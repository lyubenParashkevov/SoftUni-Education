using System;

namespace _01._Birthday_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double rent = double.Parse(Console.ReadLine());
            double cacePrice = rent * 0.20;
            double drinksPrice = cacePrice - cacePrice * 0.45;
            double animatorPrice = rent / 3;
            double finalSum = rent + cacePrice + drinksPrice + animatorPrice;
            Console.WriteLine(finalSum);
        }
    }
}
