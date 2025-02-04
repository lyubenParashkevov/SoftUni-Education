using System;

namespace _01._Dishwasher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bottles = int.Parse(Console.ReadLine());
            string input = "";
            int chemicalMl = bottles * 750;
            int dishes = 0;
            
            int count = 0;
            int platesCount = 0;    
            int potCounts = 0;
            while (true)
            {
                    input = Console.ReadLine();
                if (input == "End")
                    break;
                else
                {
                    dishes = int.Parse(input);
                    count++;
                    if (count == 3)
                    {
                       
                        chemicalMl -= dishes * 15;  
                        count = 0;
                        potCounts += dishes;
                    }
                    else
                    {
                       
                        chemicalMl -= dishes * 5;
                        platesCount += dishes;
                    }
                }
                if (chemicalMl <= 0)
                {
                    Console.WriteLine($"Not enough detergent, {Math.Abs(chemicalMl)} ml. more necessary!");
                    return;
                }
            }
            Console.WriteLine("Detergent was enough!");
            Console.WriteLine($"{platesCount} dishes and {potCounts} pots were washed.");
            Console.WriteLine($"Leftover detergent {chemicalMl} ml.");
            return;
        }
    }
}
