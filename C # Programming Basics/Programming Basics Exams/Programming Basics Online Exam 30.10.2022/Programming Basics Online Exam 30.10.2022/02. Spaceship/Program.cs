using System;

namespace _02._Spaceship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double lenght = double.Parse(Console.ReadLine());
            double hight = double.Parse(Console.ReadLine());
            double astronoughtHight = double.Parse(Console.ReadLine());
            double shipVolume = width * lenght * hight;
            double singleRoomVolume = (astronoughtHight + 0.40) * 2 * 2;
            double numRooms = Math.Floor(shipVolume / singleRoomVolume);
            if (numRooms < 3)
            {
                Console.WriteLine("The spacecraft is too small.");
            }
            else if (numRooms <= 10)
            {
                Console.WriteLine($"The spacecraft holds {numRooms} astronauts.");
            }
            else if (numRooms > 10)
            {
                Console.WriteLine("The spacecraft is too big.");
            }
        }
    }
}
