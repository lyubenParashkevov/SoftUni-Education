using System;

namespace _03._Flowers
{
    internal class Program
    {
        static void Main(string[] args)
        {


            int numHrizantemas = int.Parse(Console.ReadLine());
            int numRoses = int.Parse(Console.ReadLine());
            int numTulips = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string dayTipe = Console.ReadLine();
            double hrizantemaPrice = 0;
            double rosesPrice = 0;
            double tulipsPrice = 0;
            double bucketPrice = 0;

            if (season == "Spring" || season == "Summer")
            {
                if (dayTipe == "N")
                {
                    rosesPrice = 4.10;
                    hrizantemaPrice = 2.00;
                    tulipsPrice = 2.50;
                }
                else if (dayTipe == "Y")
                {
                    hrizantemaPrice += hrizantemaPrice * 0.15;
                    rosesPrice += rosesPrice * 0.15;
                    tulipsPrice += tulipsPrice * 0.15;
                }
                bucketPrice = numHrizantemas * hrizantemaPrice + numRoses * rosesPrice + numTulips * tulipsPrice;
                if (numTulips > 7)
                {
                    bucketPrice -= bucketPrice * 0.05;
                }
            }
            else if (season == "Autumn" || season == "Winter")
            {
                if (dayTipe == "N")
                {
                    hrizantemaPrice = 3.75;
                    rosesPrice = 4.50;
                    tulipsPrice = 4.15;
                }
                else if (dayTipe == "Y")
                {
                    hrizantemaPrice += hrizantemaPrice * 0.15;
                    rosesPrice += rosesPrice * 0.15;
                    tulipsPrice += tulipsPrice * 0.15;
                }
                bucketPrice = numHrizantemas * hrizantemaPrice + numRoses * rosesPrice + numTulips * tulipsPrice;
                if (numRoses >= 10 && season == "Winter")
                {
                    bucketPrice -= bucketPrice * 0.10;
                }
            }
            if (numHrizantemas + numTulips + numRoses > 20)
            {
                bucketPrice -= bucketPrice * 0.20;
            }
            Console.WriteLine($"{bucketPrice + 2:f2}");
        }
    }
}
