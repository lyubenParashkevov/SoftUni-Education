using System;
using System.Linq;

namespace _05._Sum_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputNums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int sum = 0;
            

            for (int i = 0; i < inputNums.Length; i++)
            {
                int number = inputNums[i];

                if (number % 2 == 0)
                {
                    sum += number;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
