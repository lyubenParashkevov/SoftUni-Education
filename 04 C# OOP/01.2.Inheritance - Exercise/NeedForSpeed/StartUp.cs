using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SportCar sCar = new(200, 100);
            sCar.Drive(20);
            Console.WriteLine(sCar.Fuel);
        }
    }
}
