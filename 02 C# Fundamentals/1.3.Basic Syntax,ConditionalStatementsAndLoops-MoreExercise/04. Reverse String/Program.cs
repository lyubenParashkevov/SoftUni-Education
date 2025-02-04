using System;

namespace _04._Reverse_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] chars = input.ToCharArray();
            for (int i = chars.Length - 1; i >= 0; i--)
            {
                char[] newChars = new char[chars.Length];
                newChars[i] = chars[i];
                Console.Write(newChars[i]);
            }
            
        }
    }
}
