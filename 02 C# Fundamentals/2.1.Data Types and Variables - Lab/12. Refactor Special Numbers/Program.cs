﻿using System;

namespace _12._Refactor_Special_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            
            for (int i = 1; i <= n; i++)
            {
                int digit = i;
                int sum = 0;

                while (digit != 0)
                {
                    sum += digit % 10;
                    digit /= 10;
                }
                if (sum == 5 || sum == 7 || sum == 11)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }

               
            }

        }
    }
}
