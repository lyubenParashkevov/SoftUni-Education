using System;

namespace _11._Fruit_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double quantiy = double.Parse(Console.ReadLine());
            double price = 0;
            double tottalSum = quantiy * price;
            if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
            {

                if (fruit != "banana" || fruit != "apple" || fruit != "orange" || fruit != "grapefruit" || fruit != "pineapple" || fruit != "grapes" || fruit != "kiwi")
                {
                    Console.WriteLine("error");
                }
                   if (fruit == "banana")
                   {
                    price = 2.50;
                   }
                   else if (fruit == "apple")
                   {
                    price = 1.20;
                   }
                   else if (fruit == "orange")
                   {
                    price = 0.85;
                   }
                   else if (fruit == "grapefruit")
                   {
                    price = 1.45;
                   }
                   else if (fruit == "pineapple")
                   {
                    price = 5.50;
                   }
                   else if (fruit == "grapes")
                   {
                    price = 3.85;
                   }
                   else if (fruit == "kiwi")
                   {
                    price = 2.70;
                    }
                   {
                     Console.WriteLine($"{tottalSum:f2}");
                   }

            }
            else if (day == "Saturday" || day == "Sunday")
            {
                if (fruit != "banana" || fruit != "apple" || fruit != "orange" || fruit != "grapefruit" || fruit != "pineapple" || fruit != "grapes" || fruit != "kiwi")
                {
                    Console.WriteLine("error");
                }
            }
            else if (fruit == "banana")
            {
               price = 2.70;
            }
            else if (fruit == "apple")
            {
               price = 1.25;
            }
            else if (fruit == "orange")
            {
               price = 0.90;
            }
            else if (fruit == "grapefruit")
            {
               price = 1.60;
            }
            else if (fruit == "kiwi")
            {
               price = 3.00;
            }
            else if (fruit == "pineapple")
            {
               price = 5.60;
            }
            else if (fruit == "grapes")
            {
               price = 4.20;
            }
            {
               Console.WriteLine($"{tottalSum:f2}");
            }

            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}

