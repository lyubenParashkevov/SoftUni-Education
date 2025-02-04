using System;

namespace Rock___Paper___Scissors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string Rock = "Rock";
            const string Paper = "Paper";
            const string Scissors = "Scissors";
            string playerMoove = "";

            Console.Write("Choose Rock, Paper or Scissors");
            playerMoove = Console.ReadLine();

            if (playerMoove == "r" || playerMoove == "rock")
            {
                playerMoove = Rock;
            }
            else if (playerMoove == "p" || playerMoove == "paper")
            {
                playerMoove = Paper;
            }
            else if (playerMoove == "s" || playerMoove == "scissors")
            {
                playerMoove = Scissors;
            }
            else
            {
                Console.WriteLine("Invalid input. Try again ");
                return;
            }
            Random random = new Random();
            int computerRandomNumber = random.Next(1, 4);

            string computersMoove = "";

            switch (computerRandomNumber)
            {
                case 1:
                    computersMoove = "Rock";
                    break;
                case 2:
                    computersMoove = "Paper";
                    break;
                case 3:
                    computersMoove = "Scissors";
                    break;
            }
            Console.WriteLine($"The computer chose {computersMoove}.");

            if ((playerMoove == Rock && computersMoove == Scissors) ||
                    (playerMoove == Scissors && computersMoove == Paper) ||
                (playerMoove == Paper && computersMoove == Rock))
            {
                Console.WriteLine("You win!");
            }
            else if ((playerMoove == Rock && computersMoove == Rock) ||
                (playerMoove == Scissors && computersMoove == Scissors) ||
                    (playerMoove == Paper && computersMoove == Paper))
            {
                Console.WriteLine("The game was draw.");
            }
            else if ((playerMoove == Scissors && computersMoove == Rock) ||
                (playerMoove == Paper && computersMoove == Scissors) ||
                (playerMoove == Rock && computersMoove == Paper))
            {
                Console.WriteLine("You loose.");
            }

        }
    }
}
         