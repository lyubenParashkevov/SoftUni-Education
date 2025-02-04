using System;

namespace _05._Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            int counter = 0;
            while (true)
            {
                string currPass = Console.ReadLine();
                string revPass = "";
                counter++;
                for (int i = currPass.Length - 1; i >= 0; i--)
                {
                    revPass += currPass[i];
                }

                if (revPass == username)
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }
                if (counter == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }
                if (revPass != username)
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }
            }
        }
    }
}
