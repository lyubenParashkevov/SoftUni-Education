using System;

namespace _06._Cake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int allPieces = width * lenght;
            int eatenPiecesSum = 0;
            int eatenPieces = 0;
            string input = "";
            while ((input = Console.ReadLine()) != "STOP")
            {
                eatenPieces = int.Parse(input);
                eatenPiecesSum += eatenPieces;
                if (eatenPiecesSum >= allPieces)
                {
                    Console.WriteLine($"No more cake left! You need {eatenPiecesSum - allPieces} pieces more.");
                    return;
                }
            }
            Console.WriteLine($"{allPieces - eatenPiecesSum} pieces are left.");

        }
    }
}
