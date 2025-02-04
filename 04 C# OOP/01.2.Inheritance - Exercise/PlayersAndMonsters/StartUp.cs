using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Hero hero = new("Pesho", 12);
            Console.WriteLine(hero.ToString());
        }
    }
}