﻿using System;

namespace _02._Half_Sum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int max = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                sum += num;

                if (num > max)
                {
                    max = num;
                }
            }
                 int sumWithoutMax = sum - max;
                if (sumWithoutMax == max)
                {
                    Console.WriteLine("Yes");
                    Console.WriteLine($"Sum = {sumWithoutMax}");
                }
                else
                {
                    int diffSum = Math.Abs(max - sumWithoutMax);
                    Console.WriteLine("No");
                    Console.WriteLine($"Diff = {diffSum}");
                }


        }
    }
}
