using System;

namespace _01._Programming_Book
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double pagePrice =  double.Parse(Console.ReadLine());
            double shellPrice = double.Parse(Console.ReadLine());
            int percent = int.Parse(Console.ReadLine());    
            double designerPrice = double.Parse(Console.ReadLine());
            int teamPercent = int.Parse(Console.ReadLine());
            double allPagesPrice = pagePrice * 899 + shellPrice * 2;
            double priceAfterPercent = allPagesPrice -= allPagesPrice * percent / 100;
            priceAfterPercent = priceAfterPercent + designerPrice;
            double finalPrice = priceAfterPercent -= priceAfterPercent * teamPercent / 100;
            Console.WriteLine($"Avtonom should pay {finalPrice:f2} BGN.");
        }
    }
}
