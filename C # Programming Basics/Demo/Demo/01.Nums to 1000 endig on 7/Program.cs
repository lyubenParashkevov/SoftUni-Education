using System;

namespace _01.Nums_to_1000_endig_on_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            for (int i = 7; i <= 997; i++)
            {
                if (i % 10 ==7)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
