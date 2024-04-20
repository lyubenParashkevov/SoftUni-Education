using System;

namespace _01._Christmas_Preparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int papperRoll = int.Parse(Console.ReadLine());
            int textileRoll = int.Parse(Console.ReadLine());
            double glueLitters = double.Parse(Console.ReadLine());
            int percent = int.Parse(Console.ReadLine());

            double paperPrice = papperRoll * 5.80;
            double textilePrice = textileRoll * 7.20;
            double gluePrise = glueLitters * 1.20;
            double sum = paperPrice + textilePrice + gluePrise;
            double finalSum = sum - sum * percent / 100;
            Console.WriteLine($"{finalSum:f3}");
        }
    }
}
