using System;

namespace _4.Car_to_Go
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());   
            string season = Console.ReadLine();
            string clas = "";
            string carTipe = "";
            double carPrice = 0;
            if (season == "Summer")
            {
                
                if (budget <= 100)
                {
                    carTipe = "Cabrio";
                    clas = "Ekonomy class";
                    carPrice = budget * 0.35;
                }
                else if (budget <= 500)
                {
                    carTipe = "Cabrio";
                    clas = "Compact class";
                    carPrice = budget * 0.45;
                }

                else
                {
                    carTipe = "Jeep";
                    clas = "Luxury class";
                    carPrice = budget * 0.9;
                }
            }
            else if (season == "Winter")
            {
                carTipe = "Jeep";
                if (budget <= 100)
                {
                    clas = "Ekonomy class";
                    carPrice = budget * 0.65;
                }
                else if (budget <= 500)
                {
                    clas = "Compact class";
                    carPrice = budget * 0.8;
                }
                else
                {
                    clas = "Luxury class";
                    carPrice = budget * 0.9;
                }
            }

            Console.WriteLine($"{clas}");
            Console.WriteLine($"{carTipe} - {carPrice:f2}");




            
        }
    }
}
