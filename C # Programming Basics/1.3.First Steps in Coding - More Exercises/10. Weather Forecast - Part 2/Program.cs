using System;

namespace _10._Weather_Forecast___Part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double degrees = double.Parse(Console.ReadLine());

            if (degrees < 5)
            {
                Console.WriteLine("unknown");
            }
            else if (degrees <= 11.9)
            {
                Console.WriteLine("Cold");
            }
            else if (degrees <= 14.9)
            {
                Console.WriteLine("Cool");
            }
            else if (degrees <= 20)
            {
                Console.WriteLine("Mild");
            }
            else if (degrees <= 25.9)
            {
                Console.WriteLine("Warm");
            }
            else if (degrees <= 35)
            {
                Console.WriteLine("Hot");
            }
            else
            {
                Console.WriteLine("unknown");
            }

            
        }
    }
}
