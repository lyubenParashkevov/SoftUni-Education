using System;

namespace _01._Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Тип Premiere – премиерна прожекция, на цена 12.00 лева.
            //Тип Normal – стандартна прожекция, на цена 7.50 лева.
            //Тип Discount – прожекция за деца, ученици и студенти на намалена цена от 5.00 лева.
            // Да се изчислят приходите при пълна зала в зависимост от типа прожекция :f2

            string tipe = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());
            int allSeats = rows * columns;

            double premierePrice = 12.00;
            double normalPrice = 7.50;
            double discountPrice = 5.00;

            if (tipe == "Premiere")
            {
                Console.WriteLine($"{allSeats * premierePrice:f2} leva");
            }
            else if (tipe == "Normal")
            {
                Console.WriteLine($"{allSeats * normalPrice:f2} leva");
            }
            else if (tipe == "Discount")
            {
                Console.WriteLine($"{allSeats * discountPrice:f2} leva");
            }


        }
    }
}
