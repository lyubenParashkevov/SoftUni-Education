using System;

namespace _09._Padawan_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double studentsNum = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double lightsaberSum = lightsaberPrice * (Math.Ceiling(studentsNum + studentsNum * 0.10));
            double robeSum = robePrice * studentsNum;
            double beltSum = beltPrice * (studentsNum - Math.Floor(studentsNum / 6));

            double sum = lightsaberSum + robeSum + beltSum;
            if (sum <= budget)
            {
                Console.WriteLine($"The money is enough - it would cost {sum:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {sum - budget:f2}lv more.");
            }

        }
    }
}
