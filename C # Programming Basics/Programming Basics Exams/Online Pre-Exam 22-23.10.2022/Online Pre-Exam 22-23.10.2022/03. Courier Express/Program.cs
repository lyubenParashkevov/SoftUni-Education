using System;

namespace _03._Courier_Express
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double weight = double.Parse(Console.ReadLine());
            string servise = Console.ReadLine();
            int distanceKm = int.Parse(Console.ReadLine());
            double price = 0;
            double finalPrice = 0;
            double extraPrice = 0;
            if (servise == "standard")
            {
                if (weight < 1)
                {
                    price = 0.03;
                }
                else if (weight < 10)
                {
                    price = 0.05;
                }
                else if (weight < 40)
                {
                    price = 0.10;
                }
                else if (weight < 90)
                {
                    price = 0.15;
                }
                else if (weight < 150)
                {
                    price = 0.20;
                } 

            }
            else if (servise == "express")
            {
                if (weight < 1)
                {
                    price = 0.03;
                    extraPrice = price * 0.8;
                }
                else if (weight < 10)
                {
                    price = 0.05;
                    extraPrice = price * 0.4;
                }
                else if (weight < 40)
                {
                    price = 0.10;
                    extraPrice = price * 0.05;
                }
                else if (weight < 90)
                {
                    price = 0.15;
                    extraPrice = price * 0.02;
                }
                else if (weight < 150)
                {
                    price = 0.20;
                    extraPrice = price * 0.01;
                }
            }
            double allExtraPrice = weight * extraPrice;
            double deliveryPrice = distanceKm * price;
            finalPrice = deliveryPrice + allExtraPrice * distanceKm;

            Console.WriteLine($"The delivery of your shipment with weight of {weight:f3} kg. would cost {finalPrice:f2} lv.");

        }
    }
}
