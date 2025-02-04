using System;
using System.Linq;

namespace _06._Equal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input.Length == 1)
                {
                    Console.WriteLine(0);
                    return;
                }
                leftSum = 0;
                for (int j = i; j > 0; j--)
                {
                    int nextLeftPosition = j - 1;
                    if (j > 0)
                    {
                        leftSum+= input[nextLeftPosition];
                    }
                }
                rightSum = 0;
                for (int r = i; r < input.Length; r++)
                {
                    int nextRightPosition = r + 1;
                    if (r < input.Length - 1)
                    {
                        rightSum += input[nextRightPosition];
                    }
                }
                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
            Console.WriteLine("no");
        }
    }
}
