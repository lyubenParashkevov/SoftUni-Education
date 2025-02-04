using System;

namespace _05._Journey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //	При 100лв.или по-малко – някъде в България: - Лято – 30 % от бюджета  -Зима – 70 % от бюджета
            //•	При 1000лв. или по малко – някъде на Балканите: - Лято – 40 % от бюджета, -Зима – 80 % от бюджета
            //•	При повече от 1000лв. – някъде из Европа; -При пътуване из Европа, независимо от сезона ще похарчи 90 % от бюджета.

            //1.•	Първи ред – „Somewhere in [дестинация]“ измежду “Bulgaria", "Balkans” и ”Europe”
            //2.•	Втори ред – “{Вид почивка} – {Похарчена сума}“
            //o	Сумата трябва да е закръглена с точност до вторият знак след запетаята.

            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double sum = 0;
            string destination = "";
            string vacationTipe = "";

            if (budget <= 100)
            {
                destination = "Bulgaria";
                if (season == "summer")
                {
                    sum = budget * 0.30;
                    vacationTipe = "Camp";
                }
                else if (season == "winter")
                {
                    sum = budget * 0.70;
                    vacationTipe = "Hotel";
                }
            }
            else if (budget <= 1000)
            {
                destination = "Balkans";
                if(season == "summer")
                {
                    sum = budget * 0.40;
                    vacationTipe = "Camp";
                }
                else if (season == "winter")
                {
                    sum = budget * 0.80;
                    vacationTipe = "Hotel";
                }
            }
            else if (budget > 1000)
            {
                destination = "Europe";
                sum = budget * 0.90;
                vacationTipe = "Hotel";
                
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{vacationTipe} - {sum:f2}");

        }
    }
}
