using System;

namespace Guess_a_Number_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random randomNumber = new Random();
            int computerNumber = randomNumber.Next(1, 101);

            while (true)
            {
                Console.Write("Guess a number (1 - 100): ");
                string playerInput = Console.ReadLine();
                bool isValid = int.TryParse(playerInput, out int playerNumber);

                if (isValid && playerNumber > 1 && playerNumber <= 100)
                {
                    if(playerNumber == computerNumber)
                    {
                        Console.WriteLine("Yoy guessed it!");
                        break;
                    }
                    else if (playerNumber > computerNumber)
                    {
                        Console.WriteLine("Too High");
                    }
                    else
                    {
                        Console.WriteLine("Too Low");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid Input.");
                }
            }
        }
    }
}
