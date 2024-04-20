using System;

namespace _06._Vowels_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int sum = 0;
            for  (int i = 0; i < text.Length; i++)
            {
                char currentChar = text[i];
                

                if (currentChar == 'a')
                    sum += 1;
                else if (currentChar == 'e')
                    sum += 2;
                else if (currentChar == 'i')
                    sum += 3;
                else if (currentChar == 'o')
                    sum += 4;
                else if (currentChar == 'u')
                    sum += 5;
                else
                    sum += 0;
            }
              Console.WriteLine(sum);

        }
    }
}
