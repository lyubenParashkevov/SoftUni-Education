using System;
using System.Linq;

namespace _01._Sort_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 3; i++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                Console.WriteLine(numbers[i]);
            }


        }
    }
}
