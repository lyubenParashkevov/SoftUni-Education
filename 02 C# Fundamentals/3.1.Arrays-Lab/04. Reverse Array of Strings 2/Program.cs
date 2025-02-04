using System;

namespace _04._Reverse_Array_of_Strings_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputToReverse = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = inputToReverse.Length -1; i >= 0; i--)
            {
                Console.Write($"{inputToReverse[i]} ");
            }
        }
    }
}
