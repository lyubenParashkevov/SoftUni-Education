using System;

namespace _06._Building
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());
            int lastFloor = floors;
            string roomTipe = "";
            
            for (int i = floors; i > 0; i--)
            {
                if (floors == lastFloor)
                {
                   roomTipe = "L";
                }
                else if (floors % 2 == 0)
                {
                    roomTipe = "O";
                }
                else
                {
                    roomTipe = "A";
                }
                
                for (int j = 0; j < rooms; j++)
                {

                    
                    Console.Write($"{roomTipe}{i}{j} ");
                    
                }
                floors--;
                Console.WriteLine();
            }
        }
    }
}
