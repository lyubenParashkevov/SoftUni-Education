using System.Runtime.InteropServices;

namespace _03._Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            string filePath = Console.ReadLine();

            int startindex = filePath.LastIndexOf('\\');

            string[] nameAndExtention = filePath.Substring(startindex + 1).Split('.');
            Console.WriteLine($"File name: {nameAndExtention[0]}");
            Console.WriteLine($"File extension: {nameAndExtention[1]}");

        }
    }
}