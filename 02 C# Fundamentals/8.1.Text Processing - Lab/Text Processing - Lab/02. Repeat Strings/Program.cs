﻿using System.Text;

namespace _02._Repeat_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            StringBuilder result = new StringBuilder();
            foreach (string word in words)
            {
                int number = word.Length;

                for (int i = 0; i < number; i++)
                {
                    result.Append(word);
                }

            }
            Console.WriteLine(result);
        }
    }
}