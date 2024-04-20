using System;

namespace _09._Ski_Trip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string accommodation = Console.ReadLine();
            string grade = Console.ReadLine();
            double roomForOnePersonPrice = 18.00;
            double apartmentPrice = 25.00;
            double presidentApartmentPrice = 35.00;
            double fullPrice = 0;
            if (accommodation == "room for one person")
            {
                fullPrice = (days - 1) * roomForOnePersonPrice;
               
                if (grade == "positive")
                {
                    fullPrice += fullPrice * 0.25;
                }
                else if (grade == "negative")
                {
                    fullPrice -= fullPrice * 0.10;
                }
            }
            else if (accommodation == "apartment")
            {
                fullPrice = (days - 1) * apartmentPrice;
                if (days < 10)
                {
                    fullPrice -= fullPrice * 0.3;
                }
                else if (days >= 10 && days <= 15)
                {
                    fullPrice -= fullPrice * 0.35;
                }
                else if (days > 15)
                {
                    fullPrice -= fullPrice * 0.5;
                }

                if (grade == "positive")
                {
                    fullPrice += fullPrice * 0.25;
                }
                else if (grade == "negative")
                {
                    fullPrice -= fullPrice * 0.10;
                }
            }
            else if (accommodation == "president apartment")
            {
                fullPrice = (days - 1) * presidentApartmentPrice;
                if (days < 10)
                {
                    fullPrice -= fullPrice * 0.1;
                }
                else if (days >= 10 && days <= 15)
                {
                    fullPrice -= fullPrice * 0.15;
                }
                else if (days > 15)
                {
                    fullPrice -= fullPrice * 0.2;
                }
                if (grade == "positive")
                {
                    fullPrice += fullPrice * 0.25;
                }
                else if (grade == "negative")
                {
                    fullPrice -= fullPrice * 0.10;
                }
            }

            Console.WriteLine($"{fullPrice:f2}");



        }
    }
}
