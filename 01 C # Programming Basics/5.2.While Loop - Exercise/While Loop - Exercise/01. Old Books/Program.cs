using System;

namespace _01._Old_Books
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string bookName = Console.ReadLine();
            int counter = 0;

            while(bookName != "No More Books")
            {
                string input = Console.ReadLine();
                if(input != bookName && input != "No More Books")
                {
                    counter++;
                }
                else if (input == bookName)
                {
                    Console.WriteLine($"You checked {counter} books and found it.");
                    break;
                }
                if(input == "No More Books")
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {counter} books.");
                    break;
                }
            }
        }
    }
}
