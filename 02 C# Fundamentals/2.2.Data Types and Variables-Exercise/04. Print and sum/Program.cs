﻿using System;

namespace _04._Print_and_sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = firstNum; i <= secondNum; i++)
            {
                sum += i;
               Console.Write($"{i} ");
                 
            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
