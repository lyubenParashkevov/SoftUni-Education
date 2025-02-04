using System;

namespace _06._Name_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNameSum = 0;            
            string firstName = "";           
            string name = "";
            string input = "";
            int sum = 0;
         
            for (int i = 0; i < 2; i++)
            {
                input = Console.ReadLine();
                if (input == "Stop")
                {
                    break;
                }
                firstName = name;
                firstNameSum = sum;
                name = input;
                sum = 0;
                for (int j = 0; j < name.Length; j++)
                {
                    int num = int.Parse(Console.ReadLine());
                    char letter = name[j];
                    if (letter == num)
                    {
                        sum += 10;
                    }
                    else
                    {
                        sum += 2;
                    }   
                }
            }
            if (firstNameSum > sum)
            {
                Console.WriteLine($"The winner is {firstName} with {firstNameSum} points!");
            }
            else
            {
                Console.WriteLine($"The winner is {name} with {sum} points!");
            }
        }
    }
}
