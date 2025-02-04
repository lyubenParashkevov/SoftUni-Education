using System;

namespace _07._Food_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double costChicken = 10.35;
            double costFish = 12.40;
            double costVegan = 8.15;
            double delivery = 2.50;

            double numChicken = double.Parse(Console.ReadLine());
            double numFish = double.Parse(Console.ReadLine());
            double numVegan = double.Parse(Console.ReadLine());

            double sum = numChicken * costChicken + numFish * costFish + numVegan * costVegan;
            double dessert = sum * 0.20;
            double finalSum = sum + dessert + delivery;

            Console.WriteLine(finalSum);


        }
    }
}
