using System;

namespace _04._Toy_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
           // ако играчките са >= 50  -  отстъпка 25% от обща цена
           // 10 % наем за магазин

            double trip = double.Parse(Console.ReadLine());
            int puzzleQuantity = int.Parse(Console.ReadLine());
            int dollQuantity = int.Parse(Console.ReadLine());
            int bearsQuantity = int.Parse(Console.ReadLine());
            int minionsQuantity = int.Parse(Console.ReadLine());
            int trucksQuantity = int.Parse(Console.ReadLine());
            int numToys = puzzleQuantity + dollQuantity + bearsQuantity + minionsQuantity + trucksQuantity;
            
            double puzzlePrice = 2.60;
            double dollPrice = 3.00;
            double bearsPrice = 4.10;
            double minionPrice = 8.20;
            double truckPrice = 2.00;

            double sum = puzzleQuantity * puzzlePrice + dollQuantity * dollPrice + bearsQuantity * bearsPrice 
                + minionsQuantity * minionPrice + trucksQuantity * truckPrice;


            if (numToys < 50)
            {
                sum = sum;
            }
            else if (numToys >= 50)
            {
                sum = sum - sum * 0.25;
            }
            double tottalSum = sum - sum * 0.10;

            if (tottalSum >= trip)
            {
                Console.WriteLine($"Yes! {tottalSum - trip:f2} lv left.");
            }
            else if (tottalSum < trip)
            {
                Console.WriteLine($"Not enough money! {trip - tottalSum:f2} lv needed.");
            }

        }
    }
}
