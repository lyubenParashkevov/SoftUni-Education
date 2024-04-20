using System;

namespace _04._Balls
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counterRed = 0;
            int counterWhite = 0;
            int counterOrange = 0;
            int counterBlack = 0;
            int counterYellow = 0;
            int countOtherColours = 0;

            double sum = 0;
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string colour = Console.ReadLine();
                if (colour == "red")
                {
                    sum += 5;
                    counterRed++;

                }
                else if (colour == "orange")
                {
                    sum += 10;
                    counterOrange++;

                }
                else if (colour == "yellow")
                {
                    sum += 15;
                    counterYellow++;

                }
                else if (colour == "white")
                {
                    sum += 20;
                    counterWhite++;

                }
                else if (colour == "black")
                {
                    sum = Math.Floor(sum / 2);
                    counterBlack++;

                }
                else if (colour != "red" && colour != "orange" && colour != "yellow" && colour != "white" && colour != "black")
                {
                    sum += 0;
                    countOtherColours++;
                   
                }
            }
            Console.WriteLine($"Total points: {sum}");
            Console.WriteLine($"Red balls: {counterRed}");
            Console.WriteLine($"Orange balls: {counterOrange}");
            Console.WriteLine($"Yellow balls: {counterYellow}");
            Console.WriteLine($"White balls: {counterWhite}");
            Console.WriteLine($"Other colors picked: {countOtherColours}");
            Console.WriteLine($"Divides from black balls: {counterBlack}");









        }
    }
}
