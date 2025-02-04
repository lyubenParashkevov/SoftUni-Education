using System;

namespace _02._Bike_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int juniors = int.Parse(Console.ReadLine());
            int seniors = int.Parse(Console.ReadLine());
            string trase = Console.ReadLine();
            double juniorsTax = 0;
            double seniorsTax = 0;
            double fullSum = 0;
            if (trase == "trail")
            {
                juniorsTax = 5.50;
                seniorsTax = 7;
            }
            else if (trase == "cross-country")
            {
                juniorsTax = 8.00;
                seniorsTax = 9.50;
                if (juniors + seniors >= 50)
                {
                    juniorsTax -= juniorsTax * 0.25;
                    seniorsTax -= seniorsTax * 0.25;
                }
            }
            else if (trase == "downhill")
            {
                juniorsTax = 12.25;
                seniorsTax = 13.75;
            }
            else if (trase == "road")
            {
                juniorsTax = 20.00;
                seniorsTax = 21.50;
            }
           fullSum = juniors * juniorsTax + seniors * seniorsTax;
            fullSum -= fullSum * 0.05;
            Console.WriteLine($"{fullSum:f2}");
        }

    }
}
