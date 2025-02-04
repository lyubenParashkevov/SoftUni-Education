using System;

namespace _08._Basketball_equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double yearTax = double.Parse(Console.ReadLine());

            double shoes = yearTax - yearTax * 0.40;
            double outfit = shoes - shoes * 0.20;
            double ball = outfit / 4;
            double accessories = ball / 5;

            double sum = yearTax + shoes + outfit + ball + accessories;

            Console.WriteLine(sum); 
        }
    }
}
