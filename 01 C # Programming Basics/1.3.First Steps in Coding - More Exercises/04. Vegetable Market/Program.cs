using System;

namespace _04._Vegetable_Market
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double vegetablesPrice = double.Parse(Console.ReadLine());
            double fruitsPrice = double.Parse(Console.ReadLine());
            int vegetablesKg = int.Parse(Console.ReadLine());
            int fruitsKg = int.Parse(Console.ReadLine());
            double fullSum = (vegetablesPrice * vegetablesKg) + (fruitsPrice * fruitsKg);
            double fullSumInEuro = fullSum / 1.94;
            Console.WriteLine($"{fullSumInEuro:f2}");
        }
    }
}
