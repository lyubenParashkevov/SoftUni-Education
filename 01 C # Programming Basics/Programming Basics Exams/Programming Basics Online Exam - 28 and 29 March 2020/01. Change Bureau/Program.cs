using System;

namespace _01._Change_Bureau
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bitcoin = int.Parse(Console.ReadLine());
            double chinaYoan = double.Parse(Console.ReadLine());
            double commision = double.Parse(Console.ReadLine());
            double levSum = bitcoin * 1168 + chinaYoan *0.15 * 1.76;
            double euroSum = levSum / 1.95;
            double finalSum = euroSum - euroSum * commision / 100;
            Console.WriteLine($"{finalSum:f2}");
        }
    }
}
