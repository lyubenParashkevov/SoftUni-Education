using System;

namespace _05._Suitcases_Load
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double trunkVolume = double.Parse(Console.ReadLine());
            string input = "";
            int suitcaseCount = 0;

            double suitcaseVolume = 0;
            while (true)
            {
                input = Console.ReadLine();

                if (input == "End")
                {
                    Console.WriteLine("Congratulations! All suitcases are loaded!");
                    Console.WriteLine($"Statistic: {suitcaseCount} suitcases loaded.");
                    break;
                }



                suitcaseVolume = double.Parse(input);
                if (trunkVolume < suitcaseVolume)
                {
                    Console.WriteLine("No more space!");
                    Console.WriteLine($"Statistic: {suitcaseCount} suitcases loaded.");
                    break;
                }
                suitcaseCount++;
                if (suitcaseCount % 3 == 0)
                {
                    suitcaseVolume += suitcaseVolume * 0.10;
                }
                trunkVolume -= suitcaseVolume;
                if (trunkVolume == 0)
                {
                    Console.WriteLine("No more space!");
                    Console.WriteLine($"Statistic: {suitcaseCount} suitcases loaded.");
                    break;
                }


            }
        }
    }
}
