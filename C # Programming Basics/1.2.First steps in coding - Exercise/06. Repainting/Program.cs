using System;

namespace _06._Repainting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double costNylon = 1.50;
            double costPaint = 14.50;
            double costPaintThinner = 5;
            double bags = 0.40;

            double nylon = double.Parse(Console.ReadLine()) + 2;
            double paint = double.Parse(Console.ReadLine());
            double paintPercent = paint * costPaint * 0.10;
            double costWorkHours = 0.30;
            double paintThinner = double.Parse(Console.ReadLine());
            double workHours = double.Parse(Console.ReadLine());

            double sum = nylon * costNylon + (paint * costPaint + paintPercent) + paintThinner * costPaintThinner + bags;
            double finalSum = sum + (sum * costWorkHours) * workHours;

            Console.WriteLine(finalSum);
        }
    }
}
