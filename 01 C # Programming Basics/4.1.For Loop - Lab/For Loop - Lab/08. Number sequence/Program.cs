﻿using System;

namespace _08._Number_sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {


            int n = int.Parse(Console.ReadLine());
            int maxNum = int.MinValue;
            int minNum = int.MaxValue;

            for (int i = 0; i < n; i++)
            {
                int currNum = int.Parse(Console.ReadLine());
            
                 if (currNum > maxNum)
                 {
                    maxNum = currNum;
                 }
                 if (currNum < minNum)
                {
                    minNum = currNum;
                }

            }
            Console.WriteLine($"Max number: {maxNum}");
            Console.WriteLine($"Min number: {minNum}");

        }
    }
}
