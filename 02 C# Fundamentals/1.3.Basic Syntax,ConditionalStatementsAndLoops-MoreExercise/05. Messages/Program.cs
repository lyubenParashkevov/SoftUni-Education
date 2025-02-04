using System;

namespace _05._Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numClicks = int.Parse(Console.ReadLine());
            string sms = "";
            for (int i = 1; i <= numClicks; i++)
            {
                string digit = Console.ReadLine();
                int digitLength = digit.Length;

                int mainDigit = int.Parse(digit) % 10;
                int offset = (mainDigit - 2) * 3;

                if (mainDigit == 8 || mainDigit == 9)
                {
                    offset++;
                }
                if (mainDigit == 0)
                {
                    sms += (char)(32);
                    continue;
                }
                int letterIndex = offset + digitLength - 1;
                sms += (char)(letterIndex + 97);
            }
            Console.WriteLine(sms); 
        }
    }
}
