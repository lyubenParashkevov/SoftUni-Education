using System;

namespace _07._House_Painting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            double houseVerticalX = double.Parse(Console.ReadLine());
            double houseHorizontalY = double.Parse(Console.ReadLine());
            double ceilingHightH = double.Parse(Console.ReadLine());

            double door = 1.2 * 2;
            double window = 1.5 * 1.5;
            double frontBack = (houseVerticalX * houseVerticalX) * 2 - door;
            double sideSides = (houseHorizontalY * houseVerticalX) * 2 - (window * 2);
            double ceilingSides = (houseHorizontalY * houseVerticalX) * 2;
            double ceilingsFrontBack = (houseVerticalX * ceilingHightH / 2) * 2;

            double allSides = frontBack + sideSides;
            double ceiling = ceilingSides + ceilingsFrontBack;

            double greenPaint = allSides / 3.4;
            double redPaint = ceiling / 4.3;

            Console.WriteLine($"{greenPaint:f2}");
            Console.WriteLine($"{redPaint:f2}");










        }
    }
}
