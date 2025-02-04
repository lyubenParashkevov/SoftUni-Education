using System;

namespace _06._Vet_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            double sum = 0;
            double price = 0;
            double fullSum = 0;
            int dayCount = 0;
            for (int i = 1; i <= days; i++)
            {
                dayCount++;
                for (int j = 1; j <= hours; j++)
                {
                    
                    if (i % 2 != 0 && j % 2 != 0 ) 
                    {
                        price = 1.00;
                        sum += price;
                    }
                   else if (i % 2 == 0 && j % 2 == 0)
                    {
                        price = 1.00;
                        sum += price;
                    }
                    else if (i % 2 == 0 && j % 2 != 0)
                    {
                        price = 2.50;
                        sum += price;
                    }
                    else if (i % 2 != 0 && j % 2 == 0)
                    {
                        price = 1.25;
                        sum += price;
                    }
                    fullSum += price;
                }
                Console.WriteLine($"Day: {dayCount} - {sum:f2} leva");
                sum = 0;
            }
            Console.WriteLine($"Total: {fullSum:f2} leva");
        }
    }
}
