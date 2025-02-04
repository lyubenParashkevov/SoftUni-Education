using System;

namespace _01._Match_Tickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int numPeople = int.Parse(Console.ReadLine());
            double ticketSum = 0;
            double transportCost = 0;
            double vipPrice = 499.99;
            double normalPrice = 249.99;
            if (numPeople <= 4)
            {
                transportCost = budget * 0.75;
            }
            else if (numPeople <= 9)
            {
                transportCost = budget * 0.6;
            }
            else if (numPeople <= 24)
            {
                transportCost = budget * 0.5;
            }
            else if (numPeople <= 49)
            {
                transportCost = budget * 0.4;
            }
            else if (numPeople >= 50)
            {
                transportCost = budget * 0.25;
            } 
             if (category == "VIP")
            {
                ticketSum = numPeople * vipPrice;
            }
             else if (category == "Normal")
            {
                ticketSum = numPeople * normalPrice;
            }
             double finalSum = ticketSum + transportCost;

            if (finalSum <= budget)
            {
                Console.WriteLine($"Yes! You have {budget - finalSum:f2} leva left.");
            }
             else if (finalSum > budget)
            {
                Console.WriteLine($"Not enough money! You need {finalSum - budget:f2} leva.");
            }   





        }
    }
}
