﻿namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                   
                    if (numbers[i] + numbers[j] == n)
                    {
                        Console.WriteLine($"{numbers[i]} {numbers[j]}");
                    }
                    
                }
            }
        }
    }
}