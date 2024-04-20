using System;

namespace _06._Fishland
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            double skumriaPrice = double.Parse(Console.ReadLine());
            double cacaPrice = double.Parse(Console.ReadLine());
            double palamudKg = double.Parse(Console.ReadLine());
            double safridKg = double.Parse(Console.ReadLine());
            double midikg = double.Parse(Console.ReadLine());

            double palamudPrice = skumriaPrice + skumriaPrice * 0.6;
            double safridPrice = cacaPrice  + cacaPrice *0.8;
            double midiPrice = 7.50;
            

            double sum = (palamudKg * palamudPrice) + (safridKg * safridPrice) + (midikg * midiPrice);

            Console.WriteLine($"{sum:f2}");
               

        }
    }
}
