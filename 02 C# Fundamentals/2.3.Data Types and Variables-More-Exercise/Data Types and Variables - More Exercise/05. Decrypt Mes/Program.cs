using System;

namespace _05._Decrypt_Mes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int charNum = int.Parse(Console.ReadLine());

            char ch;
            int num = 0;
            for (int i = 0; i < charNum; i++)
            {
                string letter = (Console.ReadLine());
                ch = char.Parse(letter);

                num = (int)ch + key;

                Console.Write((char)num);
            }
        }
    }
}
