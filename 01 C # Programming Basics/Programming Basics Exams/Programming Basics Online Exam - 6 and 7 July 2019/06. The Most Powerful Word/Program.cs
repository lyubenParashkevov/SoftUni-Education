using System;

namespace _06._The_Most_Powerful_Word
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string biggestWord = "";
            double bigestWordsum = double.MinValue;
            double wordSum = 0;
            string input = "";
            while (true)
            {
                input = Console.ReadLine();
                if (input == "End of words")
                {
                    Console.WriteLine($"The most powerful word is {biggestWord} - {bigestWordsum}");
                    break;
                }
                for (int i = 0; i < input.Length; i++)
                {
                    char letter = input[i];
                    wordSum += input[i];

                }
                if (input[0] == 'a' || input[0] == 'o' || input[0] == 'e' || input[0] == 'i' || input[0] == 'u' || input[0] == 'y' || input[0] == 'A' || input[0] == 'O' || input[0] == 'U' || input[0] == 'E' || input[0] == 'I' || input[0] == 'Y')
                {
                    wordSum = wordSum * input.Length;
                    if (wordSum > bigestWordsum)
                    {
                        bigestWordsum = wordSum;
                        biggestWord = input;
                    }
                }
                else
                {
                    wordSum = Math.Floor(wordSum / input.Length);
                    if (wordSum > bigestWordsum)
                    {
                        bigestWordsum = wordSum;
                        biggestWord = input;
                    }


                }
                wordSum = 0;

            }



        }
    }
}
