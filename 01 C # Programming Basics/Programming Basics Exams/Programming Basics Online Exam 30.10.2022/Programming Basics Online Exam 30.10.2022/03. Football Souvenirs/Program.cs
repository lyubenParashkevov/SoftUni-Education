using System;

namespace _03._Football_Souvenirs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string teams = Console.ReadLine();
            string souvenires = Console.ReadLine();
            int numSouvenires = int.Parse(Console.ReadLine());
            double price = 0;
            double allPaid = 0;
            if (teams == "Argentina")
            {
                if (souvenires == "flags")
                {
                    price = 3.25;
                }
                else if (souvenires == "caps")
                {
                    price = 7.20;
                }
                else if (souvenires == "posters")
                {
                    price = 5.10;
                }
                else if (souvenires == "stickers")
                {
                    price = 1.25;
                }
                 allPaid = numSouvenires * price;
            }
            else if (teams == "Brazil")
            {
                if (souvenires == "flags")
                {
                    price = 4.20;
                }
                else if (souvenires == "caps")
                {
                    price = 8.50;
                }
                else if (souvenires == "posters")
                {
                    price = 5.35;
                }
                else if (souvenires == "stickers")
                {
                    price = 1.20;
                }
                 allPaid = numSouvenires * price;
            }
            else if (teams == "Croatia")
            {
                if (souvenires == "flags")
                {
                    price = 2.75;
                }
                else if (souvenires == "caps")
                {
                    price = 6.90;
                }
                else if (souvenires == "posters")
                {
                    price = 4.95;
                }
                else if (souvenires == "stickers")
                {
                    price = 1.10;
                }
                 allPaid = numSouvenires * price;
            }
            else if (teams == "Denmark")
            {
                if (souvenires == "flags")
                {
                    price = 3.10;
                }
                else if (souvenires == "caps")
                {
                    price = 6.50;
                }
                else if (souvenires == "posters")
                {
                    price = 4.80;
                }
                else if (souvenires == "stickers")
                {
                    price = 0.90;
                }
                 allPaid = numSouvenires * price;
            }

            if (teams != "Argentina" && teams != "Brazil" && teams != "Croatia" && teams != "Denmark")
            {
                Console.WriteLine("Invalid country!");
            }
            else if (souvenires != "flags" && souvenires != "caps" && souvenires != "posters" && souvenires != "stickers")
            {
                Console.WriteLine("Invalid stock!");
            }
            else
            {
                Console.WriteLine($"Pepi bought {numSouvenires} {souvenires} of {teams} for {allPaid:f2} lv.");
            }
        }

    }
}
