using System;
using System.Linq;

namespace _01._Encrypt__Sort_and_Print_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numArreys = int.Parse(Console.ReadLine());
            int sum = 0;
            int[] results = new int[numArreys];
            int smalerNum = 0;
            for (int k = 0; k < results.Length; k++)
            {
                string names = Console.ReadLine();
                for (int j = 0; j < names.Length; j++)
                {
                    if (names[j] == 'a' || names[j] == 'e' || names[j] == 'i' || names[j] == 'o' || names[j] == 'u')
                    {
                        sum += names[j] * names.Length;
                    }
                    else
                    {
                        sum += names[j] / names.Length;
                    }
                }
                results[k] = sum;
                sum = 0;
            }
            for (int i = 0; i < results.Length; i++)
            {
                for (int l = 0; l < results.Length; l++)
                {

                    if (results[l] < results[i])
                    {
                        smalerNum = results[l];
 
                    }
                }
                Console.WriteLine(smalerNum);
            }

        }
    }
}
