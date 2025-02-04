using System;
using System.Linq;

namespace _03._Zig_Zag_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] firstArray = new int[n];
            int[] secondArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int j = 0; j < input.Length; j++)
                {
                    if (i % 2 == 0)
                    {

                        if (j % 2 == 0)
                        {
                            firstArray[i] = input[j];
                        }
                        else
                        {
                            secondArray[i] = input[j];
                        }
                    }
                    else
                    {
                        if (j % 2 == 0)
                        {
                            secondArray[i] = input[j];
                        }
                        else
                        {
                            firstArray[i] = input[j];
                        }
                    }
                }

            }

            Console.WriteLine(string.Join(' ', firstArray));
            Console.WriteLine(string.Join(' ', secondArray));
        }
    }
}
