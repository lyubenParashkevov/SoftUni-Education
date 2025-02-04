using System;

namespace _07._Hotel_Room
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double studioPrice = 0;
            double apartmentPrice = 0;
            double studioSum = 0;
            double apartmentSum = 0;

            if (month == "May" || month == "October")
            {
                studioPrice = 50;
                apartmentPrice = 65;
                studioSum = nights * studioPrice;
                apartmentSum = nights * apartmentPrice;
                if (nights > 7 && nights <= 14)
                {
                    studioSum -= studioSum * 0.05;
                }
                else if (nights > 14)
                {
                    studioSum -= studioSum * 0.3;
                    apartmentSum -= apartmentSum * 0.1;
                }
            }
            else if (month == "June" || month == "September")
            {
                studioPrice = 75.20;
                apartmentPrice = 68.70;
                studioSum = nights * studioPrice;
                apartmentSum = nights * apartmentPrice;
                if (nights > 14)
                {
                    studioSum -= studioSum * 0.20;
                    apartmentSum -= apartmentSum * 0.1;
                }
            }
            else if (month == "July" || month == "August")
            {
                studioPrice = 76;
                apartmentPrice = 77;
                studioSum = nights * studioPrice;
                apartmentSum = nights * apartmentPrice;

                if (nights > 14)
                {
                    apartmentSum -= apartmentSum * 0.10;
                }
            }
            Console.WriteLine($"Apartment: {apartmentSum:f2} lv.");
            Console.WriteLine($"Studio: {studioSum:f2} lv.");
        }
    }
}
