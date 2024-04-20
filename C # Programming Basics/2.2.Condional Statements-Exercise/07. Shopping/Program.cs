using System;

namespace _07._Shopping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int videoCards = int.Parse(Console.ReadLine());
            int processors = int.Parse(Console.ReadLine());
            int ram = int.Parse(Console.ReadLine());
            double videoCardsPrice = 250;
            double processorsPrice = videoCards * videoCardsPrice * 0.35;
            double ramPrice = videoCards * videoCardsPrice * 0.10;

            double fullSum = videoCards * videoCardsPrice + processors * processorsPrice + ram * ramPrice;
            if (videoCards > processors)
            {
                fullSum -= fullSum * 0.15; 
            }

            if (budget >= fullSum)
            {
                Console.WriteLine($"You have {budget - fullSum:f2} leva left!");
            }
            else if (budget < fullSum)
            {
                Console.WriteLine($"Not enough money! You need {fullSum - budget:f2} leva more!");
            }


        }
    }
}
