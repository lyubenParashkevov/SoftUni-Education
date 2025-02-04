using System;

namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wagonsNum = int.Parse(Console.ReadLine());
            int[] wagons = new int[wagonsNum];
            int sum = 0;


            for (int i = 0; i < wagons.Length; i++)
            {
                int passengers = int.Parse(Console.ReadLine());
                wagons[i] = passengers;
                sum += passengers;
            }
            Console.WriteLine(string.Join(' ',wagons));
            Console.WriteLine(sum);
        }
    }
}
