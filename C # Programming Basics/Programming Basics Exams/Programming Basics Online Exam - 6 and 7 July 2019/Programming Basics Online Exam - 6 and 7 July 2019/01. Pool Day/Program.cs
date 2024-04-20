using System;

namespace _01._Pool_Day
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numPeople = int.Parse(Console.ReadLine());
            double tax = double.Parse(Console.ReadLine());
            double sunLoungerPrice = double.Parse(Console.ReadLine());
            double umbrelaPrice = double.Parse(Console.ReadLine());

            double taxForAll = numPeople * tax;
            double countUmbrelas = Math.Ceiling(numPeople / 2.0);
            double countSunLongers = Math.Ceiling(numPeople * 0.75);
            double allSunLongersPrice = countSunLongers * sunLoungerPrice;
            double allUmbrelasPrice = countUmbrelas * umbrelaPrice;

            Console.WriteLine($"{(taxForAll + allSunLongersPrice + allUmbrelasPrice):f2} lv.");
        }
    }
}
