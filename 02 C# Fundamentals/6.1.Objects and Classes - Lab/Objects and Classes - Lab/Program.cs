using System;

namespace Objects_and_Classes___Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split(' ');

            Random random = new Random();

            for (int i = 0; i < text.Length; i++)
            {
                int newIndex = random.Next(0, text.Length);

                string curWord = text[i];
                text[i] = text[newIndex];
                text[newIndex] = curWord;

            }

            foreach (string word in text)
            {
                Console.WriteLine(word);
            }
        }
    }
}