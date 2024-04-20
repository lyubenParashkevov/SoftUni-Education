using System;

namespace _04._Fishing_Boat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermen = int.Parse(Console.ReadLine());
            double springPrice = 3000;
            double summerPrice = 4200;
            double autumnPrice = 4200;
            double winterPrice = 2600;
            double sum = 0;

            if (season == "Spring")
            {
                if (fishermen <= 6)
                {
                    sum = springPrice - springPrice * 0.10;
                }
                else if (fishermen >= 7 && fishermen <= 11)
                {
                    sum = springPrice - springPrice * 0.15;
                }
                else if (fishermen >= 12)
                {
                    sum = springPrice - springPrice * 0.25;
                }
                
            }
            else if (season == "Summer")
            {
                if (fishermen <= 6)
                {
                    sum = summerPrice - summerPrice * 0.10;
                }
                else if (fishermen >= 7 && fishermen <= 11)
                {
                    sum = summerPrice - summerPrice * 0.15;
                }
                else if (fishermen >= 12)
                {
                    sum = summerPrice - summerPrice * 0.25;
                }
                
            }
            else if (season == "Autumn")
            {
                if (fishermen <= 6)
                {
                    sum = autumnPrice - autumnPrice * 0.10;
                }
                else if (fishermen >= 7 && fishermen <= 11)
                {
                    sum = autumnPrice - autumnPrice * 0.15;
                }
                else if (fishermen >= 12)
                {
                    sum = autumnPrice - autumnPrice * 0.25;
                }

            }
            else if (season == "Winter")
            {
                if (fishermen <= 6)
                {
                    sum = winterPrice - winterPrice * 0.10;
                }
                else if (fishermen >= 7 && fishermen <= 11)
                {
                    sum = winterPrice - winterPrice * 0.15;
                }
                else if (fishermen >= 12)
                {
                    sum = winterPrice - winterPrice * 0.25;
                }
                
            }
            if (fishermen % 2 == 0 && season != "Autumn")
            {
                sum = sum - sum * 0.05;
            }



            if (budget >= sum)
            {
                Console.WriteLine($"Yes! You have {budget - sum:f2} leva left.");
            }
            else if (budget < sum)
            {
                Console.WriteLine($"Not enough money! You need {sum - budget:f2} leva.");
            }

        }
    }
}
