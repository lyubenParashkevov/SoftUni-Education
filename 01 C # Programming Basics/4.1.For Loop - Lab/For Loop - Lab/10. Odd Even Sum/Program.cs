using System;

namespace _10._Odd_Even_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sumEven = 0;
            int sumOdd = 0;
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                int element = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    sumEven += element;
                }
                else
                {
                    sumOdd += element;
                }
            }


            if (sumEven == sumOdd)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {sumEven}");
            }
            else
            {
                sum = sumEven - sumOdd;
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(sum)}");
            }


        }
    }
}
