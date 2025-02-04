using System;

namespace _05._Excursion_Sale
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int seaTrips = int.Parse(Console.ReadLine());
            int mountainTrip = int.Parse(Console.ReadLine());
            double seaPrice = 680;
            double mountainPrice = 499;
            double sum = 0;
            int seaCount = 0;
            int mountainCount = 0;
            while (true)
            {
                if (seaTrips == seaCount && mountainTrip == mountainCount)
                    break;
                string tripTipes = Console.ReadLine();

                if (tripTipes == "Stop")
                {
                    Console.WriteLine($"Profit: {sum} leva.");
                    return;
                }


                
                if (tripTipes == "sea")
                {
                    seaCount++;
                    if (seaCount > seaTrips)
                    {
                        sum += 0;
                        seaCount--;
                    }
                    else
                    {
                    sum += seaPrice;
                    }

                }
                else if (tripTipes == "mountain")
                {
                    mountainCount++;
                    if (mountainCount > mountainTrip)
                    {
                        sum += 0;
                        mountainCount--;
                    }
                    else
                    {
                    sum += mountainPrice;
                    }

                }

            }
            Console.WriteLine($"Good job! Everything is sold.");
            Console.WriteLine($"Profit: {sum} leva.");

        }
    }
}
